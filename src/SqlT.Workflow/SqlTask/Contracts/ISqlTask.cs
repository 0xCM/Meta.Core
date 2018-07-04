//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    public interface ISqlTask
    {
        SqlTaskName Name { get; }
        ISqlArguments Arguments { get; }
    }

    public interface ISqlTask<A> : ISqlTask
        where A : ISqlArguments
    {
        new A Arguments { get; }
    }



}