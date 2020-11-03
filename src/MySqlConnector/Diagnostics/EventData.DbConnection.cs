using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlConnector.Diagnostics
{
	public class DbConnectionEventData : EventData
	{
		public DbConnectionEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}

		public DbConnection? DbConnection { get; set; } = null;
	}

	public class DbConnectionOpenAfterEventData : DbConnectionEventData
	{
		public DbConnectionOpenAfterEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}

	}

	public class DbConnectionOpenBeforeEventData : DbConnectionEventData
	{
		public DbConnectionOpenBeforeEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}

	}

	public class DbConnectionOpenErrorEventData : DbConnectionEventData, IErrorEventData
	{
		public DbConnectionOpenErrorEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}

		public Exception? Exception { get; set; } = null;
	}
}
