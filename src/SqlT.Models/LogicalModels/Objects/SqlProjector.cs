//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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

        public SqlObjectName SourceTableName { get; }

        public string QueryPattern { get; }

        public IReadOnlyList<SqlColumnProjection> Columns { get; }

        public string QueryType { get; }

        public string QueryPeer { get; }

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
