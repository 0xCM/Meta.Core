//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;


/// <summary>
/// Applied to a component setting accessor to describe the setting
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ComponentSettingAttribute : Attribute
{
    private readonly string documentation;

    /// <summary>
    /// Initializes a new <see cref="ComponentSettingAttribute"/> instance
    /// </summary>
    /// <param name="documentation"></param>
    public ComponentSettingAttribute(string documentation)
    {
        this.documentation = documentation;
    }

    /// <summary>
    /// Gets the specified setting documentation
    /// </summary>
    public string Documentation
        => documentation;
}

