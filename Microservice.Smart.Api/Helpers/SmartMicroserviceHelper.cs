using Microservice.Smart.Api.Contracts;
using Microservice.Smart.Api.Enumerations;
using Microservice.Smart.Api.Extensions;
using Microservice.Smart.Api.Models.DBO;
using Microservice.Smart.Api.Models.Requests;
using Microservice.Smart.Api.Models.Responses;
using Microservice.Smart.Services.Common.Constants;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.Common.Wrappers;
using Microservice.Smart.Services.RequestReceiver;

namespace Microservice.Smart.Api.Helpers
{
    /// <summary>
    /// Class MapInfoHelper
    /// </summary>
    public class SmartMicroserviceHelper : Contracts.SmartMicroserviceHelper
	{
		private readonly IRequestReceiverWrapper _requestReceiverWrapper;
		private readonly IDapperWrapper _dapperWrapper;

		/// <summary>
		/// Create a new instance of MapInfoHelper
		/// </summary>
		/// <param name="requestReceiverWrapper">The requestReceiverWrapper</param>
		/// <param name="dapperWrapper">The dapperWrapper</param>
		public SmartMicroserviceHelper(IRequestReceiverWrapper requestReceiverWrapper, IDapperWrapper dapperWrapper)
		{
			_requestReceiverWrapper = requestReceiverWrapper;
			_dapperWrapper = dapperWrapper;
		}

		/// <summary>
		/// Gets distance between two cities.
		/// </summary>
		/// <param name="originCity">The originCity</param>
		/// <param name="destinationCity">The destinationCity</param>
		/// <returns></returns>
		public async Task<MapInfoResponse> GetDistance(string originCity, string destinationCity)
		{
			var response = new MapInfoResponse();

			try
			{
				var request = new Cities()
				{
					DestinationCity = destinationCity,
					OriginCity = originCity
				};

				// calling google distance microservice
				response.Miles = (await _requestReceiverWrapper.GetDistance(request)).Miles;
			}
			catch (Exception e)
			{
				// in case of any error, the data will be null and errors will be returned as array of string.
				response.Errors = new List<string>()
				{
					e.Message
				};
			}

			return response;
		}

		public async Task<ISSNCodeResponse> CheckISSNCode(string code)
		{
			var response = new ISSNCodeResponse();

			try
			{
				var request = new ISSNCodeInput()
				{
					Code = code
				};

				// calling directly to ISSN code checker microservice
				response.Message = (await _requestReceiverWrapper.CheckISSNCode(request)).Message;
			}
			catch (Exception e)
			{
				// in case of any error, the data will be null and errors will be returned as array of string.
				response.Errors = new List<string>()
				{
					e.Message
				};
			}

			return response;
		}

		public async Task<GetSmartMicroserviceResponse> GetSmartMicroservices(SmartMicroserviceRequest microserviceRequest)
		{
			var response = new GetSmartMicroserviceResponse()
			{
				Error = new List<string>()
			};
			var filterExpression = string.Empty;

			var searchContext = new
			{
				Id = microserviceRequest.Id?.Trim(),
				Name = microserviceRequest.Name?.Trim(),
				microserviceRequest.Type,
				microserviceRequest.Category
			};

			if (microserviceRequest.Type != SmartMicroserviceType.Unknown)
			{
				filterExpression += string.Format(SqlConstants.MicroserviceTypeFilterQuery, Enum.GetName(microserviceRequest.Type));
			}

			if (microserviceRequest.Category != SmartMicroserviceCategory.Unknown)
			{
				filterExpression += string.Format(SqlConstants.MicroserviceCategoryFilterQuery, Enum.GetName(microserviceRequest.Category));
			}

			try
			{
				var smartMicroserviceDBOs =
					await _dapperWrapper.QueryAsync<SmartMicroserviceDBO>(
						SqlConstants.GetSmartMicroservicesSql + filterExpression, searchContext);

				response.SmartMicroservices = smartMicroserviceDBOs.ToMicroserviceResponse();
			}
			catch (Exception e)
			{
				response.Error = new List<string>()
				{
					e.Message
				};
			}

			return response;
		}
	}
}
