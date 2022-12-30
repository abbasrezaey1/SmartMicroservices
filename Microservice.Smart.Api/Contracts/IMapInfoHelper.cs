using Microservice.Smart.Api.Enumerations;
using Microservice.Smart.Api.Models.Requests;
using Microservice.Smart.Api.Models.Responses;

namespace Microservice.Smart.Api.Contracts
{
    public interface SmartMicroserviceHelper
	{
		Task<MapInfoResponse> GetDistance(string originCity, string destinationCity);
		Task<ISSNCodeResponse> CheckISSNCode(string code);
		Task<GetSmartMicroserviceResponse> GetSmartMicroservices(SmartMicroserviceRequest microserviceRequest);

	}
}
