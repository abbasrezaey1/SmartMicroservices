using System.Text.Json.Serialization;
using Microservice.Smart.Api.Models.DBO;

namespace Microservice.Smart.Api.Models.Responses
{
    public class GetSmartMicroserviceResponse
    {
        [JsonPropertyName("smartMicroservices")]
        public List<SmartMicroserviceResponse> SmartMicroservices { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Error { get; set; }
    }
}
