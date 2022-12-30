namespace Microservice.Smart.Services.Common.Contracts
{
	/// <summary>
	/// Interface IGoogleApiConfiguration
	/// </summary>
	public interface IGoogleApiConfiguration
	{
		public string GoogleApiBaseUrl { get; set; }	
		public string GoogleApiKey { get; set; }	
		public string GoogleApiUrl { get; set; }	
		public string GoogleApiUrlTemplate { get; set; }
	}
}
