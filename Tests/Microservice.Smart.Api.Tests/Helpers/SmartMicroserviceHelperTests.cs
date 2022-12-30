using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using Microservice.Smart.Api.Contracts;
using Microservice.Smart.Api.Models.Responses;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.RequestReceiver;
using SmartMicroserviceHelper = Microservice.Smart.Api.Contracts.SmartMicroserviceHelper;

namespace Microservice.Smart.Api.Tests.Helpers
{
	public class SmartMicroserviceHelperTests
	{
		[Theory]
		[AutoData]
		public async Task GetMapDistance_ReturnsExpected_WhenCalled(string originCity, string destinationCity, DistanceData expectedGoogleDistanceData)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.requestReceiverWrapper.GetDistance(Arg.Is<Cities>(c => c.OriginCity == originCity && c.DestinationCity == destinationCity))
				.Returns(expectedGoogleDistanceData);

			var expectedResponse = new MapInfoResponse()
			{
				Miles = expectedGoogleDistanceData.Miles,
				Errors = null
			};
			// act
			var actualResponse = await dependencies.mapInfoHelper.GetDistance(originCity, destinationCity);

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}

		[Theory]
		[AutoData]
		public async Task GetMapDistance_ReturnsExpectedError_WhenCalled(string originCity, string destinationCity, Exception exception)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.requestReceiverWrapper.GetDistance(Arg.Is<Cities>(c => c.OriginCity == originCity && c.DestinationCity == destinationCity))
				.Returns<DistanceData>(_ => throw exception);

			var expectedResponse = new MapInfoResponse()
			{
				Miles = null,
				Errors = new List<string>()
				{
					exception.Message,
				}
			};
			// act
			var actualResponse = await dependencies.mapInfoHelper.GetDistance(originCity, destinationCity);

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}

		[Theory]
		[AutoData]
		public async Task CheckISSNCode_ReturnsExpected_WhenCalled(string code, ISSNCodeResult issnCodeResult)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.requestReceiverWrapper.CheckISSNCode(Arg.Is<ISSNCodeInput>(c => c.Code == code))
				.Returns(issnCodeResult);

			var expectedResponse = new ISSNCodeResponse()
			{
				Message = issnCodeResult.Message,
				Errors = null
			};
			// act
			var actualResponse = await dependencies.mapInfoHelper.CheckISSNCode(code);

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}

		[Theory]
		[AutoData]
		public async Task CheckISSNCode_ReturnsExpectedError_WhenCalled(string code, Exception exception)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.requestReceiverWrapper.CheckISSNCode(Arg.Is<ISSNCodeInput>(c => c.Code == code))
				.Returns<ISSNCodeResult>(_ => throw exception);

			var expectedResponse = new ISSNCodeResponse()
			{
				Message = null,
				Errors = new List<string>()
				{
					exception.Message
				}
			};
			// act
			var actualResponse = await dependencies.mapInfoHelper.CheckISSNCode(code);

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}
		private (IRequestReceiverWrapper requestReceiverWrapper, SmartMicroserviceHelper mapInfoHelper) InitializeDependencies()
		{
			var requestReceiverWrapper = Substitute.For<IRequestReceiverWrapper>();
			var dapperWrapper = Substitute.For<IDapperWrapper>();

			var mapInfoHelper = new Api.Helpers.SmartMicroserviceHelper(requestReceiverWrapper, dapperWrapper);

			return (requestReceiverWrapper, mapInfoHelper);
		}
	}
}
