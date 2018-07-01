//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;

    public interface IWorkflowStep 
    {
        WorkflowStepName Name { get; }        
    }

    public interface IWorkflowStep<R> : IWorkflowStep
    {
        WorkFlowed<R> Construct();
    }

    public interface IWorkflowStep<in X, R> : IWorkflowStep
    {
        WorkFlowed<R> Construct(X x);
    }

    public interface IWorkflowStep<in X1, in X2, R> : IWorkflowStep
    {
        WorkFlowed<R> Construct(X1 x1, X2 x2);
    }

}