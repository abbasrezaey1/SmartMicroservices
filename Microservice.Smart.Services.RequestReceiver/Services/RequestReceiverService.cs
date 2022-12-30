using Grpc.Core;
using Microservice.Smart.Services.ISSNChecker;
using Microservice.Smart.Services.RequestReceiver.Contracts;

namespace Microservice.Smart.Services.RequestReceiver.Services
{
	/// <summary>
	/// Class RequestReceiverService
	/// </summary>
	public class RequestReceiverService : RequestReceiver.RequestReceiverBase
	{
		private readonly IGoogleDistanceWrapper _googleDistanceWrapper;
		private readonly IISSNCheckerWrapper _issnCheckerWrapper;

		public RequestReceiverService(IGoogleDistanceWrapper googleDistanceWrapper, IISSNCheckerWrapper issnCheckerWrapper)
		{
			_googleDistanceWrapper = googleDistanceWrapper;
			_issnCheckerWrapper = issnCheckerWrapper;
		}

		public override async Task<ISSNCodeResult> CheckISSNCode(ISSNCodeInput request, ServerCallContext context)
		{
			ISSNCodeResult response;

			try
			{
				var issnResponse = await _issnCheckerWrapper.CheckISSNCode(new CodeInput()
				{
					Code = request.Code,
				});

				response = new ISSNCodeResult()
				{
					Message = issnResponse.Message
				};
			}
			catch (Exception)
			{
				return default;
			}

			return response;
		}

		public override async Task<DistanceData> GetDistance(Cities request, ServerCallContext context)
		{
			DistanceData response;

			try
			{
				var googleResponse = await _googleDistanceWrapper.GetDistance(new GoogleDistance.Protos.Cities()
				{
					DestinationCity = request.DestinationCity,
					OriginCity = request.OriginCity
				});

				response = new DistanceData()
				{
					Miles = googleResponse.Miles,
				};

			}
			catch (Exception)
			{
				return default;
			}

			return response;
		}
	}
}