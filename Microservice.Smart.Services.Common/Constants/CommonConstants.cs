using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.Common.Constants
{
	[ExcludeFromCodeCoverage]
	public class CommonConstants
	{
		public const string AppSettingsJson = "appsettings.json";
		public const string SwaggerVersion = "v1";
		public const string SwaggerDocTitle = "Smart Microservice";
		public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
		public const string SwaggerDescription = "Smart microservice for map information.";
	}
}
