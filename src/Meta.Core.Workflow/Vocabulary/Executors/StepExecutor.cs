﻿//-------------------------------------------------------------------------------------------
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

    public abstract class StepExecutor : IStepExecutor
    {
        protected abstract IEnumerable<WorkFlowed<object>> Execute(IEnumerable<IWorkflowStep> steps);

        IEnumerable<WorkFlowed<object>> IStepExecutor.Execute(IEnumerable<IWorkflowStep> steps)
            => Execute(steps);
    }




}