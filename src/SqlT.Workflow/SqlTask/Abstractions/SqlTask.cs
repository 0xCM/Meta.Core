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
    

    public class SqlTask : ISqlTask
    {

        public SqlTask(SqlTaskName Name, ISqlArguments Arguments = null)
        {
            this.Name = Name;
            this.Arguments = Arguments ?? SqlArguments.Empty;
        }

        public SqlTaskName Name { get; }

        protected ISqlArguments Arguments { get; }

        ISqlArguments ISqlTask.Arguments
            => Arguments;
    }

    /// <summary>
    /// Specifies what to do but now how to do it
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlTask<T> : SqlTask
       where T : SqlTask<T>
    {
        protected SqlTask()
            :base(typeof(T).Name, SqlArguments.Empty)
        { }

        protected SqlTask(ISqlArguments Arguments)
            : base(typeof(T).Name, Arguments)
        {


        }

        protected SqlTask(SqlTaskName Name, ISqlArguments Arguments)
            : base(Name, Arguments)
        {


        }
    }

    public abstract class SqlTask<A,T> : SqlTask<T>
       where T : SqlTask<A,T>
        where A : class,  ISqlProxyAssembly, new()
    {
        protected SqlTask()
            : base(typeof(T).Name, SqlArguments.Empty)
        { }

        protected SqlTask(ISqlArguments Arguments)
            : base(typeof(T).Name, Arguments)
        {


        }

        protected SqlTask(SqlTaskName Name, ISqlArguments Arguments)
            : base(Name, Arguments)
        {


        }

    }


}