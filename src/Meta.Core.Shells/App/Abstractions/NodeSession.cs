//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using static metacore;

    using N = SystemNode;

    public abstract class NodeSession<H,S> : NodeService<H,S>, INodeSession
        where H : NodeSession<H,S>
        where S : INodeSession
    {
        protected NodeSession(INodeContext C)
            : base(C)
        {
            CommandController = new NodeSessionController(C, () => stream(C.Host));
        }


        protected N ExecutingNode
            => SystemNode.Local;

        public IShellCommandController CommandController { get; }

        public IOption ExecuteCommand(ICommandSpec command, CorrelationToken? ct)
            => CommandController.ExecuteCommand(command, ct);

        protected IEnumerable<ShellCommandDescriptor> AvailableCommands
            => ShellCommand.DiscoverCommands(GetType());

        [ShellCommand, Description("Lists the commands known to the shell")]
        public void commands()
            => iter(AvailableCommands.OrderBy(x => x.LocalName.IdentifierText), Print);
    }

    public abstract class NodeSession<H> : NodeSession<H, INodeSession>
        where H : NodeSession<H>
    {
        protected NodeSession(INodeContext C)
            : base(C)
        {

        }

        
    }


    

    

}