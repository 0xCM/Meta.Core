//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Contract for any optional value
/// </summary>
public interface IOption
{
    /// <summary>
    /// The encapsualted value, if any
    /// </summary>
    object Value { get; }

    /// <summary>
    /// True if a value does exists, false otherwise
    /// </summary>
    bool IsSome { get; }

    /// <summary>
    /// True if a value does not exist, false otherwise
    /// </summary>
    bool IsNone { get; }

    /// <summary>
    /// Message that explains why there is or is not a value present
    /// </summary>
    IAppMessage Message { get; }

    /// <summary>
    /// The type of the encapsulated value, if present
    /// </summary>
    Type ValueType { get; }
}

public interface IOption<T> : IOption
{
    /// <summary>
    /// The encapsualted value, if any
    /// </summary>
    new T Value { get; }
}
