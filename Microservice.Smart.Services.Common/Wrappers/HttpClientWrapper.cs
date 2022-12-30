using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.Common.Wrappers
{
	using System.Net.Http;
	using System.Threading.Tasks;
	using Contracts;

	/// <summary>
	/// Class HttpClientWrapper
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class HttpClientWrapper : IHttpClientWrapper
	{
		private readonly HttpClient _httpClient;

		/// <summary>
		/// Create a new wrapper around http client.
		/// </summary>
		/// <param name="httpClient"></param>
		public HttpClientWrapper(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		/// A wrapper around http client GetStringAsync.
		/// </summary>
		/// <param name="requestUri">The requestUri</param>
		/// <returns></returns>
		public Task<string> GetStringAsync(string requestUri)
		{
			return _httpClient.GetStringAsync(requestUri);
		}
	}
}
