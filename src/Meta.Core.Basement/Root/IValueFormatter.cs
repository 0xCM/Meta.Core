//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Defines contract for producing a string from a value
    /// </summary>
    public interface IValueFormatter<in V>
    {
        string Format(V value);
    }

    public delegate string ValueFormatter<in V>(V value);
}