//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.Commands
{
    using System;
    using System.Linq;
    
    public class CommandDispatcherSettings : SystemAgentSettings<CommandDispatcherSettings>
    {
        

        public CommandDispatcherSettings(IConfigurationProvider configure)
            : base(configure, CommandDispatcher.AgentIdentifier)
        { }


    }



}
