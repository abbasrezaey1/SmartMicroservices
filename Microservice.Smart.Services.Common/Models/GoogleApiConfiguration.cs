using Microservice.Smart.Services.Common.Contracts;

namespace Microservice.Smart.Services.Common.Models
{
	/// <summary>
	/// Class GoogleApiConfiguration
	/// </summary>
	public class GoogleApiConfiguration : IGoogleApiConfiguration
	{
		public string GoogleApiBaseUrl { get; set; }
		public string GoogleApiKey { get; set; }
		public string GoogleApiUrl { get; set; }
		public string GoogleApiUrlTemplate { get; set; }
	}
}
