//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;


    public class WorkCommandAgentObserver<TSpec> : WorkAgentObserver<WorkCommand<TSpec>>, IWorkCommandAgentObserver<TSpec>
        where TSpec : CommandSpec<TSpec>, new()
    {
        public WorkCommandAgentObserver
            (
                WorkSubmitted<TSpec> WorkSubmitted,
                WorkDispatched<TSpec> WorkDispatched,
                WorkCompleted<TSpec> WorkCompleted
            ) : base
            (
                work => WorkSubmitted?.Invoke(work.Command),
                work => WorkDispatched?.Invoke(work.Command),
                work => WorkCompleted?.Invoke(work.Command)
            )
        {

        }


        public WorkCommandAgentObserver
            (
                WorkGroupSubmitted GroupSubmitted = null,
                WorkGroupCompleted GroupCompleted = null,
                WorkSubmitted<TSpec> WorkSubmitted = null,
                WorkDispatched<TSpec> WorkDispatched = null,
                WorkCompleted<TSpec> WorkCompleted = null
            ) : base
            (
                GroupSubmitted,
                GroupCompleted,
                work => WorkSubmitted?.Invoke(work.Command),
                work => WorkDispatched?.Invoke(work.Command),
                work => WorkCompleted?.Invoke(work.Command)
            )
        {

        }





    }

}