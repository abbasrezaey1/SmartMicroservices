namespace Microservice.Smart.Services.Common.Contracts
{
	/// <summary>
	/// Interface IRequestReceiverConfiguration
	/// </summary>
	public interface IRequestReceiverConfiguration
	{
		public string GoogleDistanceGrpcChannelUrl { get; set; }
		public string ISSNCheckerGrpcChannelUrl { get; set; }
	}
}
