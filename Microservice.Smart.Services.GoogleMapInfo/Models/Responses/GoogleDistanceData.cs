using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Microservice.Smart.Services.GoogleMapInfo.Models.Responses
{
	public class GoogleDistanceData
	{
		[JsonPropertyName("destination_addresses")]
		public string[] DestinationAddresses { get; set; }
		[JsonPropertyName("origin_addresses")]
		public string[] OriginAddresses { get; set; }
		[JsonPropertyName("rows")]
		public Row[] Rows { get; set; }
		[JsonPropertyName("status")]
		public string Status { get; set; }
	}
}
