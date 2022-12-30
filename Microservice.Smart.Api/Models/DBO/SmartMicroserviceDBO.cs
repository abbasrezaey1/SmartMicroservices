using System.Text.Json.Serialization;

namespace Microservice.Smart.Api.Models.DBO
{
    public class SmartMicroserviceDBO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TypeId { get; set; }

        public string TypeTitle { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryTitle { get; set; }
    }
}
