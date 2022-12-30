using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Api.Extensions;
using Microservice.Smart.Api.Models.DBO;
using Microservice.Smart.Api.Models.Responses;

namespace Microservice.Smart.Api.Tests.Extensions
{
	public class SmartMicroserviceDBOExtensionsTests
	{
		[Theory]
		[AutoData]
		public void ToMicroserviceResponse_ReturnsExpected_WhenCalled(List<SmartMicroserviceDBO> smartMicroserviceDBOs)
		{
			// arrange
			smartMicroserviceDBOs.RemoveRange(1,2);

			var expectedResponse = new List<SmartMicroserviceResponse>()
			{
				new()
				{
					Id = smartMicroserviceDBOs[0].Id,
					Name = smartMicroserviceDBOs[0].Name,
					Type = new TypeResponse()
					{
						Id = smartMicroserviceDBOs[0].TypeId,
						Title = smartMicroserviceDBOs[0].TypeTitle
					},
					Category = new CategoryResponse()
					{
						Id = smartMicroserviceDBOs[0].CategoryId,
						Title = smartMicroserviceDBOs[0].CategoryTitle
					}
				}
			};

			// act
			var actualResponse = smartMicroserviceDBOs.ToMicroserviceResponse();

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}
	}
}
