namespace Microservice.Smart.Services.Common.Contracts
{
	/// <summary>
	/// Interface ISmartApiConfiguration
	/// </summary>
	public interface ISmartApiConfiguration
	{
		public string RequestReceiverGrpcChannelUrl { get; set; }
		public string SmartMicroserviceDBConnectionString { get; set; }
	}
}
