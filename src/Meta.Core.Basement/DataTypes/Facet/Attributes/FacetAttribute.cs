//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using System;
using System.Linq;

/// <summary>
/// Base type for attributes that identify and describe a field or property of core type
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public abstract class FacetAttribute : Attribute
{
    public FacetAttribute(int index)
    {
        this.Index = index;
    }

    public int Index { get; set; }

    public string Name { get; set; }

    public bool Required { get; set; }

    public string Documentation { get; set; }
}

