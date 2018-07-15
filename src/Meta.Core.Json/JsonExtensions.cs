//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Meta.Core;

using static metacore;

public static class ConfigurationStoreExtensions
{

    public static Json ToJson(this IEnumerable<NamedValue> NamedValues)
        => JsonServices.ToJson(JObject.FromObject(new
        {
            NamedValues
        }));

    public static void ExportComponentSettings(this IConfigurationStore store, string environment, string component, string path)
    {
        if (isBlank(environment) || isBlank(component))
            throw new ArgumentException("Both environment and component must be specified");

        var export = new ComponentConfigurationSet
        {
            Environment = environment,
            Component = component,
            Settings = store.GetComponentSettings(environment, component).ToList()
        };
        JsonServices.ToObjectFile(export, path);
    }

    public static void ImportComponentSettings(this IConfigurationStore store, string environment, string component, string path)
    {
        if (isBlank(environment) || isBlank(component))
            throw new ArgumentException("Both environment and component must be specified");

        var settings = JsonServices.FromObjectFile<ComponentConfigurationSet>(path).Settings;
        store.SaveComponentSettings(settings);

    }
}
