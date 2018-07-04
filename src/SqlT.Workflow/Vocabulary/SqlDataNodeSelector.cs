//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;

    using Meta.Core;
    using Meta.Core.Workflow;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public class SqlDataNodeSelector : DataTransformer
    {
        public SqlFunctionName RoutineName { get; }

        protected SqlDataNodeSelector(SqlFunctionName RoutineName, IDataSource Source, IDataTarget Target)
            : base(new TransformationName(RoutineName.FullName), Source, Target)
        {
            this.RoutineName = RoutineName;
        }
    }

    public class SqlDataNodeSelector<F, T> :  SqlDataNodeSelector,  ISqlWorkflowFunction<F, T>
        where F : sxc.table_function
        where T : class, IDataTarget, new()
    {
        protected SqlDataNodeSelector(SqlFunctionName RoutineName, IDataSource Source, IDataTarget Target)
            : base(RoutineName, Source, Target)
        {
            
        }
    }

    public class SqlDataNodeSelector<F, S, T> : SqlDataNodeSelector, ISqlWorkflowFunction<F, S, T>
        where F : sxc.table_function
        where S : class, IDataSource, new()
        where T : class, IDataTarget, new()
    {


        protected SqlDataNodeSelector(SqlFunctionName RoutineName, S Source, T Target)
            : base(RoutineName, Source, Target)
        {

        }
    }
}