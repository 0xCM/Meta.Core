//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class SqlTFactory
    {
        /// <summary>
        /// Determines whether a statement has the "drop existing" clause
        /// </summary>
        /// <param name="src">The statement to evaluate</param>
        /// <returns></returns>
        static bool DropExisting(this TSql.CreateIndexStatement src)
            => src.IndexOptions.OfType<TSql.IndexStateOption>().Any(
                        x => x.OptionKind == TSql.IndexOptionKind.DropExisting && x.OptionState == TSql.OptionState.On);

        /// <summary>
        /// Determines whether a statement has the "drop existing" clause
        /// </summary>
        /// <param name="src">The statement to evaluate</param>
        /// <returns></returns>
        static bool DropExisting(this TSql.CreateColumnStoreIndexStatement src)
            => src.IndexOptions.OfType<TSql.IndexStateOption>().Any(
                        x => x.OptionKind == TSql.IndexOptionKind.DropExisting
                        && x.OptionState == TSql.OptionState.On);


        /// <summary>
        /// Constructs a <see cref="SqlIndex"/> representation from a <see cref="TSql.CreateIndexStatement"/>
        /// </summary>
        /// <param name="src">The source statement</param>
        /// <returns></returns>
        [SqlTBuilder]
        public static Option<SqlIndex> Model(this TSql.CreateIndexStatement src)
            => new SqlIndex
                (
                    IndexName: src.Name.Value,
                    TableName: src.OnName.ToTableName(),
                    PrimaryColumns: map(src.Columns, c => new SqlIndexColumn(c.Column.FormatName())),
                    IncludedColumns: map(src.IncludeColumns, c => new SqlIndexColumn(c.FormatName())),
                    Clustered: src.Clustered.HasValue ? src.Clustered.Value : false,
                    Unique: src.Unique,
                    DropExisting: src.DropExisting()
                );

        /// <summary>
        /// Constructs a <see cref="SqlIndex"/> representation from a <see cref="TSql.CreateColumnStoreIndexStatement"/>
        /// </summary>
        /// <param name="src">The source statement</param>
        /// <returns></returns>        
        [SqlTBuilder]
        public static Option<SqlIndex> Model(this TSql.CreateColumnStoreIndexStatement src)
            => new SqlIndex
                (
                    IndexName: src.Name.Value,
                    TableName: src.OnName.ToTableName(),
                    PrimaryColumns: map(src.Columns, c => new SqlIndexColumn(c.FormatName())).ToArray(),
                    Clustered: src.Clustered.HasValue ? src.Clustered.Value : false,
                    DropExisting: src.DropExisting()
                );
    }
}