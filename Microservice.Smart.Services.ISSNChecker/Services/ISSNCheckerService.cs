using Grpc.Core;
using Microservice.Smart.Services.ISSNChecker.Extensions;

namespace Microservice.Smart.Services.ISSNChecker.Services
{
	/// <summary>
	/// Class ISSNCheckerService
	/// </summary>
	public class ISSNCheckerService : ISSNChecker.ISSNCheckerBase
	{
		public override Task<CodeResult> Check(CodeInput codeInput, ServerCallContext context)
		{
			return Task.FromResult(new CodeResult()
			{
				Message = codeInput.Code.ValidateISSNCode()
			});
		}
	}
}