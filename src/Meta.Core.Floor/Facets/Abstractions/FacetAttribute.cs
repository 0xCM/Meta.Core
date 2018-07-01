//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
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

