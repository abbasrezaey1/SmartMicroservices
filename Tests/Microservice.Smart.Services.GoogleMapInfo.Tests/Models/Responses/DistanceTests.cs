using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;

namespace Microservice.Smart.Services.GoogleMapInfo.Tests.Models.Responses
{
	public class DistanceTests
	{
		[Theory, AutoData]
		public void Distance_ReturnsExpectedProperties_WhenCalled(Distance expectedDistance)
		{
			// arrange and act
			var actualDistance = new Distance()
			{
				Text = expectedDistance.Text,
				Value = expectedDistance.Value
			};

			// assert
			actualDistance.Should().BeEquivalentTo(expectedDistance);
		}
	}
}
