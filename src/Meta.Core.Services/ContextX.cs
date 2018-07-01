//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using static metacore;


    public static class ContextX
    {

        public static Option<S> SysOpSet<S>(this IApplicationContext C, SystemNode ActiveNode)
            where S : SysOpComponent<S>
            => C.SysOpProvider().RequestOperationSet<S>(ActiveNode);

        public static Option<IOperationProvider> SysOpSet(this IApplicationContext C, Type ComponentType, SystemNode ActiveNode)
            => C.SysOpProvider().RequestOperationSet(ComponentType, ActiveNode);

        public static Option<CorrelationToken> MonitorFilePath(this IApplicationContext C, FolderPath Path, Action<FileChangeDescription> Observer)
            => from agent in C.FileMonitorAgent().StartIfNotRunning()
               from ct in agent.Watch(Path, Observer)
               select ct;




    }


}