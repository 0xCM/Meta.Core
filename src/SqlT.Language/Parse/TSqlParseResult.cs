//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Services;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using static metacore;
    

    public class TSqlParseResult
    {
        public static TSqlParseResult<T> Success<T>(T Content)
            where T : TSql.TSqlFragment
            => new TSqlParseResult<T>(Content);

        public static TSqlParseResult<T> Failure<T>(SqlParseError Error)
            where T : TSql.TSqlFragment
            => new TSqlParseResult<T>(Error);

        public static TSqlParseResult<T> Create<T>(T Content, SqlParseError Error)
            where T : TSql.TSqlFragment
            => isNotNull(Error) ? Failure<T>(Error) : Success(Content) ;        
    }

    public class TSqlParseResult<T> where T : TSql.TSqlFragment
    {

        public TSqlParseResult(T Content)
        {
            this.Content = Content;
        }

        public TSqlParseResult(SqlParseError Error)
        {
            this.Error = Error;
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

        public IReadOnlyList<TSql.TSqlStatement> ExtractStatements()
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
