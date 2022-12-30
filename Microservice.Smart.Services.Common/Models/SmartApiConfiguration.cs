using Microservice.Smart.Services.Common.Contracts;

namespace Microservice.Smart.Services.Common.Models
{
	/// <summary>
	/// Class SmartApiConfiguration
	/// </summary>
	public class SmartApiConfiguration : ISmartApiConfiguration
	{
		public string RequestReceiverGrpcChannelUrl { get; set; }
		public string SmartMicroserviceDBConnectionString { get; set; }
	}
}
