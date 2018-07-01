//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Describes a <see cref="ApplicationMessage"/>
/// </summary>
public class ApplicationMessageAttribute : Attribute
{

    public ApplicationMessageAttribute(string DisplayName)
    {
        this.DisplayName = DisplayName;
        this.Description = String.Empty;
        this.Category = ApplicationMessageCategory.None;
    }

    public ApplicationMessageAttribute(string DisplayName, string Description)
    {
        this.DisplayName = DisplayName;
        this.Description = Description;
        this.Category = ApplicationMessageCategory.None;
    }

    public ApplicationMessageAttribute(string DisplayName, string Description, ApplicationMessageCategory Category)
    {
        this.DisplayName = DisplayName;
        this.Description = Description;
        this.Category = Category;
    }

    public ApplicationMessageAttribute(ApplicationMessageCategory Category)
    {
        this.DisplayName = String.Empty;
        this.Description = String.Empty;
        this.Category = Category;
    }

    public string DisplayName { get; }

    public string Description { get; }

    /// <summary>
    /// Specifies the category to which the message belongs
    /// </summary>
    public ApplicationMessageCategory Category { get; set; }
}

