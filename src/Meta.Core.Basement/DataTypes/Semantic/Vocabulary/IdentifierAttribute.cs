//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// Assigns an identifier (relative to some context) to a code element
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple =false)]
public sealed class IdentifierAttribute : Attribute
{
   

    public IdentifierAttribute(string Identifier)
    {
        this.Identifier = Identifier;
    }

    public string Identifier { get; }

    public override string ToString()
        => Identifier;
}



