using System.Text.Json;
using AutoFixture.Xunit2;
using Microservice.Smart.Services.Common.Constants;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.GoogleMapInfo.Contracts;
using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;
using Microservice.Smart.Services.GoogleMapInfo.Services;
using Microservice.Smart.Services.GoogleMapInfo.Tests.Resources;
using NSubstitute;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

namespace Microservice.Smart.Services.GoogleMapInfo.Tests.Services
{
	public class GoogleDistanceServiceTests
	{
		[Theory]
		[AutoData]
		public async Task GetMapDistance_ReturnsExpected_WhenCalled(string googleApiKey, string googleApiUrl, string originCity, string destinationCity)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.googleApiConfiguration.GoogleApiKey.Returns(googleApiKey);
			dependencies.googleApiConfiguration.GoogleApiUrl.Returns(googleApiUrl);

			var expectedGoogleApiUrl = googleApiUrl + string.Format(GoogleApiConstants.GoogleApiUrlTemplate, originCity,
				destinationCity, googleApiKey);
			dependencies.httpClientWrapper.GetStringAsync(expectedGoogleApiUrl).Returns(GoogleApi.GoogleApi_Response_Success);

			var expectedResponse = JsonSerializer.Deserialize<GoogleDistanceData>(GoogleApi.GoogleApi_Response_Success);

			// act
			var actualResponse = await dependencies.googleDistanceService.GetMapDistance(originCity, destinationCity);

			// assert
			actualResponse.Should().BeEquivalentTo(expectedResponse);
		}

		[Theory]
		[AutoData]
		public async Task GetMapDistance_Throws_WhenCalled(string googleApiKey, string googleApiUrl, string originCity, string destinationCity, Exception exception)
		{
			// arrange
			var dependencies = InitializeDependencies();
			dependencies.googleApiConfiguration.GoogleApiKey.Returns(googleApiKey);
			dependencies.googleApiConfiguration.GoogleApiUrl.Returns(googleApiUrl);

			var expectedGoogleApiUrl = googleApiUrl + string.Format(GoogleApiConstants.GoogleApiUrlTemplate, originCity,
				destinationCity, googleApiKey);
			dependencies.httpClientWrapper.GetStringAsync(expectedGoogleApiUrl).Returns<string>(_ => throw exception);

			// act
			var func = async () => await dependencies.googleDistanceService.GetMapDistance(originCity, destinationCity);

			// assert
			await func.Should().ThrowAsync<Exception>().WithMessage(exception.Message);
		}

		private (IGoogleApiConfiguration googleApiConfiguration, IHttpClientFactoryWrapper httpClientFactoryWrapper, IHttpClientWrapper httpClientWrapper, IGoogleDistanceService googleDistanceService) InitializeDependencies()
		{
			var httpClientWrapper = Substitute.For<IHttpClientWrapper>();
			var httpClientFactoryWrapper = Substitute.For<IHttpClientFactoryWrapper>();

			httpClientFactoryWrapper.CreateClient(DependencyNameConstants.GoogleApiClientName).Returns(httpClientWrapper);

			var googleApiConfiguration = Substitute.For<IGoogleApiConfiguration>();


			var googleDistanceService = new GoogleDistanceService(googleApiConfiguration, httpClientFactoryWrapper);

			return (googleApiConfiguration, httpClientFactoryWrapper, httpClientWrapper, googleDistanceService);
		}
	}
}
