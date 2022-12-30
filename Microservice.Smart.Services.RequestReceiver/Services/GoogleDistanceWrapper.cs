using System.Diagnostics.CodeAnalysis;
using Grpc.Net.Client;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.GoogleDistance.Protos;
using Microservice.Smart.Services.RequestReceiver.Contracts;

namespace Microservice.Smart.Services.RequestReceiver.Services
{
	/// <summary>
	/// Class GoogleDistanceWrapper
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class GoogleDistanceWrapper : IGoogleDistanceWrapper
	{
		private readonly IRequestReceiverConfiguration _requestReceiverConfiguration;

		/// <summary>
		/// Create new instance of GoogleDistanceWrapper
		/// </summary>
		/// <param name="requestReceiverConfiguration">The requestReceiverConfiguration</param>
		public GoogleDistanceWrapper(IRequestReceiverConfiguration requestReceiverConfiguration)
		{
			_requestReceiverConfiguration = requestReceiverConfiguration;
		}

		/// <inheritdoc />
		public async Task<GoogleDistance.Protos.DistanceData> GetDistance(GoogleDistance.Protos.Cities cities)
		{
			// connecting to google distance microservice via gRPC
			var googleDistanceChannel = GrpcChannel.ForAddress(new Uri(_requestReceiverConfiguration.GoogleDistanceGrpcChannelUrl));
			var googleDistanceClient = new DistanceInfo.DistanceInfoClient(googleDistanceChannel);

			return await googleDistanceClient.GetDistanceAsync(cities);
		}
	}
}
