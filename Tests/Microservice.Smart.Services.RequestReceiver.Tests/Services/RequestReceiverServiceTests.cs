using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.ISSNChecker;
using Microservice.Smart.Services.RequestReceiver.Contracts;
using Microservice.Smart.Services.RequestReceiver.Services;
using NSubstitute;

namespace Microservice.Smart.Services.RequestReceiver.Tests.Services
{
	public class RequestReceiverServiceTests
	{
		[Theory]
		[AutoData]
		public async Task CheckISSNCode_ReturnsExpectedResult_WhenCalled(ISSNCodeInput request, ISSNCodeResult issnCodeResult)
		{
			// arrange
			var dependencies = InitializeDependencies();

			var expectedResult = new CodeResult()
			{
				Message = issnCodeResult.Message,
			};

			dependencies.iissnCheckerWrapper.CheckISSNCode(Arg.Is<CodeInput>(c => c.Code == request.Code))
				.Returns(expectedResult);

			// act 
			var actualResult = await dependencies.requestReceiverService.CheckISSNCode(request, null);

			// assert
			actualResult.Message.Should().BeEquivalentTo(issnCodeResult.Message);
		}

		[Theory]
		[AutoData]
		public async Task CheckISSNCode_ReturnsNullMessage_WhenThrows(ISSNCodeInput request)
		{
			// arrange
			var dependencies = InitializeDependencies();

			dependencies.iissnCheckerWrapper.CheckISSNCode(Arg.Is<CodeInput>(c => c.Code == request.Code))
				.Returns(null as CodeResult);

			// act 
			var actualResult = await dependencies.requestReceiverService.CheckISSNCode(request, null);

			// assert
			actualResult.Should().BeNull();
		}

		[Theory]
		[AutoData]
		public async Task GetDistance_ReturnsExpectedResult_WhenCalled(Cities cities, DistanceData distanceData)
		{
			// arrange
			var dependencies = InitializeDependencies();

			var expectedResult = new GoogleDistance.Protos.DistanceData()
			{
				Miles = distanceData.Miles
			};

			dependencies.googleDistanceWrapper.GetDistance(Arg.Is<GoogleDistance.Protos.Cities>(c => c.DestinationCity == cities.DestinationCity && c.OriginCity == cities.OriginCity))
				.Returns(expectedResult);

			// act 
			var actualResult = await dependencies.requestReceiverService.GetDistance(cities, null);

			// assert
			actualResult.Miles.Should().BeEquivalentTo(distanceData.Miles);
		}

		[Theory]
		[AutoData]
		public async Task GetDistance_ReturnsNull_WhenThrows(Cities cities, DistanceData distanceData)
		{
			// arrange
			var dependencies = InitializeDependencies();

			dependencies.googleDistanceWrapper.GetDistance(Arg.Is<GoogleDistance.Protos.Cities>(c => c.DestinationCity == cities.DestinationCity && c.OriginCity == cities.OriginCity))
				.Returns(null as GoogleDistance.Protos.DistanceData);

			// act 
			var actualResult = await dependencies.requestReceiverService.GetDistance(cities, null);

			// assert
			actualResult.Should().BeNull();
		}
		private (IGoogleDistanceWrapper googleDistanceWrapper, IISSNCheckerWrapper iissnCheckerWrapper, RequestReceiverService requestReceiverService) InitializeDependencies()
		{
			var googleDistanceWrapper = Substitute.For<IGoogleDistanceWrapper>();
			var iissnCheckerWrapper = Substitute.For<IISSNCheckerWrapper>();

			var distanceInfoService = new RequestReceiverService(googleDistanceWrapper, iissnCheckerWrapper);

			return (googleDistanceWrapper, iissnCheckerWrapper, distanceInfoService);
		}
	}
}
