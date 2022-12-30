using System.Text.Json.Serialization;

namespace Microservice.Smart.Services.GoogleMapInfo.Models.Responses
{
	public class Distance
	{
		[JsonPropertyName("text")]
		public string Text { get; set; }
		
		[JsonPropertyName("value")]
		public int Value { get; set; }
	}
}
