//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;

using static minicore;

public class ServiceFactoryState
{
    ConcurrentDictionary<ServiceDescriptor, ServiceDescriptor> _Descriptors { get; }
        = new ConcurrentDictionary<ServiceDescriptor, ServiceDescriptor>();

    ConcurrentDictionary<ServiceInstantiation, ServiceInstantiation> _Instantiations { get; }
        = new ConcurrentDictionary<ServiceInstantiation, ServiceInstantiation>();

    public bool DescriptorExists(ServiceDescriptor d)
        => _Descriptors.ContainsKey(d);

    public IReadOnlySet<ServiceDescriptor> Descriptors
            => _Descriptors.Values.ToReadOnlySet();


    public void AddDescriptor(ServiceDescriptor descriptor)
    {
        _Descriptors.TryAdd(descriptor, descriptor);
    }

    public void AddDescriptors(IEnumerable<ServiceDescriptor> descriptors)
    {
        iter(descriptors, AddDescriptor);
    }

    public void RemoveDescriptor(ServiceDescriptor descriptor)
    {
        _Descriptors.TryRemove(descriptor, out ServiceDescriptor value);
    }

    public void AddInstantiation(ServiceInstantiation instantiation)
    {
        _Instantiations.TryAdd(instantiation, instantiation);
    }

    public void RemoveInstantiation(ServiceInstantiation instantiation)
    {
        _Instantiations.TryRemove(instantiation, out ServiceInstantiation value);
    }


    public IReadOnlySet<ServiceInstantiation> Instantiations
        => _Instantiations.Values.ToReadOnlySet();

    public Dictionary<Type, IDependencyResolver> Resolvers { get; }
        = new Dictionary<Type, IDependencyResolver>();
}
