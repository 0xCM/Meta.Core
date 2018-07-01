//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;

/// <summary>
/// Defines extensions for working with embedded resources
/// </summary>
public static class ResourceExtensions
{
    public static IReadOnlyDictionary<string, string> IndexTextResources(this ResourceSet src)
    {
        var index = new Dictionary<string, string>();
        foreach (DictionaryEntry item in src)
        {
            if (item.Value is string)
                index[(string)item.Key] = item.Value as string;
        }
        return index;

    }
}
