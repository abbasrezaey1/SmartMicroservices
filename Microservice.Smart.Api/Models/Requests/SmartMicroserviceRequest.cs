using System.Text.Json.Serialization;
using Microservice.Smart.Api.Enumerations;

namespace Microservice.Smart.Api.Models.Requests
{
    public class SmartMicroserviceRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SmartMicroserviceType Type { get; set; }

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SmartMicroserviceCategory Category { get; set; }
    }
}
