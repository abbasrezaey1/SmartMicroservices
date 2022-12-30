using AutoFixture.Xunit2;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;
using FluentAssertions;

namespace Microservice.Smart.Services.GoogleMapInfo.Tests.Models.Responses
{
	public class RowTests
	{
		[Theory, AutoData]
		public void Row_ReturnsExpectedProperties_WhenCalled(Row expectedRow)
		{
			// arrange and act
			var actualRow = new Row()
			{
				Elements = expectedRow.Elements
			};

			// assert
			actualRow.Should().BeEquivalentTo(expectedRow);
		}
	}
}
