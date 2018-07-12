//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;

public interface IApplicationContext : IDisposable
{
    T Service<T>();

    T Service<T>(string ImplementationName);

    Option<T> TryGetService<T>();

    Option<object> TryGetService(ServiceIdentifier Identifier);


    Option<T> TryGetService<T>(string ImplementationName);

    T Setting<T>(string SettingName);

    T Settings<T>();

    void PostMessage(IAppMessage message);

    IConfigurationProvider ConfigurationProvider { get; }

    bool IsServiceProvided<T>(string ImplementationName = "Default");

    string EnvironmentName { get; }

    string ComponentName { get; }

    IReadOnlyList<ServiceDescriptor> ProvidedServices { get; }


    Option<T> TryGetValue<T>(string name);
}

