//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using Meta.Core;
using Meta.Core.Workflow;

using static metacore;
using System;
using System.Collections.Generic;

using N = SystemNode;

public static partial class wf
{

    public static IWorkflowStep<R> step<R>(IWorkflowNode Host,
            WorkflowStepName name,
            Func<WorkFlowed<R>> worker,
             IEnumerable<FacetInfo> facets = null,
            Func<IApplicationMessage> beforeExec = null,
            WorkflowTransformer<R> afterSuccess = null,
            WorkflowTransformer<R> afterError = null)
                => new WorkflowStep<R>(Host, name, worker, facets ?? stream<FacetInfo>(),  beforeExec, afterSuccess, afterError);

    public static IEnumerable<IWorkflowStep<R>> steps<R>(IWorkflowNode Host,       
            Func<IApplicationMessage> beforeExec = null,
            WorkflowTransformer<R> afterSuccess = null,
            WorkflowTransformer<R> afterError = null)
                    => WorkflowStep.DefineSteps(Host, beforeExec, afterSuccess, afterError);

    public static WorkflowStep<X, R> step<X, R>(IWorkflowContext C,
           WorkflowStepName name,
            Func<X, WorkFlowed<R>> worker,
             IEnumerable<FacetInfo> facets = null,

            Func<X, IApplicationMessage> beforeExec = null,
            WorkflowTransformer<R> afterSuccess = null,
            WorkflowTransformer<R> afterError = null) 
                => new WorkflowStep<X, R>(C, name, worker, facets ?? stream<FacetInfo>(), beforeExec, afterSuccess, afterError);

    public static WorkflowStep<X1,X2, R> step<X1, X2, R>(IWorkflowContext C,
            WorkflowStepName name,
            Func<X1, X2, WorkFlowed<R>> worker,
            IEnumerable<FacetInfo> facets = null,
            Func<X1, X2, IApplicationMessage> beforeExec = null,
            WorkflowTransformer<R> afterSuccess = null,
            WorkflowTransformer<R> afterError = null)
                => new WorkflowStep<X1, X2, R>(C, name, worker, facets ?? stream<FacetInfo>(), beforeExec, afterSuccess, afterError);

    public static IEnumerable<W> payload<W>(WorkFlowed<W> flowed)
        => flowed.Payload;

    public static ILinkedContext context(IApplicationContext ac, NodeLink link)
        => new LinkedContext(ac, link);

    public static INodeEndpoint<E> source<E>(N producer, SystemUri Identifier)
        => new NodeEndpoint<E>(producer, Identifier, EndpointRole.Source);

    public static INodeEndpoint<E> target<E>(N consumer, SystemUri Identifier)
        => new NodeEndpoint<E>(consumer, Identifier, EndpointRole.Target);
}