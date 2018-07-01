//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    

    public class WorkflowStep
    {
        static IEnumerable<IWorkflowStep<R>> DefineNestedSteps<R>(IWorkflowNode Parent,
            Func<IApplicationMessage> beforeExec, WorkflowTransformer<R> afterSuccess,
            WorkflowTransformer<R> afterError = null)
                => from m in Parent.GetType().ClrType().Require().DeclaredPublicInstanceMethods
                   where m.ReturnsType<IEnumerable<WorkFlowed<R>>>()
                   let workers = m.Func<IEnumerable<WorkFlowed<R>>>(Parent)
                   from worker in workers()
                   let facets = WorkflowFacetAtribute.AppliedFacets(m)
                   let step = new WorkflowStep<R>(Parent, m.Name, () => worker, facets, beforeExec, afterSuccess, afterError)
                   select step;

        public static IEnumerable<IWorkflowStep<R>> DefineSteps<R>(IWorkflowNode Parent,           
            Func<IApplicationMessage> beforeExec, WorkflowTransformer<R> afterSuccess,
            WorkflowTransformer<R> afterError = null) 
                => (from m in Parent.GetType().ClrType().Require().DeclaredPublicInstanceMethods
                    where m.ReturnsType<WorkFlowed<R>>()
                    let worker =  m.Func<WorkFlowed<R>>(Parent)                   
                    let facets = WorkflowFacetAtribute.AppliedFacets(m)
                    let step = new WorkflowStep<R>(Parent, m.Name, worker, facets, beforeExec, afterSuccess, afterError)
                    select step).Union(DefineNestedSteps(Parent, beforeExec, afterSuccess, afterError));
    }

    public class WorkflowStep<R> : WorkflowNode<R>, IWorkflowStep<R>
    {
        public WorkflowStep(IWorkflowNode Parent, WorkflowStepName Name, Func<WorkFlowed<R>> StepBuilder,
            IEnumerable<Facet> Facets, Func<IApplicationMessage> BeforeExec = null,
            WorkflowTransformer<R> AfterSuccess = null, WorkflowTransformer<R> AfterError = null
                ) : base(Parent, Facets, AfterSuccess, AfterError)                
        {
        
            this.Name = Name;
            this.StepBuilder = Prepend(BeforeExec ?? (() => inform($"Executing {Name}")), StepBuilder);
        }

        Func<WorkFlowed<R>> Prepend(Func<IApplicationMessage> Message, Func<WorkFlowed<R>> StepBuilder)
        {
            Post(Message());
            return StepBuilder;          
        }
        
        protected void Post(IApplicationMessage Message)
            => Notify(Message);

        public Func<WorkFlowed<R>> StepBuilder { get; }

        public WorkflowStepName Name { get; }

        public override WorkFlowed<R> Construct()            
            => StepBuilder()
                .OnFailure(f =>
                {
                    var y = AfterError(f);
                    Post(y.Description);
                    return y;

                })
                .OnSuccess(s =>
                {
                    var y = AfterSuccess(s);
                    if (not(y.Description.IsEmpty))
                        Post(y.Description);
                    else
                        Post(inform($"Executed {Name}"));
                    return y;
                });

        WorkFlowed<R> IWorkflowStep<R>.Construct()
            => Construct();
    }

    public class WorkflowStep<X, R> : WorkflowNode<X, R>
    {
        public WorkflowStep(IWorkflowContext C, WorkflowStepName Name, Func<X, WorkFlowed<R>> StepBuilder,
            IEnumerable<Facet> Facets,Func<X, IApplicationMessage> BeforeExec = null,
            WorkflowTransformer<R> AfterSuccess = null, WorkflowTransformer<R> AfterError = null)
                : base(C,Facets)
        {
            this.Name = Name;
            this.StepBuilder = Prepend(BeforeExec ?? ((x) => inform($"Executing {Name} with input {x}")), StepBuilder);
            this.AfterSuccess = AfterSuccess;
            this.AfterError = AfterError;
        }

        Func<X, WorkFlowed<R>> Prepend(Func<X, IApplicationMessage> Message, Func<X, WorkFlowed<R>> StepBuilder)
            => x =>
            {
                Post(Message(x));
                return StepBuilder(x);
            };

        protected void Post(IApplicationMessage Message)
            => Notify(Message);

        public Func<X, WorkFlowed<R>> StepBuilder { get; }

        public WorkflowStepName Name { get; }

        public WorkflowTransformer<R> AfterSuccess { get; }

        public WorkflowTransformer<R> AfterError { get; }

        public override WorkFlowed<R> Construct(X input)
            => StepBuilder(input)
                .OnFailure(f =>
                {
                    var y = AfterError?.Invoke(f) ?? f;
                    Post(y.Description);
                    return y;
                })
                .OnSuccess(s =>
                {
                    var y = AfterSuccess?.Invoke(s) ?? s;
                    if (not(y.Description.IsEmpty))
                        Post(y.Description);
                    else
                        Post(inform($"Executed {Name}"));
                    return y;
                });
    }

    public class WorkflowStep<X1,X2, R> : WorkflowNode<X1, X2, R>
    {
        public WorkflowStep(IWorkflowContext C, WorkflowStepName Name, Func<X1,X2, WorkFlowed<R>> StepBuilder,
            IEnumerable<Facet> Facets, Func<X1,X2, IApplicationMessage> BeforeExec = null,
            WorkflowTransformer<R> AfterSuccess = null, WorkflowTransformer<R> AfterError = null)
                : base(C,Facets)
        {

            this.Name = Name;
            this.StepBuilder = Prepend(BeforeExec ?? ((x1, x2) => inform($"Executing {Name} with input {(x1,x2)}")), StepBuilder);
            this.AfterSuccess = AfterSuccess;
            this.AfterError = AfterError;            
        }

        Func<X1, X2, WorkFlowed<R>> Prepend(Func<X1,X2, IApplicationMessage> Message, Func<X1, X2, WorkFlowed<R>> StepBuilder)
            => (x1,x2) =>
            {
                Post(Message(x1,x2));
                return StepBuilder(x1,x2);
            };

        protected void Post(IApplicationMessage Message)
            => Notify(Message);

        public WorkflowStepName Name { get; }

        public Func<X1, X2, WorkFlowed<R>> StepBuilder { get; }

        public WorkflowTransformer<R> AfterSuccess { get; }

        public WorkflowTransformer<R> AfterError { get; }

        public override WorkFlowed<R> Construct(X1 x1, X2 x2)
            => StepBuilder(x1,x2)
                .OnFailure(f =>
                {
                    var y = AfterError?.Invoke(f) ?? f;
                    Post(y.Description);
                    return y;

                })
                .OnSuccess(s =>
                {
                    var y = AfterSuccess?.Invoke(s) ?? s;
                    if (not(y.Description.IsEmpty))
                        Post(y.Description);
                    else
                        Post(inform($"Executed {Name}"));
                    return y;
                });
    }
}