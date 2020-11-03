using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlConnector.Diagnostics
{
	public class CommandExecuterEventData : EventData
	{
		public CommandExecuterEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}
		public string? CommandText { get; set; } = null;

		public DbConnection? DbConnection { get; set; } = null;
	}

	public class CommandExecuterExecuteBeforeEventData : CommandExecuterEventData
	{
		public CommandExecuterExecuteBeforeEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}
	}

	public class CommandExecuterExecuteAfterEventData : CommandExecuterEventData
	{
		public CommandExecuterExecuteAfterEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}
	}

	public class CommandExecuterExecuteErrorEventData : CommandExecuterEventData, IErrorEventData
	{
		public CommandExecuterExecuteErrorEventData(Guid operationId, string operation) : base(operationId, operation)
		{

		}

		public Exception? Exception { get; set; } = null;
	}
}
