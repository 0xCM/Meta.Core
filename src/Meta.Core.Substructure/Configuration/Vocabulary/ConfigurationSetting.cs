//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

public class ConfigurationSetting
{

    public ConfigurationSetting()
    {
        this.Name = String.Empty; ;
        this.Value = String.Empty; ;
        this.Description = String.Empty;
    }
    public ConfigurationSetting(string Name, object Value, string Description)
    {
        this.Description = Description;
        this.Value = Value;
        this.Name = Name;
    }

    public string Name { get; set; }

    public object Value { get; set; }

    public string Description { get; set; }
}

public sealed class ConfigurationSetting<T> : ConfigurationSetting
{
    public static implicit operator T(ConfigurationSetting<T> x) => x.Value;

    public ConfigurationSetting()
    {

    }

    public ConfigurationSetting(string Name, T Value, string Description)
        : base(Name, Value, Description)
    {

    }

    public new T Value
        => (T)base.Value;
}

