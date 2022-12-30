using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Smart.Services.Common.Contracts
{
	public interface IDapperWrapper
	{
		Task<List<T>> QueryAsync<T>(string sql, object model = null,
			System.Data.CommandType commandType = System.Data.CommandType.Text, int? commandTimeOut = null);
	}
}
