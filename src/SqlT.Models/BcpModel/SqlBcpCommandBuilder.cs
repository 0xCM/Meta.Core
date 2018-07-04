//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Models;
    using SqlT.Core;

    using static metacore;
    

    public class SqlBcpCommandBuilder : CommandBuilder<SqlBcpCommand>
    {
        public SqlBcpCommandBuilder(IApplicationContext C)
            : base(C)
        {

        }

        public override IEnumerable<ConstructedCommand<SqlBcpCommand>>
            BuildCommands(RelativePath OutputLocation, params (string ParamName, object ParamValue)[] parms)
            => stream<ConstructedCommand<SqlBcpCommand>>();

        public SqlBcpCommand export(
            SqlTableQuery SourceQuery,  
            FilePath DataFile, 
            SqlUserCredentials Credentials = null)
        {
            var command = new SqlBcpCommand(
                BcpToolAction.Export,
                SourceQuery: SourceQuery,
                DataFile: DataFile,
                Credentials: Credentials
                );

            return command;
        }

        public SqlBcpCommand format(
            SqlTableQuery SourceQuery, 
            FilePath FormatFile, 
            SqlUserCredentials Credentials = null)
        {
            var command = new SqlBcpCommand(
                BcpToolAction.Format,
                SourceQuery: SourceQuery,
                FormatFile: FormatFile,
                Credentials: Credentials
                );

            return command;
        }


        public SqlBcpCommand import(
            SqlTableName SourceTable, 
            FilePath DataFile, 
            FilePath FormatFile,
            SqlUserCredentials Credentials = null,
            int? BatchSize = null
            )
        {
            var command = new SqlBcpCommand(
                BcpToolAction.Import,
                TargetTable: SourceTable,
                DataFile: DataFile,
                FormatFile: FormatFile,
                Credentials: Credentials,
                BatchSize: BatchSize
                );

            return command;
        }

        public IEnumerable<SqlBcpCommand> transport(
            SqlTableQuery SourceQuery,
            SqlTableName TargetTable,
            FilePath DataFile,
            FilePath FormatFile,
            SqlUserCredentials Credentials,
            int? BatchSize = null

            ) => stream(
                export(SourceQuery, DataFile, Credentials),
                format(SourceQuery, FormatFile, Credentials),
                import(TargetTable, DataFile, FormatFile, Credentials, BatchSize)
                );

           public IEnumerable<SqlBcpCommand> Transport(
            SqlTableQuery SourceQuery,
            SqlUserCredentials SourceUser,
            SqlTableName TargetTable,
            SqlUserCredentials TargetUser,
            FilePath DataFile,
            FilePath FormatFile,
            int? BatchSize = null
            ) => stream(
                export(SourceQuery, DataFile, SourceUser),
                format(SourceQuery, FormatFile, SourceUser),
                import(TargetTable, DataFile, FormatFile, TargetUser, BatchSize)
                );

    }


}