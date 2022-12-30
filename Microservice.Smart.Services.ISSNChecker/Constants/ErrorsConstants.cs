using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.ISSNChecker.Constants
{
	/// <summary>
	/// Class ErrorsConstants
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class ErrorsConstants
	{
		public const string CodeShouldNotBeEmptyError = "ISSN code can not be empty.";
		public const string CodeIsNotValidError = "ISSN code is not valid.";
		public const string InValidError = "Invalid.";
		public const string ValidResult = "Valid.";
	}
}
