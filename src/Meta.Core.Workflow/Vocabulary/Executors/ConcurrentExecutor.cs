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

    public class ConcurrentExecutor<R> : StepExecutor
    {
        public IEnumerable<WorkFlowed<R>> Execute(IEnumerable<IWorkflowStep<R>> steps)
           => from step in steps.AsParallel()
              select step.Construct();

        protected override IEnumerable<WorkFlowed<object>> Execute(IEnumerable<IWorkflowStep> steps)
        {
            var results = from result in steps.Cast<IWorkflowStep<R>>().AsParallel()
                          select result.Construct();
            foreach (var result in results)
                yield return result;
            
        }
    }



}