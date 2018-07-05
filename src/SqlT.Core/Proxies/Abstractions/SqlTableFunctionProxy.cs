//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;


    public abstract class SqlTableFunctionProxy<F,TResult> : SqlRoutineProxy<F,TResult>, ISqlTableFunctionProxy<F,TResult>
        where F : class, ISqlTableFunctionProxy<F, TResult>, new()
        where TResult : class, ISqlTabularProxy, new()

    {

    }



}