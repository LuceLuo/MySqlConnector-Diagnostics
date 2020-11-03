using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector.Core;

namespace MySqlConnector.Diagnostics
{
	public static class MySqlDiagnosticListenerExtensions
	{
		public const string MYSQL_DIAGNOSTIC_LISTENER = "MySqlDiagnosticListener";
		public static readonly DiagnosticListener Instance = new DiagnosticListener(MYSQL_DIAGNOSTIC_LISTENER);
		public const string MYSQL_PREFIX = "MySql.";

		#region Connection.Open

		public const string MYSQL_BEFORE_CONNECTION_OPEN = MYSQL_PREFIX + nameof(WriteConnectionOpenBefore);
		public const string MYSQL_AFTER_CONNECTION_OPEN = MYSQL_PREFIX + nameof(WriteConnectionOpenAfter);
		public const string MYSQL_ERROR_CONNECTION_OPEN = MYSQL_PREFIX + nameof(WriteConnectionOpenError);

		internal static Guid WriteConnectionOpenBefore(this DiagnosticListener listener, DbConnection dbConnection)
		{
			if (!listener.IsEnabled(MYSQL_BEFORE_CONNECTION_OPEN))
				return Guid.Empty;
			var operationId = Guid.NewGuid();
			listener.Write(MYSQL_BEFORE_CONNECTION_OPEN, new DbConnectionOpenBeforeEventData(operationId, MYSQL_PREFIX + "Connection.Open")
			{
				DbConnection = dbConnection
			});
			return operationId;
		}

		internal static void WriteConnectionOpenAfter(this DiagnosticListener listener, Guid operationId, DbConnection dbConnection)
		{
			if (listener.IsEnabled(MYSQL_AFTER_CONNECTION_OPEN))
				listener.Write(MYSQL_AFTER_CONNECTION_OPEN, new DbConnectionOpenAfterEventData(operationId, MYSQL_PREFIX + "Connection.Open")
				{
					DbConnection = dbConnection
				});
		}

		internal static void WriteConnectionOpenError(this DiagnosticListener listener, Guid operationId, DbConnection dbConnection, Exception ex)
		{
			if (listener.IsEnabled(MYSQL_ERROR_CONNECTION_OPEN))
				listener.Write(MYSQL_ERROR_CONNECTION_OPEN, new DbConnectionOpenErrorEventData(operationId, MYSQL_PREFIX + "Connection.Open")
				{
					DbConnection = dbConnection,
					Exception = ex
				});
		}


		#endregion

		#region Connection.Open

		public const string MYSQL_BEFORE_COMMAND_EXECUTE = MYSQL_PREFIX + nameof(WriteCommandExecuteBefore);
		public const string MYSQL_AFTER_COMMAND_EXECUTE = MYSQL_PREFIX + nameof(WriteCommandExecuteAfter);
		public const string MYSQL_ERROR_COMMAND_EXECUTE = MYSQL_PREFIX + nameof(WriteCommandExecuteError);

		internal static Guid WriteCommandExecuteBefore(this DiagnosticListener listener, IMySqlCommand command)
		{
			if (!listener.IsEnabled(MYSQL_BEFORE_COMMAND_EXECUTE))
				return Guid.Empty;
			var operationId = Guid.NewGuid();
			listener.Write(MYSQL_BEFORE_COMMAND_EXECUTE, new CommandExecuterExecuteBeforeEventData(operationId, MYSQL_PREFIX + "Command.Execute")
			{
				DbConnection = command.Connection,
				CommandText = command.CommandText
			});
			return operationId;
		}

		internal static void WriteCommandExecuteAfter(this DiagnosticListener listener, Guid operationId, IMySqlCommand command)
		{
			if (listener.IsEnabled(MYSQL_AFTER_COMMAND_EXECUTE))
				listener.Write(MYSQL_AFTER_COMMAND_EXECUTE, new CommandExecuterExecuteAfterEventData(operationId, MYSQL_PREFIX + "Command.Execute")
				{
					DbConnection = command.Connection,
					CommandText = command.CommandText
				});
		}

		internal static void WriteCommandExecuteError(this DiagnosticListener listener, Guid operationId, IMySqlCommand command, Exception ex)
		{
			if (listener.IsEnabled(MYSQL_ERROR_COMMAND_EXECUTE))
				listener.Write(MYSQL_ERROR_COMMAND_EXECUTE, new CommandExecuterExecuteErrorEventData(operationId, MYSQL_PREFIX + "Command.Execute")
				{
					DbConnection = command.Connection,
					CommandText = command.CommandText,
					Exception = ex
				});
		}


		#endregion
	}
}
