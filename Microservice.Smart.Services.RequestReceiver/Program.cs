using Microservice.Smart.Services.Common.Constants;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.Common.Models;
using Microservice.Smart.Services.RequestReceiver.Contracts;
using Microservice.Smart.Services.RequestReceiver.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile(CommonConstants.AppSettingsJson, optional: true, reloadOnChange: true).Build();
// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// build configuration for request receiver service
IRequestReceiverConfiguration requestReceiverConfiguration = new RequestReceiverConfiguration()
{
	GoogleDistanceGrpcChannelUrl = configuration[RequestReceiverConstants.GoogleDistanceGrpcChannelUrlTitle],
	ISSNCheckerGrpcChannelUrl = configuration[RequestReceiverConstants.ISSNCheckerGrpcChannelUrlTitle]
};

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton(requestReceiverConfiguration);
builder.Services.AddSingleton<IGoogleDistanceWrapper, GoogleDistanceWrapper>();
builder.Services.AddSingleton<IISSNCheckerWrapper, ISSNCheckerWrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<RequestReceiverService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
