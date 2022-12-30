using Microservice.Smart.Services.GoogleMapInfo.Models.Responses;

namespace Microservice.Smart.Services.GoogleMapInfo.Contracts
{
	public interface IGoogleDistanceService
	{
		Task<GoogleDistanceData> GetMapDistance(string originCity, string destinationCity);
	}
}
