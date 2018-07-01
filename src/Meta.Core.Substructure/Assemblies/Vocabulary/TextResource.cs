//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines a text resource
/// </summary>
public class TextResource : ValueObject<TextResource>
{
    public TextResource(string Name, string Text)
    {
        this.Name = Name;
        this.Text = Text;
    }

    /// <summary>
    /// The resource name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The resource value
    /// </summary>
    public string Text { get; }

    public override string ToString()
        => Text;
}
