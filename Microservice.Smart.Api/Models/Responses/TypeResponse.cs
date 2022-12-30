using System.Text.Json.Serialization;

namespace Microservice.Smart.Api.Models.Responses
{
    public class TypeResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
