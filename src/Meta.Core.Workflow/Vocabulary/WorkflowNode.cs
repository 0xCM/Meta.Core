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

    /// <summary>
    /// Represents a transactional constituent of the workflow
    /// </summary>
    public abstract class WorkflowNode : NodeComponent, IWorkflowNode
    {

        protected new IWorkflowContext C
            => Context as IWorkflowContext;

        protected WorkflowNode(IWorkflowNode Parent, IEnumerable<Facet> Facets)
            : base(Parent.WorkflowContext)
        {
           
            this.ParentNode = some(Parent);
            this.Facets = rolist(Facets ?? stream<Facet>());
        }

        protected WorkflowNode(IWorkflowContext C, IEnumerable<Facet> Facets)
            : base(C)
        {
            this.Facets = rolist(Facets);
            this.Facets = rolist(Facets ?? stream<Facet>());
        }

        public Option<IWorkflowNode> ParentNode { get; }

        public IReadOnlyList<Facet> Facets { get; }

        public IWorkflowContext WorkflowContext
            => C;

        public abstract WorkFlowed<object> Construct(params object[] args);

        protected virtual WorkFlowed<object> Evaluate(WorkFlowed<object> construction)
            => construction.Evaluate();

        public WorkFlowed<object> Evaluate(params object[] args)
            => Evaluate(Construct(args));
    }

    public class WorkflowNode<R> : WorkflowNode, IWorkflowNode<R>
    {
        protected WorkflowNode(IWorkflowNode Parent, 
            IEnumerable<Facet> Facets = null,
            WorkflowTransformer<R> AfterSuccess = null,
            WorkflowTransformer<R> AfterError = null
            )
            : base(Parent,Facets)
        {
            SuccessTransformer = AfterSuccess;
            ErrorTransformer = AfterError;
        }
       
        WorkflowTransformer<R> SuccessTransformer { get; }

        WorkflowTransformer<R> ErrorTransformer { get; }

        protected WorkflowNode(IWorkflowContext C, IEnumerable<Facet> Facets = null)
            : base(C,Facets)
        {

        }

        protected virtual IStepExecutor<R> Executor { get; }
            = new SequentialExecutor<R>();

        protected virtual WorkFlowed<R> AfterSuccess(WorkFlowed<R> flowed)        
            => SuccessTransformer?.Invoke(flowed) ?? flowed;
       
        protected virtual WorkFlowed<R> AfterError(WorkFlowed<R> flowed)
            => ErrorTransformer?.Invoke(flowed) ?? flowed;

        public virtual WorkFlowed<R> Construct()
        {
            var steps = from s in Steps
                        select s.Construct();
            return steps.Reduce();
        }

        public virtual WorkFlowed<R> Evaluate(WorkFlowed<R> construction)
            => construction.Evaluate();

        protected virtual IEnumerable<IWorkflowStep<R>> Steps
            => wf.steps<R>(this, null, AfterSuccess, AfterError);

        public override sealed WorkFlowed<object> Construct(params object[] args)
            => Construct();
    }

    public class WorkflowNode<X,R> : WorkflowNode, IWorkflowNode<X,R>
    {
        protected WorkflowNode(IWorkflowContext C, IEnumerable<Facet> Facets = null)
            : base(C,Facets)
        {

        }

        protected WorkflowNode(IWorkflowNode Parent, IEnumerable<Facet> Facets = null)
            :base(Parent,Facets)
        {

        }

        public virtual WorkFlowed<R> Construct(X x)
            => wf.flowed(stream<R>());

        public virtual WorkFlowed<R> Evaluate(X x)
            => Construct(x).Evaluate();

        public override sealed WorkFlowed<object> Construct(params object[] args)
            => Construct((X)args[0]);

    }

    public class WorkflowNode<X1,X2, R> : WorkflowNode, IWorkflowNode<X1,X2, R>
    {
        protected WorkflowNode(IWorkflowContext C, IEnumerable<Facet> Facets = null)
            : base(C,Facets)
        {

        }

        protected WorkflowNode(IWorkflowNode Parent, IEnumerable<Facet> Facets = null)
            : base(Parent,Facets)
        {

        }

        public virtual WorkFlowed<R> Construct(X1 x1, X2 x2)
            => wf.flowed(stream<R>());

        public virtual WorkFlowed<R> Evaluate(X1 x1, X2 x2)
            => Construct(x1,x2).Evaluate();

        public override sealed WorkFlowed<object> Construct(params object[] args)
            => Construct((X1)args[0],(X2)args[1]);
    }

}
