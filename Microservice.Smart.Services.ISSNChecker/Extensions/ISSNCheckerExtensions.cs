using Microservice.Smart.Services.ISSNChecker.Constants;
using System.Text.RegularExpressions;

namespace Microservice.Smart.Services.ISSNChecker.Extensions
{
	/// <summary>
	/// Class ISSNCheckerExtensions
	/// </summary>
	public static class ISSNCheckerExtensions
	{
		/// <summary>
		/// An extension method to validate ISSN code
		/// </summary>
		/// <param name="code">The ISSN code</param>
		/// <returns>A message shows whether code is valid or not.</returns>
		public static string ValidateISSNCode(this string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				return ErrorsConstants.CodeShouldNotBeEmptyError;
			}

			if (code.Length != 9)
			{
				return ErrorsConstants.CodeIsNotValidError;
			}

			var checksum = 0;
			var multi = 8;
			foreach (var c in code.Replace("-", string.Empty))
			{
				int number;
				if (string.Equals(c.ToString(), "x", StringComparison.InvariantCultureIgnoreCase))
				{
					number = 10;
				}
				else
				{
					if (!int.TryParse(c.ToString(), out number))
					{
						return ErrorsConstants.InValidError;
					}
				}

				checksum += number * multi;
				multi--;
			}

			if (checksum % 11 != 0)
			{
				return ErrorsConstants.InValidError;
			}

			var regex = new Regex(CommonConstants.ISSNPattern);
			return regex.IsMatch(code) ? ErrorsConstants.ValidResult : ErrorsConstants.InValidError;
		}
	}
}
