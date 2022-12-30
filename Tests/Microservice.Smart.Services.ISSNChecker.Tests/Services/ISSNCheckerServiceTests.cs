using Microservice.Smart.Services.ISSNChecker.Constants;
using FluentAssertions;
using Microservice.Smart.Services.ISSNChecker.Services;

namespace Microservice.Smart.Services.ISSNChecker.Tests.Services
{
	public class ISSNCheckerServiceTests
	{
		[Theory]
		[InlineData("1144-875X", ErrorsConstants.ValidResult)]
		[InlineData("1144-875x", ErrorsConstants.ValidResult)]
		[InlineData("1144-871X", ErrorsConstants.InValidError)]
		[InlineData("11448875X", ErrorsConstants.InValidError)]
		[InlineData("1144-87zx", ErrorsConstants.InValidError)]
		[InlineData("114487zx", ErrorsConstants.CodeIsNotValidError)]
		[InlineData("", ErrorsConstants.CodeShouldNotBeEmptyError)]
		public async Task Check_ReturnsExpected_WhenCalled(string expectedCode, string expectedResponse)
		{
			// arrange
			var issnCheckerService = new ISSNCheckerService();

			// act
			var actualResult = await issnCheckerService.Check(new CodeInput()
			{
				Code = expectedCode
			}, null);

			// assert
			actualResult.Message.Should().BeEquivalentTo(expectedResponse);
		}
	}
}
