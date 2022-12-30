using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;

namespace Microservice.Smart.Services.GoogleMapInfo.Tests.Models.Responses
{
	public class GoogleDistanceDataTests
	{
		[Theory, AutoData]
		public void GoogleDistanceData_ReturnsExpectedProperties_WhenCalled(GoogleDistanceData expectedGoogleDistanceData)
		{
			// arrange and act
			var actualGoogleDistanceData = new GoogleDistanceData()
			{
				Rows = expectedGoogleDistanceData.Rows,
				DestinationAddresses = expectedGoogleDistanceData.DestinationAddresses,
				OriginAddresses = expectedGoogleDistanceData.OriginAddresses,
				Status = expectedGoogleDistanceData.Status
			};

			// assert
			actualGoogleDistanceData.Should().BeEquivalentTo(expectedGoogleDistanceData);
		}
	}
}
