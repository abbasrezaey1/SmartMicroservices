using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.Common.Models;

namespace Microservice.Smart.Services.Common.Tests.Models
{
	public class GoogleApiConfigurationTests
	{
		[Theory, AutoData]
		public void GoogleApiConfiguration_ReturnsExpectedProperties_WhenCalled(GoogleApiConfiguration expectedGoogleApiConfiguration)
		{
			// arrange and act
			var actualGoogleApiConfiguration = new GoogleApiConfiguration()
			{
				GoogleApiUrl = expectedGoogleApiConfiguration.GoogleApiUrl,
				GoogleApiBaseUrl = expectedGoogleApiConfiguration.GoogleApiBaseUrl,
				GoogleApiKey = expectedGoogleApiConfiguration.GoogleApiKey,
				GoogleApiUrlTemplate = expectedGoogleApiConfiguration.GoogleApiUrlTemplate
			};

			// assert
			actualGoogleApiConfiguration.Should().BeEquivalentTo(expectedGoogleApiConfiguration);
		}
	}
}
