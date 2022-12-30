using System.Diagnostics.CodeAnalysis;

namespace Microservice.Smart.Services.ISSNChecker.Constants
{
	/// <summary>
	/// Class CommonConstants
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class CommonConstants
	{
		public const string ISSNPattern = @"^\d{4}-\d{3}[\dxX]{1}$";
	}
}
