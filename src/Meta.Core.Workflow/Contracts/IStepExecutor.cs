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


    public interface IStepExecutor 
    {
        IEnumerable<WorkFlowed<object>> Execute(IEnumerable<IWorkflowStep> steps);
    }


    public interface IStepExecutor<R> : IStepExecutor
    {
        IEnumerable<WorkFlowed<R>> Execute(IEnumerable<IWorkflowStep<R>> steps);
    }

}
