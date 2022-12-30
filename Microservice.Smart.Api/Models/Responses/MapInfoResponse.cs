using Microservice.Smart.Services.RequestReceiver;

namespace Microservice.Smart.Api.Models.Responses
{
    /// <summary>
    /// Class MapInfoResponse
    /// </summary>
    public class MapInfoResponse
    {
        public string Miles { get; set; }
        public List<string> Errors { get; set; }
    }
}
