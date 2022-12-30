using Grpc.Core;
using Microservice.Smart.Services.GoogleDistance.Protos;
using Microservice.Smart.Services.GoogleMapInfo.Contracts;

namespace Microservice.Smart.Services.GoogleDistance.Services
{
	/// <summary>
	/// Class DistanceInfoService to add gRPC.
	/// </summary>
	public class DistanceInfoService : DistanceInfo.DistanceInfoBase
	{
		private readonly IGoogleDistanceService _googleDistanceService;

		public DistanceInfoService(IGoogleDistanceService googleDistanceService)
		{
			_googleDistanceService = googleDistanceService;
		}

		/// <summary>
		/// Get distance method that is called by gRPC consumer.
		/// </summary>
		/// <param name="cities">The cities</param>
		/// <param name="context">The context</param>
		/// <returns></returns>
		public override async Task<DistanceData> GetDistance(Cities cities, ServerCallContext context)
		{
			var totalMiles = "0";

			// calling google api service to get distance
			var distanceData = await _googleDistanceService.GetMapDistance(cities.OriginCity, cities.DestinationCity);

			// get total miles 
			foreach (var distanceDataRow in distanceData.Rows)
			{
				foreach (var element in distanceDataRow.Elements)
				{
					totalMiles = element.Distance.Text;
				}
			}

			return new DistanceData { Miles = totalMiles };
		}
	}
}
