//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using C = MonitorPath;
    using X = MonitorPathX;
    using R = CorrelationToken;

    [CommandPattern]
    public class MonitorPathX : CommandExecutionService<X, C, R>
    {


        public MonitorPathX(IApplicationContext C)
            : base(C)
        { }

        Option<R> WF(C command)
            => from svc in C.TryGetService<IFileChangeReceiver>()
               let agent = C.FileMonitorAgent()
               from ct in agent.Watch(command.Path, svc.Receive)
               select ct;

        protected override Option<R> TryExecute(C command)
        {
            try
            {
                var wf = WF(command);
                return wf;
            }
            catch(Exception e)
            {
                return none<R>(e);
            }
            
        }
    }

}