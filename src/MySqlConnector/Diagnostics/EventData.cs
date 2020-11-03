using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlConnector.Diagnostics
{
	public class EventData
	{
		public EventData(Guid operationId, string operation)
		{
			OperationId = operationId;
			Operation = operation;
		}
		public Guid OperationId { get; }

		public string Operation { get; }
	}
}
