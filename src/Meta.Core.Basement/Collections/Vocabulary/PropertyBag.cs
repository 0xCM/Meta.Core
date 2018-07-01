//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using static minicore;
    
/// <summary>
/// Defines an immutable key-value lookup
/// </summary>
public sealed class PropertyBag 
{
    IReadOnlyDictionary<string, object> Properties { get; }

    public PropertyBag(IReadOnlyDictionary<string,object> properties)
    {
        if (properties.Values.Any(p => p is null))
            throw new ArgumentNullException("Property values cannot be null");
        this.Properties = properties;
    }

    public PropertyBag(params (string Key,object Value)[] properties)
        : this(dict(properties))
    { }

    public PropertyBag(IEnumerable<(string Key,object Value)> properties)
        : this(dict(properties))
    {

    }

    /// <summary>
    /// Initializes a new <see cref="PropertyBag"/> instance from the public properties on a specified object
    /// </summary>
    /// <param name="src">The source of the properties</param>
    public PropertyBag(object src)
        => Properties = dict(src.GetType().GetProperties()
                .Select(p => (p.Name, p.GetValue(src))));                

    public Option<object> TryFindValue(string name) 
        => Properties.TryFind(name);

    public Option<T> TryFindValue<T>(string name)
        => Properties.TryFind(name).Map(v => convert<T>(v));
            
    /// <summary>
    /// Finds the identified properties
    /// </summary>
    /// <param name="names">The names of the properties to find</param>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<string, object>> FindProperties(params string[] names) 
        => Properties.Where(x => names.Contains(x.Key));

    /// <summary>
    /// Finds the identified properties
    /// </summary>
    /// <param name="names">The names of the properties to find</param>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<string, object>> FindProperties(IEnumerable<string> names) 
        => Properties.Where(x => names.Contains(x.Key));

    public IReadOnlyDictionary<string, object> ToDictionary()
        => Properties;

}

