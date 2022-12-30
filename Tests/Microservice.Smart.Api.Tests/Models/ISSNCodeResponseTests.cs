using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Api.Models.Responses;

namespace Microservice.Smart.Api.Tests.Models
{
    public class ISSNCodeResponseTests
	{
		[Theory, AutoData]
		public void ISSNCodeResponse_ReturnsExpectedProperties_WhenCalled(ISSNCodeResponse expectedISSNCodeResponse)
		{
			// arrange and act
			var actualISSNCodeResponse = new ISSNCodeResponse()
			{
				Errors = expectedISSNCodeResponse.Errors,
				Message = expectedISSNCodeResponse.Message
			};

			// assert
			actualISSNCodeResponse.Should().BeEquivalentTo(expectedISSNCodeResponse);
		}
	}
}
