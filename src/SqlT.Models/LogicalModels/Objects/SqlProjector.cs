//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;


    /// <summary>
    /// Characterizes a projector
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Projector)]
    public sealed class SqlProjector : SqlRoutine<SqlProjector>
    {

        public readonly SqlObjectName SourceTableName;
        public readonly string QueryPattern;
        public readonly IReadOnlyList<SqlColumnProjection> Columns;
        public readonly string QueryType;
        public readonly string QueryPeer;

        public SqlProjector
        (
            SqlTableName SourceTableName,
            SqlFunctionName FunctionName, 
            IReadOnlyList<SqlRoutineParameter> Parameters,
            IReadOnlyList<SqlColumnProjection> Columns,
            string QueryPattern,
            string QueryType,
            string QueryPeer = null,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null

        ) : base
            (
                RoutineName : FunctionName, 
                Parameters : Parameters, 
                Documentation : Documentation, 
                Properties : Properties
            )
        {
            this.SourceTableName = SourceTableName;
            this.Columns = Columns;
            this.QueryPattern = QueryPattern;
            this.QueryType = QueryType;
            this.QueryPeer = QueryPeer ?? String.Empty;
        }

        public string QueryIdentifier 
            => $"[{ObjectName.SchemaNamePart}].[{ObjectName.UnqualifiedName}]";

        /// <summary>
        /// Indicates whether the query should be interpreted as a change projector
        /// </summary>
        public bool IsChangeProjector 
            => QueryType == SqlQueryTypes.ChangeProjector;

        /// <summary>
        /// Indicates whether the query should be interpreted as a sequential projector
        /// </summary>
        public bool IsSequentialProjector 
            => QueryType == SqlQueryTypes.SequentialProjector;

        public bool HasPeer
            => !String.IsNullOrWhiteSpace(QueryPeer);

        
    }

}
