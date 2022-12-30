using Microservice.Smart.Services.Common.Contracts;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Microservice.Smart.Services.Common.Wrappers
{
	/// <summary>
	/// Class DapperWrapper
	/// </summary>
	public class DapperWrapper : IDapperWrapper
	{
		private readonly ISmartApiConfiguration _smartApiConfiguration;

		public DapperWrapper(ISmartApiConfiguration smartApiConfiguration)
		{
			_smartApiConfiguration = smartApiConfiguration;
		}

		/// <summary>
		/// QueryAsync method
		/// </summary>
		/// <typeparam name="T">Could be DB types</typeparam>
		/// <param name="sql">The sql statement</param>
		/// <param name="model">The search context</param>
		/// <param name="commandType">The commandType.</param>
		/// <param name="commandTimeOut">The commandTimeOut</param>
		/// <returns></returns>
		public async Task<List<T>> QueryAsync<T>(string sql, object model = null, CommandType commandType = CommandType.Text,
			int? commandTimeOut = null)
		{
			await using var sqlConnection = new SqlConnection(_smartApiConfiguration.SmartMicroserviceDBConnectionString);
 			await sqlConnection.OpenAsync();
      var result =
	      (await sqlConnection.QueryAsync<T>(sql, model, commandType: commandType, commandTimeout: commandTimeOut)).ToList();
      await sqlConnection.CloseAsync();
			return result;
		}
	}
}
