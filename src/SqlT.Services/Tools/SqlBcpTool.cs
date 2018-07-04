//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Text;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    public static class SqlBcpTool
    {
        static string enquote(Option<FilePath> path)
            => metacore.enquote(path.MapValueOrDefault(p => p.Value, String.Empty));

        const int DefaultBatchSize = 25000;

        static string enquote(Option<SqlTableQuery> query)
            => metacore.enquote(query.MapValueOrDefault(s => s.Script.ScriptText, String.Empty));

        public static string FormatToolArguments(this SqlBcpCommand command)
        {
            var sb = new StringBuilder();
            var targetTable = command.TargetTable.ValueOrDefault(SqlTableName.Empty).TrimServer();
            var sourceTable = command.SourceTable.ValueOrDefault(SqlTableName.Empty).TrimServer();
            switch (command.Action)
            {

                case BcpToolAction.Export:
                    if (command.SourceQuery.MapValueOrDefault(q => q.IsFiltered))
                        sb.Append($"{enquote(command.SourceQuery)} queryout {enquote(command.DataFile)}");
                    else
                        sb.Append($"{sourceTable} out {enquote(command.DataFile)}");
                    break;

                case BcpToolAction.Import:
                    var batchSize = command.BatchSize.ValueOrDefault(DefaultBatchSize);
                    sb.Append($"{targetTable} in {enquote(command.DataFile)} -f {enquote(command.FormatFile)} -b {batchSize}");
                    break;

                case BcpToolAction.Format:
                    sb.Append($"{sourceTable} format nul -n -f {enquote(command.FormatFile)}");
                    break;
            }

            sb.Append($" -N -S {command.ServerName}");

            command.Credentials.OnSome(c => sb.Append($" -U {c.UserName} -P {c.Password}"))
                    .OnNone(() => sb.Append(" -T"));

            var args = sb.ToString();
            return args;
        }

        public static FileWriteResult SaveToolCommand(this SqlBcpCommand command, FilePath dst)
            => dst.Write($"bcp.exe {command.FormatToolArguments()}");
    }
}
