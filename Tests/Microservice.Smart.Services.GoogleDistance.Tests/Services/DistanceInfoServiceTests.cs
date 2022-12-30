using AutoFixture.Xunit2;
using NSubstitute;
using FluentAssertions;
using Microservice.Smart.Services.GoogleDistance.Protos;
using Microservice.Smart.Services.GoogleDistance.Services;
using Microservice.Smart.Services.GoogleMapInfo.Contracts;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;

namespace Microservice.Smart.Services.GoogleDistance.Tests.Services
{
	public class DistanceInfoServiceTests
	{
		[Theory]
		[AutoData]
		public async Task GetDistance_ReturnsExpected_WhenCalled(GoogleDistanceData expectedGoogleDistanceData, string originCity, string destinationCity)
		{
			// arrange
			var dependencies = InitializeDependencies();
			var expectedCities = new Cities()
			{
				DestinationCity = originCity,
				OriginCity = destinationCity
			};

			var expectedTotalMiles = "0";
			foreach (var distanceDataRow in expectedGoogleDistanceData.Rows)
			{
				foreach (var element in distanceDataRow.Elements)
				{
					expectedTotalMiles = element.Distance.Text;
				}
			}

			var expectedResult = new DistanceData()
			{
				Miles = expectedTotalMiles,
			};

			dependencies.googleDistanceService.GetMapDistance(expectedCities.OriginCity, expectedCities.DestinationCity)
				.Returns(expectedGoogleDistanceData);

			// act
			var actualResult = await dependencies.distanceInfoService.GetDistance(new Cities()
			{
				DestinationCity = originCity,
				OriginCity = destinationCity
			}, null);

			// assert
			actualResult.Should().BeEquivalentTo(expectedResult);
		}
		private (IGoogleDistanceService googleDistanceService, DistanceInfoService distanceInfoService) InitializeDependencies()
		{
			var googleDistanceService = Substitute.For<IGoogleDistanceService>();

			var distanceInfoService = new DistanceInfoService(googleDistanceService);

			return (googleDistanceService, distanceInfoService);
		}
	}
}
