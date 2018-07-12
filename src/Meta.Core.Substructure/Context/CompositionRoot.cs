//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents the composition root in the context of the dependency injection pattern
/// </summary>
/// <typeparam name="TRoot">The specialized subtyped</typeparam>
public abstract class CompositionRoot<TRoot> : ICompositionRoot
    where TRoot : CompositionRoot<TRoot>, new()
{
    /// <summary>
    /// Provides access to the system console
    /// </summary>
    protected ISystemConsole AppConsole { get; } 
        = SystemConsole.Get();

    /// <summary>
    /// The backing context
    /// </summary>
    protected IApplicationContext Context { get; }


    /// <summary>
    /// Instantiations the root with a supplied context
    /// </summary>
    /// <param name="context">The content to be wrapped</param>
    protected CompositionRoot(IApplicationContext context)
    {
        this.Context = context;
        Initialized(this.Context);
    }

    /// <summary>
    /// Instantiates the root with a context provided by a factory/subclass 
    /// </summary>
    protected CompositionRoot()
    {
        Context = CreateContext();
        Initialized(Context);        
    }

    protected T Service<T>()
        => Context.Service<T>();

    protected T Service<T>(string ImplementationName)
        => Context.Service<T>(ImplementationName);

    protected T Settings<T>()
        => Context.Settings<T>();
   
    protected virtual AppMessageFormatter MessageFormatter
        => m => m.Format();

    protected virtual Action<IAppMessage> MessageObserver
        => m => AppConsole.Write(m, MessageFormatter);
  
    protected void Notify(IAppMessage message)
        => Service<IMessageBroker>().Route(message);

    protected void Status(string message)
        => Notify(AppMessage.Inform(message));

    protected IAssemblyDesignator AssemblyDesignator
        => typeof(TRoot).Assembly.GetRealizations<IAssemblyDesignator>()
                                 .SingleOrDefault()
                                 ?.CreateInstance<IAssemblyDesignator>();

    protected virtual IApplicationContext CreateContext()
        => ApplicationContext.Create(AssemblyDesignator?.ModuleDependencies);

    void ICompositionRoot.Initialized(IApplicationContext context)
        => Initialized(context);

    protected virtual void Initialized(IApplicationContext context)
    { }

    protected virtual void Dispose()
    {
        Context.Dispose();
    }

    void IDisposable.Dispose() 
        => Dispose();

    #region Delegation
    IConfigurationProvider IApplicationContext.ConfigurationProvider 
        => Context.ConfigurationProvider;

    Option<T> IApplicationContext.TryGetValue<T>(string name)
        => Context.Service<IValueService>().TryGetValue<T>(name);


    string IApplicationContext.EnvironmentName 
        => Context.EnvironmentName;

    string IApplicationContext.ComponentName
        => Context.ComponentName;

    IReadOnlyList<ServiceDescriptor> IApplicationContext.ProvidedServices 
        => Context.ProvidedServices;
       
    bool IApplicationContext.IsServiceProvided<T>(string ImplementationName) 
        => Context.IsServiceProvided<T>(ImplementationName);

    void IApplicationContext.PostMessage(IAppMessage message) 
        => Context.PostMessage(message);

    T IApplicationContext.Service<T>() 
        => Context.Service<T>();

    T IApplicationContext.Setting<T>(string Name)
        => Context.Setting<T>(Name);

    T IApplicationContext.Service<T>(string ImplementationName) 
        => Context.Service<T>(ImplementationName);


    T IApplicationContext.Settings<T>() 
        => Context.Settings<T>();

    Option<T> IApplicationContext.TryGetService<T>() 
        => Context.TryGetService<T>();

    Option<T> IApplicationContext.TryGetService<T>(string ImplementationName) 
        => Context.TryGetService<T>(ImplementationName);

    Option<object> IApplicationContext.TryGetService(ServiceIdentifier Identifier)
        => Context.TryGetService(Identifier);

    #endregion
}

