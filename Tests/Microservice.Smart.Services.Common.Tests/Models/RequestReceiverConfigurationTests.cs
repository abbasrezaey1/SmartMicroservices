using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.Common.Models;

namespace Microservice.Smart.Services.Common.Tests.Models
{
	public class RequestReceiverConfigurationTests
	{
		[Theory, AutoData]
		public void RequestReceiverConfiguration_ReturnsExpectedProperties_WhenCalled(RequestReceiverConfiguration expectedRequestReceiverConfiguration)
		{
			// arrange and act
			var actualRequestReceiverConfiguration = new RequestReceiverConfiguration()
			{
				GoogleDistanceGrpcChannelUrl = expectedRequestReceiverConfiguration.GoogleDistanceGrpcChannelUrl,
				ISSNCheckerGrpcChannelUrl = expectedRequestReceiverConfiguration.ISSNCheckerGrpcChannelUrl
			};

			// assert
			actualRequestReceiverConfiguration.Should().BeEquivalentTo(expectedRequestReceiverConfiguration);
		}
	}
}
