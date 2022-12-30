using Microservice.Smart.Services.Common.Constants;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.Common.Models;
using Microservice.Smart.Services.Common.Wrappers;
using Microservice.Smart.Services.GoogleDistance.Services;
using Microservice.Smart.Services.GoogleMapInfo.Contracts;
using Microservice.Smart.Services.GoogleMapInfo.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile(CommonConstants.AppSettingsJson, optional: true, reloadOnChange: true).Build();
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// build configuration for google api service
IGoogleApiConfiguration googleApiConfiguration = new GoogleApiConfiguration()
{
	GoogleApiBaseUrl = configuration[GoogleApiConstants.GoogleApiBaseUrl],
	GoogleApiKey = configuration[GoogleApiConstants.GoogleApiKey],
	GoogleApiUrl = configuration[GoogleApiConstants.GoogleApiUrl],
	GoogleApiUrlTemplate = configuration[GoogleApiConstants.GoogleApiUrlTemplate]
};

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton(googleApiConfiguration);
builder.Services.AddSingleton<IGoogleDistanceService, GoogleDistanceService>();
builder.Services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
builder.Services.AddSingleton<IHttpClientFactoryWrapper, HttpClientFactoryWrapper>();
builder.Services.AddHttpClient(DependencyNameConstants.GoogleApiClientName, httpClient => httpClient.BaseAddress = new Uri(googleApiConfiguration.GoogleApiBaseUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DistanceInfoService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
