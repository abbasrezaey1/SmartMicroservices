using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.Common.Constants
{
	[ExcludeFromCodeCoverage]
	public class GoogleApiConstants
	{
		public const string GoogleApiBaseUrl = "googleDistanceApi:baseUrl";
		public const string GoogleApiKey = "googleDistanceApi:apiKey";
		public const string GoogleApiUrl = "googleDistanceApi:apiUrl";
		public const string GoogleApiUrlTemplate = "?units=imperial&origins={0}&destinations={1}&key={2}";
	}
}
