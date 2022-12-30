using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Microservice.Smart.Services.GoogleMapInfo.Models.Responses
{
	public class Row
	{
		[JsonPropertyName("elements")]
		public Element[] Elements { get; set; }
	}
}
