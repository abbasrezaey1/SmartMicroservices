namespace Microservice.Smart.Services.Common.Contracts
{
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IHttpClientWrapper
	/// </summary>
	public interface IHttpClientWrapper
	{
		Task<string> GetStringAsync(string requestUri);
	}
}
