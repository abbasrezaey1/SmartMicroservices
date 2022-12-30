using Grpc.Net.Client;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.RequestReceiver.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.RequestReceiver.Services
{
	/// <summary>
	/// Class IISSNCheckerWrapper
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class ISSNCheckerWrapper : IISSNCheckerWrapper
	{
		private readonly IRequestReceiverConfiguration _requestReceiverConfiguration;

		public ISSNCheckerWrapper(IRequestReceiverConfiguration requestReceiverConfiguration)
		{
			_requestReceiverConfiguration = requestReceiverConfiguration;
		}

		/// <inheritdoc />
		public async Task<ISSNChecker.CodeResult> CheckISSNCode(ISSNChecker.CodeInput issnCodeInput)
		{

			// connecting to ISSN code checker microservice via gRPC
			var issnCheckerChannel = GrpcChannel.ForAddress(new Uri(_requestReceiverConfiguration.GoogleDistanceGrpcChannelUrl));
			var issnCheckerClient = new ISSNChecker.ISSNChecker.ISSNCheckerClient(issnCheckerChannel);

			return await issnCheckerClient.CheckAsync(issnCodeInput);
		}
	}
}
