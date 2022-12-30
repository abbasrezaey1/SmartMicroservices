namespace Microservice.Smart.Services.RequestReceiver.Contracts
{
	/// <summary>
	/// Interface IISSNCheckerWrapper
	/// </summary>
	public interface IISSNCheckerWrapper
	{
		/// <summary>
		/// Check ISSN code
		/// </summary>
		/// <param name="issnCodeInput">The issn code</param>
		/// <returns>ISSN code result</returns>
		Task<ISSNChecker.CodeResult> CheckISSNCode(ISSNChecker.CodeInput issnCodeInput);
	}
}
