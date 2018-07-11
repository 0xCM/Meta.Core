//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static minicore;
using N = SystemNode;

using Meta.Core;

public class NodeContext : ApplicationContext, INodeContext
{
    static Dictionary<string, NodeContext> Contexts { get; }
        = new Dictionary<string, NodeContext>();
    static object locker = new object();

    HashSet<ServiceInstantiation> Instantiations { get; }
        = new HashSet<ServiceInstantiation>();


    public static INodeContext Get(IApplicationContext PeerContext, N Host)
    {
        lock(locker)
        {           
            if(!Contexts.ContainsKey(Host.NodeIdentifier))
                Contexts[Host.NodeIdentifier] = new NodeContext(cast<ApplicationContext>(PeerContext).ServiceFactoryState, Host);
            return Contexts[Host.NodeIdentifier];
        }
    }

    NodeContext(ServiceFactoryState ServiceFactoryState, N Host)
        : base(ServiceFactoryState)
    {
        this.Host = Host;
    }

    protected NodeContext(IApplicationContext PeerContext, N Host)
        : base(PeerContext)
    {
        this.Host = Host;
    }

    object locker2 = new object();
    Option<ServiceInstantiation> FindNodeInstantiation(ServiceDescriptor Descriptor, Type ContractType, string ImplementationName)
    {
        lock (locker2)
        {
            return (from i in dict(Instantiations.Select(x => (x, x.Descriptor)))
                    where i.Value.Contracts.Contains(ContractType)
                    && i.Value.ImplementationName == ImplementationName
                    select i.Key).TryGetSingle();
        }
    }


    bool IsNodeSerice(Type ContractType)
        => ContractType.GetInterfaces().Contains(typeof(INodeService));

    protected override Option<ServiceInstantiation> FindInstantiation(ServiceDescriptor Descriptor, Type ContractType, string ImplementationName)
        => IsNodeSerice(ContractType) 
            ? FindNodeInstantiation(Descriptor, ContractType, ImplementationName)
            : base.FindInstantiation(Descriptor, ContractType, ImplementationName);

    public N Host { get; }

    protected override object InstantiateService(Type ImplemementationType)
        => Activator.CreateInstance(ImplemementationType, this);

}

