//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;

    using SqlT.Core;
    using SqlT.Models;
    using sxc = SqlT.Syntax.contracts;


    public abstract class SqlWorkflowRoutineStep : ISqlWorkflowRoutineStep
    {
        protected SqlWorkflowRoutineStep(sxc.ISqlObjectName Name, Type RoutineType, Type ResultType)
        {
            this.Name = Name;
            this.RoutineProxyType = RoutineType;
            this.ResultProxyType = ResultType;
        }

        public sxc.ISqlObjectName Name { get; }

        public Type RoutineProxyType { get; }

        public Option<Type> ResultProxyType { get; }

        public override string ToString()
            => Name.Format(true);

    }

    public abstract class SqlWorkflowRoutineStep<N> : SqlWorkflowRoutineStep
        where N : sxc.ISqlObjectName
    {
        protected SqlWorkflowRoutineStep(N Name, Type RoutineType, Type ResultType)
            : base(Name, RoutineType, ResultType)
        {
            this.Name = Name;
        }

        public new N Name { get; }

    }

}