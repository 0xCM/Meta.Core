//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public interface ISqlProcedureInvocation : ISqlActionInvocation
    {
        SqlProcedureName ProcedureName { get; }
    }

    public interface ISqlCommandAction : ISqlAction
    {

    }

    public interface ISqlCommandAction<T> : ISqlAction<T>, ISqlCommandAction
        where T : ISqlCommandAction
    { }

    public interface ISqlQueryAction : ISqlAction
    {

    }

    public interface ISqlAction : IModel
    {
        Option<Type> ResultType { get; }
        bool RequiresScript { get; }
        Option<SqlRoutineParameter> this[string name] { get; }
        

    }

    public interface ISqlAction<T> : ISqlAction
        where T : ISqlAction
    {


    }

    public interface ISqlActionInvocation
    {
        ISqlAction Action { get; }
        IReadOnlyList<SqlParameterValue> Arguments { get; }
    }

}
