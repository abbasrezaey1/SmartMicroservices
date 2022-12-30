using AutoFixture.Xunit2;
using Microservice.Smart.Services.Common.Models;
using FluentAssertions;

namespace Microservice.Smart.Services.Common.Tests.Models
{
	public class SmartApiConfigurationTests
	{
		[Theory, AutoData]
		public void SmartApiConfiguration_ReturnsExpectedProperties_WhenCalled(SmartApiConfiguration expectedSmartApiConfiguration)
		{
			// arrange and act
			var actualSmartApiConfiguration = new SmartApiConfiguration()
			{
				RequestReceiverGrpcChannelUrl = expectedSmartApiConfiguration.RequestReceiverGrpcChannelUrl,
				SmartMicroserviceDBConnectionString = expectedSmartApiConfiguration.SmartMicroserviceDBConnectionString
			};

			// assert
			actualSmartApiConfiguration.Should().BeEquivalentTo(expectedSmartApiConfiguration);
		}
	}
}
