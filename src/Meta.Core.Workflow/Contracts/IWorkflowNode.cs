//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using static metacore;

    public interface IWorkflowNode
    {
        WorkFlowed<object> Construct(params object[] args);
        WorkFlowed<object> Evaluate(params object[] args);

        IWorkflowContext WorkflowContext { get; }
    }

    public interface IWorkflowNode<R> : IWorkflowNode
    {
        WorkFlowed<R> Construct();
        WorkFlowed<R> Evaluate(WorkFlowed<R> construction);
    }


    public interface IWorkflowNode<in X, R> : IWorkflowNode
    {
        WorkFlowed<R> Construct(X x);
        WorkFlowed<R> Evaluate(X x);
    }

    public interface IWorkflowNode<in X1, in X2, R> : IWorkflowNode
    {
        WorkFlowed<R> Construct(X1 x1, X2 x2);
        WorkFlowed<R> Evaluate(X1 x1, X2 x2);
    }


}