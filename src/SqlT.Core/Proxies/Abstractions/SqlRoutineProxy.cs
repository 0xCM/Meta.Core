//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;



    public abstract class SqlRoutineProxy : SqlObjectProxy, ISqlRoutineProxy
    {

    }

    public abstract class SqlRoutineProxy<R, TResult> : SqlRoutineProxy, ISqlRoutineProxy<R, TResult>
        where R : ISqlRoutineProxy<R, TResult>
        where TResult : class, ISqlTabularProxy, new()
    {


    }


}