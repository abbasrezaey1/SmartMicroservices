using Microservice.Smart.Services.GoogleMapInfo.Contracts;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;
using System.Text.Json;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.Common.Constants;

namespace Microservice.Smart.Services.GoogleMapInfo.Services
{
	/// <summary>
	/// Class GoogleDistanceService
	/// </summary>
	public class GoogleDistanceService : IGoogleDistanceService
	{
		private readonly IHttpClientFactoryWrapper _httpClientFactoryWrapper;
		private readonly IGoogleApiConfiguration _googleApiConfiguration;

		/// <summary>
		/// Create a new instance of Google distance service
		/// </summary>
		/// <param name="googleApiConfiguration">The googleApiConfiguration</param>
		/// <param name="httpClientFactoryWrapper">The httpClientFactoryWrapper</param>
		public GoogleDistanceService(IGoogleApiConfiguration googleApiConfiguration, IHttpClientFactoryWrapper httpClientFactoryWrapper)
		{
			_googleApiConfiguration = googleApiConfiguration;
			_httpClientFactoryWrapper = httpClientFactoryWrapper;
		}

		/// <summary>
		/// Gets map distance between two cities by using Google’s Distance API 
		/// </summary>
		/// <param name="originCity">The originCity</param>
		/// <param name="destinationCity">The destinationCity</param>
		/// <returns>Google distance data</returns>
		public async Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity)
		{
			// get api key and api url from configuration.
			var apiKey = _googleApiConfiguration.GoogleApiKey;
			var googleDistanceApiUrl = _googleApiConfiguration.GoogleApiUrl;

			// build final url based on google documentation.
			googleDistanceApiUrl += string.Format(GoogleApiConstants.GoogleApiUrlTemplate, originCity, destinationCity, apiKey);

			// create http client wrapper.
			var httpClientWrapper = _httpClientFactoryWrapper.CreateClient(DependencyNameConstants.GoogleApiClientName);

			// call the service.
			var responseStr = await httpClientWrapper.GetStringAsync(googleDistanceApiUrl);

			// prepare the response and return it to caller.
			var distanceInfo = JsonSerializer.Deserialize<GoogleDistanceData>(responseStr);
			return distanceInfo;
		}
	}
}
