//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static minicore;
using Meta.Core;

public class ApplicationContext : IMutableContext
{
    const string DefaultImplementationName = "Default";

    public static readonly IApplicationContext Empty = new ApplicationContext(0);

    ApplicationContext(int _)
    {
        ServiceFactoryState = new ServiceFactoryState();
    }

    ServiceFactoryState _ServiceFactoryState;

    public ServiceFactoryState ServiceFactoryState
    {
        get
        {
            return _ServiceFactoryState;
        }
        set
        {
            if (value is null)       
                throw new ArgumentNullException("ServiceFactoryState cannot be null");
            _ServiceFactoryState = value;
                
        }
    }

    protected ApplicationContext(ServiceFactoryState CoreState)
    {
        this.ServiceFactoryState = CoreState;
    }

    protected ApplicationContext(IApplicationContext PeerContext)
    {
        this.ServiceFactoryState = ((ApplicationContext)PeerContext).ServiceFactoryState;
    }

    ApplicationContext(IEnumerable<Assembly> assemblies, IConfigurationProvider configuration,
            IMessageBroker broker, IServiceInstantiator instantiator)
    {
        Instantiator = instantiator ?? new DefaultServiceInstantiator(this);
        ServiceFactoryState = new ServiceFactoryState();
       
        if(configuration != null)
            InjectService<IConfigurationProvider>(configuration);

        if (broker != null)
            InjectService<IMessageBroker>(broker);

        RegisterAssemblies(assemblies?.ToArray() ?? array<Assembly>());
        RegisterAssemblyServices();
    }

    public static IMutableContext Create(IEnumerable<Assembly> assemblies, 
        IConfigurationProvider configuration = null, 
        IMessageBroker broker = null,
        IServiceInstantiator instantiator = null) 
            => new ApplicationContext(assemblies, configuration, broker, instantiator);

    protected virtual object InstantiateService(Type ImplementationType)
        => Instantiator.InstantiateService(ImplementationType);

    IReadOnlySet<ServiceDescriptor> Descriptors
        => ServiceFactoryState.Descriptors;

    IReadOnlySet<ServiceInstantiation> Instantiations
        => ServiceFactoryState.Instantiations;

    Dictionary<Type, IDependencyResolver> Resolvers
        => ServiceFactoryState.Resolvers;

    readonly object locker = new object();

    IServiceInstantiator Instantiator { get; }
        
    IAssemblyRegistrar AssemblyRegistrar
        => Service<IAssemblyRegistrar>();

    IMessageBroker Broker
        => Service<IMessageBroker>();

    void AddDescriptor(ServiceDescriptor descriptor)
        => ServiceFactoryState.AddDescriptor(descriptor);

    bool IsServiceProvided(Type contract, string ImplementationName)
        => Descriptors.Any(d => d.Contracts.Contains(contract) && d.ImplementationName == ImplementationName);

    protected virtual Option<ServiceInstantiation> FindInstantiation(ServiceDescriptor Descriptor, Type ContractType, string ImplementationName)
        => (from i in dict(Instantiations.Select(x => (x, x.Descriptor)))
            where i.Value.Contracts.Contains(ContractType)
            && i.Value.ImplementationName == ImplementationName
            select i.Key).TryGetSingle();

    Option<ServiceInstantiation<T>> TryAcquireService<T>(string ImplementationName)
    {
        lock (locker)
        {
            var descriptor = Descriptors.Where(
                                d => d.Contracts.Contains(typeof(T))
                                     && d.ImplementationName == ImplementationName
                                     ).FirstOrDefault();

            var qInstance = FindInstantiation(descriptor, typeof(T), ImplementationName);
            if (qInstance.IsSome())
                return qInstance.MapRequired(i => new ServiceInstantiation<T>(i.Descriptor, (T)i.Instance));

            T instance = default(T);
            if (descriptor == null)
            {
                if (Resolvers.ContainsKey(typeof(T)))
                {
                    instance = Resolvers[typeof(T)].ResolveService<T>(ImplementationName);
                    var I = ServiceInstantiation.FromInstance<T>(instance, ImplementationName);
                    ServiceFactoryState.AddInstantiation(I);
                    return I;
                }
            }
            else
            {                
                instance = (T)InstantiateService(descriptor.ImplementationType);
                var I = new ServiceInstantiation<T>(descriptor, instance);
                ServiceFactoryState.AddInstantiation(I);
                return I;    
            }

            return none<ServiceInstantiation<T>>();
        }
    }

    void InjectService(Type PrimaryContractType, ServiceInstantiation i)
    {
        if (IsServiceProvided(PrimaryContractType, i.Descriptor.ImplementationName))
            throw new ArgumentException($"The {i.Descriptor.ImplementationName} implementation for the {PrimaryContractType.Name} has already been specified");

        AddDescriptor(i.Descriptor);
        ServiceFactoryState.AddInstantiation(i);
    }

    Option<object> TryGetService(ServiceDescriptor d)
    {
        try
        {
            var instance = from i in Instantiations
                           where i.Descriptor.Contracts.Contains(d.Contracts.First())
                           && i.Descriptor.ImplementationType == d.ImplementationType
                           select i;
            var instantiation = instance.SingleOrDefault();
            if (instantiation != null)
                return instantiation.Instance;
            else
            {
                var newInstance = InstantiateService(d.ImplementationType); 
                var I = new ServiceInstantiation(d, newInstance);
                ServiceFactoryState.AddInstantiation(I);
                return newInstance;
            }
        }
        catch (Exception e)
        {
            return none<object>(AppMessage.Error(e));
        }


    }
    public Option<object> TryGetService(ServiceIdentifier Identifier)
    {
        var descriptor = (from d in Descriptors
                          let c = d.Contracts.First()
                          where c.FullName == Identifier.ContractType
                          && d.ImplementationType.FullName == Identifier.Implementor
                          select d).TryGetFirst();

        return from d in descriptor
               from s in TryGetService(d)
               select s;
    }

