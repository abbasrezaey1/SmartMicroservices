namespace Microservice.Smart.Services.RequestReceiver.Contracts
{
	/// <summary>
	/// Interface IGoogleDistanceWrapper
	/// </summary>
	public interface IGoogleDistanceWrapper
	{
		/// <summary>
		/// Get distance data
		/// </summary>
		/// <param name="cities">The cities</param>
		/// <returns>Distance data</returns>
		Task<GoogleDistance.Protos.DistanceData> GetDistance(GoogleDistance.Protos.Cities cities);
	}
}
