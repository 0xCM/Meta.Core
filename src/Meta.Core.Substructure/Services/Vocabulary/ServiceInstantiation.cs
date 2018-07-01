//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Encapsulates an application service instance together with metadata describing it
/// </summary>
public class ServiceInstantiation
{
    static ServiceInstantiation FromInstance(object ServiceInstance, string ImplementationName = null, params Type[] ContractTypes)
    {
        var descriptor = new ServiceDescriptor(ServiceInstance.GetType(), ImplementationName ?? "Default" , ContractTypes);
        return new ServiceInstantiation(descriptor, ServiceInstance);
    }

    public static ServiceInstantiation<C> FromInstance<C>(object ServiceInstance, string ImplementationName = null)
    {
        var descriptor = new ServiceDescriptor(ServiceInstance.GetType(), ImplementationName ?? "Default", typeof(C));
        return new ServiceInstantiation<C>(descriptor, (C)ServiceInstance);

    }

    readonly ServiceDescriptor _Descriptor;
    readonly object _Instance;

    public ServiceInstantiation(ServiceDescriptor Descriptor, object Instance)
    {
        if (Descriptor == null)
            throw new ArgumentNullException(nameof(Descriptor));
        if (Instance == null)
            throw new ArgumentNullException(nameof(Instance));

        this._Descriptor = Descriptor;
        this._Instance = Instance;
    }

    public ServiceDescriptor Descriptor
        => _Descriptor;

    public object Instance
        => _Instance;

    public bool SupportsContract<T>() 
        => typeof(T).IsAssignableFrom(_Instance.GetType());

    public override string ToString()    
        => Descriptor.ToString();
}

public sealed class ServiceInstantiation<C> : ServiceInstantiation
{

    public ServiceInstantiation(ServiceDescriptor Descriptor, C Instance)
        : base(Descriptor, Instance)
    {

    }

    public new C Instance
        => (C)base.Instance;
}