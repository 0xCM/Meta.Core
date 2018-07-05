//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Base type for agents that are responsible for a set of operations on a 
    /// specific computational node
    /// </summary>
    /// <typeparam name="A">The specialized agent subtype</typeparam>
    /// <typeparam name="S">The spcialized agent settings type</typeparam>
    public abstract class NodeAgent<A, S> : ServiceAgent<A, S>, INodeAgent
        where A : NodeAgent<A, S>
        where S : NodeAgentSettings<S>
    {
        protected new INodeContext C { get; }

        public NodeAgent(INodeContext C)
            : base(C)
        {
            this.C = C;
        }
 
        SystemNode INodeComponent.Host
            => C.Host;
    }

    public abstract class NodeAgent<A> : NodeAgent<A,NodeAgentSettings>
        where A : NodeAgent<A>
    {
        protected NodeAgent(INodeContext C)
            : base(C)
        {

        }

    }
}