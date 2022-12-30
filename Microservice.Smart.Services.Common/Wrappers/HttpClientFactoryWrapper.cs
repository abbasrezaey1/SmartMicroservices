using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.Common.Wrappers
{
	using Contracts;

	/// <summary>
	/// Class HttpClientFactoryWrapper
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class HttpClientFactoryWrapper : IHttpClientFactoryWrapper
	{
		private readonly IHttpClientFactory _httpClientFactory;

		/// <summary>
		/// Create new wrapper around http client factory.
		/// </summary>
		/// <param name="httpClientFactory">The httpClientFactory</param>
		public HttpClientFactoryWrapper(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IHttpClientWrapper CreateClient(string name = "")
		{
			// if there is a name a client will be created by that name and any config that has been applied in DI.
			// otherwise a simple http client will be generated.
			var httpClient = string.IsNullOrEmpty(name) ? _httpClientFactory.CreateClient() : _httpClientFactory.CreateClient(name);

			return new HttpClientWrapper(httpClient);
		}
	}
}
