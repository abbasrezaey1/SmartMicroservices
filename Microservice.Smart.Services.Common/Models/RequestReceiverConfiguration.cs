using Microservice.Smart.Services.Common.Contracts;

namespace Microservice.Smart.Services.Common.Models
{
	/// <summary>
	/// Class RequestReceiverConfiguration
	/// </summary>
	public class RequestReceiverConfiguration : IRequestReceiverConfiguration
	{
		public string GoogleDistanceGrpcChannelUrl { get; set; }
		public string ISSNCheckerGrpcChannelUrl { get; set; }
	}
}
