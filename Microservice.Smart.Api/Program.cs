using System.Diagnostics.CodeAnalysis;
using Microservice.Smart.Api.Contracts;
using Microservice.Smart.Api.Helpers;
using Microservice.Smart.Api.Services;
using Microservice.Smart.Services.Common.Constants;
using Microservice.Smart.Services.Common.Contracts;
using Microservice.Smart.Services.Common.Models;
using Microservice.Smart.Services.Common.Wrappers;
using Microsoft.OpenApi.Models;
using SmartMicroserviceHelper = Microservice.Smart.Api.Contracts.SmartMicroserviceHelper;

namespace Microservice.Smart.Api
{
	/// <summary>
	/// Class Program.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class Program
	{
		/// <summary>
		/// The entry point.
		/// </summary>
		/// <param name="args">The args</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var configuration = new ConfigurationBuilder().AddJsonFile(CommonConstants.AppSettingsJson, optional: true, reloadOnChange: true).Build();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			// Inject swagger
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(CommonConstants.SwaggerVersion, new OpenApiInfo
				{
					Title = CommonConstants.SwaggerDocTitle,
					Version = CommonConstants.SwaggerVersion
				});
			});

			// build configuration for smart api service
			ISmartApiConfiguration smartApiConfiguration = new SmartApiConfiguration()
			{
				RequestReceiverGrpcChannelUrl = configuration[SmartApiConstants.RequestReceiverGrpcChannelUrlTitle],
				SmartMicroserviceDBConnectionString = configuration[SmartApiConstants.SmartMicroserviceDBConnectionString]
			};

			// add gRPC
			builder.Services.AddGrpc();

			// add services to DI
			builder.Services.AddSingleton<SmartMicroserviceHelper, Helpers.SmartMicroserviceHelper>();
			builder.Services.AddSingleton<IRequestReceiverWrapper, RequestReceiverWrapper>();
			builder.Services.AddSingleton<IDapperWrapper, DapperWrapper>();
			builder.Services.AddSingleton(smartApiConfiguration);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint(CommonConstants.SwaggerEndpoint,
						CommonConstants.SwaggerDescription);
				});
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();

		}
	}
}