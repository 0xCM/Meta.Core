//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core.Workflow;
    using Meta.Core.Build;
    using static Meta.Core.Build.BuildSyntax;

    using static metacore;
      
    [Workflow]
    class MetaBuildTests : WorkflowNode<WorkflowArgument,StepResult>
    {

        static IReadOnlyList<WorkflowStepMethod> WorkflowSteps { get; }

        static IEnumerable<WorkflowStepMethod> GetSteps<T>(int precedence = 0)
            => from m in ClrClass.Get<T>().DeclaredInstanceMethods
               let a = m.TryGetCustomAttribute<WorkflowStepAttribute>()
               where a.IsSome()
               select new WorkflowStepMethod
               (
                   Method: m,
                   StepName: a.MapValue(x => x.StepName.ValueOrElse(() => m.Name)),
                   Precedence: a.MapValue(x => x.Precedence.ValueOrElse(() => precedence++))
               );

        static MetaBuildTests()
        {
            WorkflowSteps = GetSteps<MetaBuildTests>().OrderBy(x => x.Precedence).ToReadOnlyList();
        }

        IMetaBuild MetaBuild
            => C.MetaBuild();

        public MetaBuildTests(IWorkflowContext C)
           : base(C)
        {

        }

        protected BuildNavigator BuildNavigator
            => C.BuildNavigator(MetaShell.Instance.AppDesignator.Area.Identifier);

        public override WorkFlowed<StepResult> Construct(WorkflowArgument arg)
        {
            var _args = new object[] { (WorkflowArguments.Create(stream(arg))) };
            var results = rolist(from m in WorkflowSteps
                        let result = m.Method.InvokeOnHost(this, _args)
                        select result as IOption);
                 
            return wf.lift(stream(new StepResult(results, true)));
        }

        ProjectDefinition DefineProject(NodeFilePath SrcPath)
        {
            var def = new ProjectDefinition();

               
            return def;
        }               

        [WorkflowStep]
        public Option<int> ReadProperties(WorkflowArguments args)
        {
            

            var files = map(BuildNavigator.AreaPropertyFiles, DefineProject);


            return 0;
                        
        }

    }
}
