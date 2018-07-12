//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    
    using static metacore;

    public class TableMonitorSettings : SystemAgentSettings<TableMonitorSettings>
    {

        public TableMonitorSettings(IConfigurationProvider configure)
            : base(configure, TableMonitor.AgentIdentifier)
        {
            
        }

        public override int SpinFrequency
            => 1000;
    }
}