//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;

    using Meta.Core;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using static metacore;

    /// <summary>
    /// Encapsulates the outcome of a parsing operation
    /// </summary>
    /// <typeparam name="T">The type of fragment that was parsed</typeparam>
    public readonly struct TSqlParseResult<T>
       where T : TSql.TSqlFragment
    {
        public TSqlParseResult(T Content)
        {
            this.Content = Content;
            this.Error = none<SqlParseError>();
        }

        public TSqlParseResult(SqlParseError Error)
        {
            this.Error = Error;
            this.Content = none<T>();
        }

        public Option<T> Content { get; }

        public Option<SqlParseError> Error { get; }

        public bool Succeeded => Error.IsNone();

        public bool Failed => Error.IsSome();

        public IApplicationMessage GetApplicationError()
            => Error.MapValueOrDefault(e => e.GetApplicationError(), ApplicationMessage.Empty);

        public C As<C>()
            => cast<C>(Content.Require());

        public bool Is<C>()
            => Content.ValueOrDefault() is C;

        public bool IsStatementList
            => Is<TSql.StatementList>();

        public bool IsBatch
            => Is<TSql.TSqlBatch>();

        public bool IsScript
            => Is<TSql.TSqlScript>();

        public bool IsStatement
            => Is<TSql.TSqlStatement>();

        public Lst<TSql.TSqlStatement> ExtractStatements()
        {
            var statements = MutableList.Create<TSql.TSqlStatement>();
            if (IsBatch)
                statements.AddRange(As<TSql.TSqlBatch>().Statements);
            else if (IsStatementList)
                statements.AddRange(As<TSql.StatementList>().Statements);
            else if (IsScript)
                statements.AddRange(As<TSql.TSqlScript>().Batches.SelectMany(x => x.Statements));
            else if (IsStatement)
                statements.Add(As<TSql.TSqlStatement>());
            else
                throw new NotSupportedException();
            return statements;
        }
    }
}