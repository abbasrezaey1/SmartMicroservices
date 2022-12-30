namespace Microservice.Smart.Services.Common.Contracts
{
	/// <summary>
	/// Interface IHttpClientFactoryWrapper
	/// </summary>
	public interface IHttpClientFactoryWrapper
	{
		IHttpClientWrapper CreateClient(string name = "");
	}
}
