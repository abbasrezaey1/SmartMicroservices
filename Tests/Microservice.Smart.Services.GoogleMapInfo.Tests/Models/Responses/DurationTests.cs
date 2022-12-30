using AutoFixture.Xunit2;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;
using FluentAssertions;

namespace Microservice.Smart.Services.GoogleMapInfo.Tests.Models.Responses
{
	public class DurationTests
	{
		[Theory, AutoData]
		public void Duration_ReturnsExpectedProperties_WhenCalled(Duration expectedDuration)
		{
			// arrange and act
			var actualDuration = new Duration()
			{
				Text = expectedDuration.Text,
				Value = expectedDuration.Value
			};

			// assert
			actualDuration.Should().BeEquivalentTo(expectedDuration);
		}
	}
}
