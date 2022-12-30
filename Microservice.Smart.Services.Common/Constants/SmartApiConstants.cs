using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.Common.Constants
{
	/// <summary>
	/// Class SmartApiConstants
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class SmartApiConstants
	{
		public const string RequestReceiverGrpcChannelUrlTitle = "gRPCChannels:RequestReceiverGrpcChannelUrl";
		public const string SmartMicroserviceDBConnectionString = "ConnectionStrings:SmartMicroserviceDB";
	}
}