    void ReplaceService(Type PrimaryContractType, ServiceInstantiation i)
    {
        var descriptor = Descriptors.FirstOrDefault(d
            => d.Contracts.Contains(PrimaryContractType)
         && d.ImplementationName == i.Descriptor.ImplementationName);

        if (descriptor != null)
        {
            ServiceFactoryState.RemoveDescriptor(descriptor);

            var old = Instantiations.FirstOrDefault(
                x => x.Descriptor.Contracts.Contains(PrimaryContractType)
                  && x.Descriptor.ImplementationName == i.Descriptor.ImplementationName
                  );

            if (old != null)
                ServiceFactoryState.RemoveInstantiation(old);
        }

        InjectService(PrimaryContractType, i);
    }

    void RegisterRegistrar()
    {
        var sd = AssemblyRegistar.ServiceDescriptor;
        ServiceFactoryState.AddDescriptor(sd);
        ServiceFactoryState.AddInstantiation(new ServiceInstantiation<IAssemblyRegistrar>(sd, new AssemblyRegistar(this)));
    }

    void RegisterAssemblies(params Assembly[] assemblies)
    {
        RegisterRegistrar();
        AssemblyRegistrar.RegisterAssemblies(assemblies);
    }

    void RegisterAssemblyServices()
    {

        var types = AssemblyRegistrar.GetAssemblyTypes();
        var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
        var set1 = from t in types
                   where !t.IsAbstract && t.IsSubclassOf(typeof(ApplicationService)) && !t.IsGenericType
                   let descriptor = t.GetProperty(nameof(IApplicationService.ServiceDescriptor), flags)
                   select (ServiceDescriptor)descriptor.GetValue(null);

        ServiceFactoryState.AddDescriptors(set1);
        var set2 = from t in types
                   let attribs = t.GetCustomAttributes<ServiceAttribute>()
                   where attribs.Any()
                   let contracts = attribs.SelectMany(x => x.ContractTypes).ToArray()
                   let iname = attribs.First().ImplementationName ?? DefaultImplementationName
                   select new ServiceDescriptor(t, iname, contracts);

        ServiceFactoryState.AddDescriptors(set2);

        
        this.Resolvers.AddRange(dict(from d in Descriptors
                              where d.SupportsContract<IDependencyResolver>()
                              let resolver = (IDependencyResolver)Activator.CreateInstance(d.ImplementationType, this)
                              from contract in resolver.GetResolvableConracts(AssemblyRegistrar)
                              select (contract, resolver)));

    }

    public T Service<T>()
        => TryAcquireService<T>(DefaultImplementationName).MapValueOrDefault(x => x.Instance);

    public IConfigurationProvider ConfigurationProvider
       => Service<IConfigurationProvider>();

    public string EnvironmentName
        => ConfigurationProvider?.EnvironmentName ?? String.Empty;

    public string ComponentName
        => ConfigurationProvider?.ComponentName ?? String.Empty;

    public bool IsServiceProvided<T>(string ImplementationName)
        => Descriptors.Any(d =>
                d.Contracts.Contains(typeof(T))
             && d.ImplementationName == ImplementationName);

    public T Service<T>(string ImplementationName)
        => TryAcquireService<T>(ImplementationName).MapValueOrDefault(x => x.Instance);

    public Option<T> TryGetService<T>()
        => TryAcquireService<T>(DefaultImplementationName).Map(x => x.Instance);

    public Option<T> TryGetService<T>(string ImplementationName)
        => TryAcquireService<T>(ImplementationName).Map(x => x.Instance);

    public T Settings<T>()
         => (T)Activator.CreateInstance(typeof(T), Service<IConfigurationProvider>());

    public T Setting<T>(string SettingName)
        => ConfigurationProvider.GetSetting<T>(SettingName);


    public void PostMessage(IAppMessage message)
    {
        if (Broker == null)
            throw new ArgumentNullException("No broker is specified");
        Broker.Route(message);
    }

    public IReadOnlyList<ServiceDescriptor> ProvidedServices
        => Descriptors.ToReadOnlyList();

    void Dispose()
    {
        var final = MutableList.Create<IDisposable>();
        foreach (var i in Instantiations)
        {
            try
            {
                (i.Instance as IDisposable)?.Dispose();
            }
            catch (Exception e)
            {
                PostMessage(AppMessage.Error(e));
            }
        }

        foreach (var f in final)
        {
            try
            {
                f.Dispose();
            }
            catch (Exception)
            {
                //Not much can be done at this point; need to emit to a fail-safe log
            }
        }
    }

    void InjectService<C>(object service, string ImplementationName = null)
        => InjectService(typeof(C),
            ServiceInstantiation.FromInstance<C>(service, ImplementationName ?? DefaultImplementationName));

    public Option<T> TryGetValue<T>(string name)
        => this.Service<IValueService>().TryGetValue<T>(name);

    void IMutableContext.InjectService<C>(object service, string ImplementationName)
        => InjectService<C>(service, ImplementationName);

    void IMutableContext.InjectValue(string name, object value)
        => ((ValueService)this.Service<IValueService>()).SetValue(name, value);

    void IMutableContext.ReplaceService<C>(object service, string ImplementationName)
        => ReplaceService(typeof(C),
                ServiceInstantiation.FromInstance<C>(service, ImplementationName ?? DefaultImplementationName));

    void IMutableContext.Register(ServiceDescriptor descriptor)
        => AddDescriptor(descriptor);

    void IDisposable.Dispose()
    { }                         
}

