using Grpc.Core;
using Microservice.Smart.Services.RequestReceiver;

namespace Microservice.Smart.Api.Contracts
{
	/// <summary>
	/// Interface IRequestReceiverWrapper
	/// </summary>
	public interface IRequestReceiverWrapper
	{
		/// <summary>
		/// Check ISSN code
		/// </summary>
		/// <param name="issnCodeInput">The issnCodeInput</param>
		/// <returns>ISSN code result</returns>
		Task<ISSNCodeResult> CheckISSNCode(ISSNCodeInput issnCodeInput);

		/// <summary>
		/// Get distance
		/// </summary>
		/// <param name="cities">The cities</param>
		/// <returns>Distance data</returns>
		Task<DistanceData> GetDistance(Cities cities);
	}
}
