//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

public class RepresentationAttributeValue 
{

    /// <summary>
    /// Initializes a new <see cref="RepresentationAttributeValue"/> instance
    /// </summary>
    /// <param name="index">The peer-relative position of the attribute</param>
    /// <param name="name">The (semantic) name of the attribute</param>
    /// <param name="value">The attribute value</param>
    public RepresentationAttributeValue(int index, string name, object value)
    {
        this.Index = index;
        this.Name = name;
        this.Value = value;
    }


    /// <summary>
    /// Initializes a new <see cref="RepresentationAttributeValue"/> instance
    /// </summary>
    /// <param name="name">The (semantic) name of the attribute</param>
    /// <param name="value">The attribute value</param>
    public RepresentationAttributeValue(string name, object value)
    {
        this.Index = null;
        this.Name = name;
        this.Value = value;
    }

    /// <summary>
    /// The index of the parameter
    /// </summary>
    public int? Index { get; private set; }
        
    /// <summary>
    /// The name of the parameter
    /// </summary>
    public string Name { get; private set; }
        
    /// <summary>
    /// The value of the parameter
    /// </summary>
    public object Value { get; private set; }

    public override string ToString() => 
        $"{Name}, {Index}: {Value}";

    public override bool Equals(object other)
    {
        var _other = other as RepresentationAttributeValue;
        if (isNull(_other))
            return false;

        return this.Name == _other.Name 
            && this.Index == _other.Index 
            && Object.Equals(this.Value, _other.Value);            
    }

    public override int GetHashCode()
        => ToString().GetHashCode();
}

