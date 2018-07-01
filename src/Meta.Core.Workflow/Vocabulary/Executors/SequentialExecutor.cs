//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using static metacore;


    public class SequentialExecutor<R> : StepExecutor, IStepExecutor<R>
    {
        public SequentialExecutor()
        {
            this.HaltOnError = false;
        }

        public SequentialExecutor(bool HaltOnError)
        {
            this.HaltOnError = HaltOnError;
        }

        public bool HaltOnError { get; }

        public IEnumerable<WorkFlowed<R>> Execute(IEnumerable<IWorkflowStep<R>> steps)
        {
            foreach(var step in steps)
            {
                var flowed = step.Construct();
                yield return flowed;

                if (not(flowed.Succeeded) && HaltOnError)
                    break;
            }
        }

        protected override IEnumerable<WorkFlowed<object>> Execute(IEnumerable<IWorkflowStep> steps)
        {
            foreach(var step in steps.Cast<IWorkflowStep<R>>())
            {
                var flowed = step.Construct();
                yield return flowed;

                if (not(flowed.Succeeded) && HaltOnError)
                    break;

            }
        }

    }



}