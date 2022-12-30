using System.Diagnostics.CodeAnalysis;
using Grpc.Net.Client;
using Microservice.Smart.Api.Contracts;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.RequestReceiver;

namespace Microservice.Smart.Api.Services
{
	/// <summary>
	/// Class RequestReceiverWrapper
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class RequestReceiverWrapper : IRequestReceiverWrapper
	{
		private readonly ISmartApiConfiguration _smartApiConfiguration;

		public RequestReceiverWrapper(ISmartApiConfiguration smartApiConfiguration)
		{
			_smartApiConfiguration = smartApiConfiguration;
		}
		/// <inheritdoc />
		public async Task<ISSNCodeResult> CheckISSNCode(ISSNCodeInput issnCodeInput)
		{
			// connecting to request receiver microservice via gRPC
			var requestReceiverChannel = GrpcChannel.ForAddress(new Uri(_smartApiConfiguration.RequestReceiverGrpcChannelUrl));
			var requestReceiverClient = new RequestReceiver.RequestReceiverClient(requestReceiverChannel);

			return await requestReceiverClient.CheckISSNCodeAsync(issnCodeInput);
		}

		/// <inheritdoc />
		public async Task<DistanceData> GetDistance(Cities cities)
		{
			// connecting to request receiver microservice via gRPC
			var requestReceiverChannel = GrpcChannel.ForAddress(new Uri(_smartApiConfiguration.RequestReceiverGrpcChannelUrl));
			var requestReceiverClient = new RequestReceiver.RequestReceiverClient(requestReceiverChannel);

			return await requestReceiverClient.GetDistanceAsync(cities);
		}
	}
}
