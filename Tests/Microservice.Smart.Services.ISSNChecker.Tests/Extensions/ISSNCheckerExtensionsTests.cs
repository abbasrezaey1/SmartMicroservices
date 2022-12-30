using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microservice.Smart.Services.ISSNChecker.Constants;
using Microservice.Smart.Services.ISSNChecker.Extensions;

namespace Microservice.Smart.Services.ISSNChecker.Tests.Extensions
{
	public class ISSNCheckerExtensionsTests
	{
		[Theory]
		[InlineData("1144-875X", ErrorsConstants.ValidResult)]
		[InlineData("1144-875x", ErrorsConstants.ValidResult)]
		[InlineData("1144-871X", ErrorsConstants.InValidError)]
		[InlineData("11448875X", ErrorsConstants.InValidError)]
		[InlineData("1144-87zx", ErrorsConstants.InValidError)]
		[InlineData("114487zx", ErrorsConstants.CodeIsNotValidError)]
		[InlineData("", ErrorsConstants.CodeShouldNotBeEmptyError)]
		[InlineData(null, ErrorsConstants.CodeShouldNotBeEmptyError)]
		public void ValidateISSNCode_ReturnsExpected_WhenCalled(string expectedCode, string expectedResponse)
		{
			// act
			var actualResult = expectedCode.ValidateISSNCode();

			// assert
			actualResult.Should().BeEquivalentTo(expectedResponse);
		}
	}
}
