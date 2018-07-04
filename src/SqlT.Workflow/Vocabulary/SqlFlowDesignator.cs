//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Runtime.CompilerServices;

    using Meta.Core;
    using Meta.Core.Workflow;
    using SqlT.Core;

    public class SqlWorkflowDesignator : WorkflowDesignator
    {
        public SqlWorkflowDesignator(SqlTransformationName Name, Type SourceType, Type TargetType)
            : base(new TransformationName(Name.FullName), SourceType, TargetType)
        {

        }

        public static WorkflowDesignator<S, T> Selector<S, T>(SqlFunctionName Name)
            => Define<S, T>(Name.ToString());

        public static WorkflowDesignator<S, T> Projector<S, T>(SqlProcedureName Name)
            => Define<S, T>(Name.ToString());

        public static SqlWorkflowDesignator Selector(SqlFunctionName Name, Type SourceType, Type TargetType)
            => new SqlWorkflowDesignator(Name.ToString(), SourceType, TargetType);

        public static WorkflowDesignator Projector(SqlProcedureName Name, Type SourceType, Type TargetType)
            => Define(Name.ToString(), SourceType, TargetType);

    }


}