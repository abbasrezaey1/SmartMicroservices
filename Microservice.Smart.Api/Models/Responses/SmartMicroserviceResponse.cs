using System.Text.Json.Serialization;

namespace Microservice.Smart.Api.Models.Responses
{
    public class SmartMicroserviceResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public TypeResponse Type { get; set; }

        [JsonPropertyName("category")]
        public CategoryResponse Category { get; set; }
    }
}
