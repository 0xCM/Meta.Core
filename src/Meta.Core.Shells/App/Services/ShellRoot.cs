//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public sealed class ShellRoot : ICompositionRoot
    {
        public ShellRoot(IAssemblyDesignator AppAssembly, IShellConsole Shell, IApplicationContext Context)
        {
            this.AppAssembly = AppAssembly;
            this.Shell = Shell;
            this.Context = Context;

        }

        public IShellConsole Shell { get; }

        public IAssemblyDesignator AppAssembly { get; }

        public IApplicationContext Context { get; }

        public T Service<T>()
            => Context.Service<T>();

        public T Service<T>(string ImplementationName)
            => Context.Service<T>(ImplementationName);

        public T Settings<T>()
            => Context.Settings<T>();


        void Notify(IApplicationMessage message)
            => Service<IMessageBroker>().Route(message);

        void Status(string message)
            => Notify(ApplicationMessage.Inform(message));



        void ICompositionRoot.Initialized(IApplicationContext context)
        { }


        public void Dispose()
        {
            Context.Dispose();
        }


        #region Delegation
        public IConfigurationProvider ConfigurationProvider
            => Context.ConfigurationProvider;

        public Option<T> TryGetValue<T>(string name)
            => Context.Service<IValueService>().TryGetValue<T>(name);

        public string EnvironmentName
            => Context.EnvironmentName;

        public string ComponentName
            => Context.ComponentName;

        public IReadOnlyList<ServiceDescriptor> ProvidedServices
            => Context.ProvidedServices;

        public bool IsServiceProvided<T>(string ImplementationName)
            => Context.IsServiceProvided<T>(ImplementationName);

        public void PostMessage(IApplicationMessage message)
            => Context.PostMessage(message);


        public T Setting<T>(string Name)
            => Context.Setting<T>(Name);


        public Option<T> TryGetService<T>()
            => Context.TryGetService<T>();

        public Option<T>  TryGetService<T>(string ImplementationName)
            => Context.TryGetService<T>(ImplementationName);

        public Option<object> TryGetService(ServiceIdentifier Identifier)
            => Context.TryGetService(Identifier);
        #endregion
    }
}
    