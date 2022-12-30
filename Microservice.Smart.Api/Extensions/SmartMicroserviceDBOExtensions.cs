using Microservice.Smart.Api.Models.DBO;
using Microservice.Smart.Api.Models.Responses;

namespace Microservice.Smart.Api.Extensions
{
	/// <summary>
	/// Class SmartMicroserviceDBOExtensions
	/// </summary>
	public static class SmartMicroserviceDBOExtensions
	{
		/// <summary>
		/// Convert a list of SmartMicroserviceDBO to a list of SmartMicroserviceResponse
		/// </summary>
		/// <param name="smartMicroserviceDBOs">List of smartMicroserviceDBOs</param>
		/// <returns>List of SmartMicroserviceResponse</returns>
		public static List<SmartMicroserviceResponse> ToMicroserviceResponse(this List<SmartMicroserviceDBO> smartMicroserviceDBOs)
		{
			return smartMicroserviceDBOs.Select(s => new SmartMicroserviceResponse()
			{
				Id = s.Id,
				Name = s.Name,
				Type = new TypeResponse()
				{
					Id = s.TypeId,
					Title = s.TypeTitle
				},
				Category = new CategoryResponse()
				{
					Id = s.CategoryId,
					Title = s.CategoryTitle
				}
			}).ToList();
		}
	}
}
