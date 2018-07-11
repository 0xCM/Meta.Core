//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using SqlT.Core;

    /// <summary>
    /// External command that defines a SQL BCP tool operation
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/sql/tools/bcp-utility
    /// </remarks>
    [CommandSpec]    
    public class SqlBcpCommand : CommandSpec<SqlBcpCommand>
    {      

        public static implicit operator string(SqlBcpCommand src)
            => src.ToString();

        /// <summary>
        /// The name of the targeted SQL Server 
        /// </summary>
        public SqlServerName ServerName { get; set; }

        /// <summary>
        /// The selected tool feature to execute
        /// </summary>
        public BcpToolAction Action { get; set; }


        /// <summary>
        /// For the export action, specifies the text of the query, if applicable
        /// </summary>
        public Option<SqlTableQuery> SourceQuery { get; set; }

        /// <summary>
        /// For the export action, specifies the name of the source table/view if applicable
        /// </summary>
        public Option<SqlTableName> SourceTable
            => SourceQuery.Map(q => q.SourceName);

        /// <summary>
        /// For the import action, specifies the name of the destination table/view if applicable
        /// </summary>
        public Option<SqlTableName> TargetTable { get; set; }

        /// <summary>
        /// The path to the import/export file interpreted according to the tool action.
        /// </summary>
        public Option<FilePath> DataFile { get; set; }

        /// <summary>
        /// The path to the import file if the <see cref="BcpToolAction.Format"/> action is specified
        /// </summary>
        public Option<FilePath> FormatFile { get; set; }

        /// <summary>
        /// The username to use when connecting to SQL Server, if applicable
        /// </summary>
        public Option<SqlUserCredentials> Credentials { get; set; }

        /// <summary>
        /// The desired batch size
        /// </summary>
        public Option<int> BatchSize { get; set; }

        public SqlBcpCommand()
        {

        }

        /// <summary>
        /// Creates a new command based on state of the current command
        /// </summary>
        /// <param name="Action"></param>
        /// <returns></returns>
        public SqlBcpCommand WithNewAction(BcpToolAction Action)
            => new SqlBcpCommand(Action,
                SourceQuery : SourceQuery.ValueOrDefault(),
                TargetTable : TargetTable.ValueOrDefault(),
                DataFile : DataFile.ValueOrDefault(),
                FormatFile: FormatFile.ValueOrDefault(),
                Credentials: Credentials.ValueOrDefault(),
                BatchSize: BatchSize.ValueOrDefault()
                );

        public SqlBcpCommand
        (
            BcpToolAction Action,
            SqlTableQuery SourceQuery = null,
            SqlTableName TargetTable = null,
            FilePath DataFile = null,
            FilePath FormatFile = null,
            SqlUserCredentials Credentials = null,
            int? BatchSize = null
        )
        {
            this.Action = Action;
            this.SourceQuery = SourceQuery;
            this.TargetTable = TargetTable;
            this.ServerName 
                = this.SourceQuery.MapValueOrElse(q 
                    => q.SourceName.ServerName, x 
                    => this.TargetTable.MapValueOrDefault(t 
                        => t.ServerName, SqlServerName.Empty)
                        );
            this.DataFile = DataFile;
            this.FormatFile = FormatFile;
            this.Credentials = Credentials;
            this.BatchSize = BatchSize != null ? BatchSize.Value : none<int>();
        }

        public string SemanticName
            => DataFile.MapValueOrElse(
                x => x.FileName.RemoveExtension(), 
                _ => FormatFile.MapValueOrDefault(
                y => y.FileName.RemoveExtension(), FileName.Empty));

        public FileName BatchFileName
        {
            get
            {
                BcpFileType GetBatchFileType()
                {
                    switch (Action)
                    {
                        case BcpToolAction.Import:
                            return BcpFileType.BcpImportScript;
                        case BcpToolAction.Format:
                            return BcpFileType.BcpFormatScript;
                        case BcpToolAction.Export:
                            return BcpFileType.BcpFormatScript;
                    }
                    return BcpFileType.None;
                }

                var table = (Action == BcpToolAction.Export || Action == BcpToolAction.Format) 
                          ? SourceTable 
                          : TargetTable;
                var filterValue = SourceQuery.MapValueOrDefault(q => q.FilterValue, string.Empty);
                return (from t in table
                        let fn = SqlBcpFileName.Create(GetBatchFileType(), t, filterValue)
                        select fn).MapValueOrDefault(x => FileName.Parse(x));
            }
        }

        /// <summary>
        /// Gets the companion bulk insert script
        /// </summary>
        public Option<SqlScript> SqlInsertScript
            => from target in TargetTable
               from dat in DataFile
               from fmt in FormatFile
               select target.SQL_BULK_INSERT(dat.FileSystemPath, fmt.FileSystemPath);                   
    }

}