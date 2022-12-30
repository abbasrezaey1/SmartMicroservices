using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microservice.Smart.Api.Contracts;
using Microservice.Smart.Api.Enumerations;
using Microservice.Smart.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Smart.Api.Controllers
{
    /// <summary>
    /// The MapInfo Controller
    /// </summary>
    [Route("[controller]/[action]")]
	[ApiController]
	[ExcludeFromCodeCoverage]
	public class SmartMicroserviceController : Controller
	{
		private readonly SmartMicroserviceHelper _mapInfoHelper;

		/// <summary>
		/// Create a new instance of MapInfoController
		/// </summary>
		/// <param name="mapInfoHelper">The map info helper</param>
		public SmartMicroserviceController(SmartMicroserviceHelper mapInfoHelper)
		{
			_mapInfoHelper = mapInfoHelper;
		}

		/// <summary>
		/// Get distance between two cities.
		/// </summary>
		/// <param name="originCity">The originCity</param>
		/// <param name="destinationCity">The destinationCity</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetDistance(string originCity, string destinationCity)
		{
			// using controller helper class to get the distance from google api
			return Ok(await _mapInfoHelper.GetDistance(originCity, destinationCity));
		}

		/// <summary>
		/// Check ISSN code.
		/// </summary>
		/// <param name="code">The issn code</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> CheckISSNCode(string code)
		{
			// using controller helper class to check issn code
			return Ok(await _mapInfoHelper.CheckISSNCode(code));
		}

		/// <summary>
		/// Get list of microservices.
		/// </summary>
		/// <param name="smartMicroserviceRequest">The smart microservice request</param>
		[HttpGet]
		public async Task<IActionResult> GetSmartMicroservices([FromQuery] SmartMicroserviceRequest smartMicroserviceRequest)
		{
			// get smart microservices data from DB
			return Ok(await _mapInfoHelper.GetSmartMicroservices(smartMicroserviceRequest));
		}
	}
}
