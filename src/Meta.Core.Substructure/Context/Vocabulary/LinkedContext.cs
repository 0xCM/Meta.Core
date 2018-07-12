//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using Meta.Core;

using N = SystemNode;
using static minicore;

public class LinkedContext : ILinkedContext
{
    
    public LinkedContext(INodeContext SourceContext, INodeContext TargetContext)
    {
        this.SourceContext = SourceContext;
        this.TargetContext = TargetContext;
        this.Link = SourceContext.Host.LinkTo(TargetContext.Host);       
    }

    public LinkedContext(IApplicationContext PeerContext, NodeLink Link)    
    {
        if (PeerContext is ILinkedContext)
        {
            this.SourceContext = (PeerContext as ILinkedContext).SourceContext.NodeContext(Link.Source);
            this.TargetContext = (PeerContext as ILinkedContext).TargetContext.NodeContext(Link.Target);
        }
        else if (PeerContext is INodeContext)
        {
            this.SourceContext = (PeerContext as INodeContext).NodeContext(Link.Source);
            this.TargetContext = (PeerContext as INodeContext).NodeContext(Link.Target);
        }
        else
        {
            this.SourceContext = PeerContext.NodeContext(Link.Source);
            this.TargetContext = PeerContext.NodeContext(Link.Target);
        }
        this.Link = Link;
    }

    public LinkedContext(IApplicationContext PeerContext, N SourceNode, N TargetNode)
        : this(PeerContext, SourceNode.LinkTo(TargetNode))
    { }

    public INodeContext SourceContext { get; }

    public INodeContext TargetContext { get; }
  
    public NodeLink Link { get; }

    public N SourceNode
        => Link.Source;

    public N TargetNode
        => Link.Target;

    public bool LinkedToSelf
        => Link.LinkedToSelf;

    IConfigurationProvider IApplicationContext.ConfigurationProvider
        => SourceContext.ConfigurationProvider;

    string IApplicationContext.EnvironmentName
        => link(SourceContext.EnvironmentName,TargetContext.EnvironmentName).ToString();

    string IApplicationContext.ComponentName
        => link(SourceContext.ComponentName, TargetContext.ComponentName).ToString();

    IReadOnlyList<ServiceDescriptor> IApplicationContext.ProvidedServices
        => SourceContext.ProvidedServices;

    public LinkedContext ReplaceSource(N NewSource)
       => new LinkedContext(this, NewSource.LinkTo(TargetNode));

    public LinkedContext ReplaceTarget(N NewTarget)
        => new LinkedContext(this, SourceNode.LinkTo(NewTarget));

    public override string ToString()
        => Link.ToString();

    ILinkedContext ILinkedContext.ReplaceSource(N NewSource)
        => ReplaceSource(NewSource);

    ILinkedContext ILinkedContext.ReplaceTarget(N NewTarget)
        => ReplaceTarget(NewTarget);

    protected object InstantiateService(Type ImplemementationType)
        => Activator.CreateInstance(ImplemementationType, this);

    T IApplicationContext.Service<T>()
        => SourceContext.Service<T>();

    T IApplicationContext.Service<T>(string ImplementationName)
        => SourceContext.Service<T>(ImplementationName);

    Option<T> IApplicationContext.TryGetService<T>()
        => SourceContext.TryGetService<T>();

    Option<object> IApplicationContext.TryGetService(ServiceIdentifier Identifier)
        => SourceContext.TryGetService(Identifier);

    Option<T> IApplicationContext.TryGetService<T>(string ImplementationName)
        => SourceContext.TryGetService<T>(ImplementationName);

    T IApplicationContext.Setting<T>(string SettingName)
        => SourceContext.Setting<T>(SettingName);

    T IApplicationContext.Settings<T>()
        => SourceContext.Settings<T>();

    void IApplicationContext.PostMessage(IAppMessage message)
        => SourceContext.PostMessage(message);

    bool IApplicationContext.IsServiceProvided<T>(string ImplementationName)
        => SourceContext.IsServiceProvided<T>(ImplementationName);

    Option<T> IApplicationContext.TryGetValue<T>(string name)
        => SourceContext.TryGetValue<T>(name);

    void IDisposable.Dispose()
    {
     
    }
}

