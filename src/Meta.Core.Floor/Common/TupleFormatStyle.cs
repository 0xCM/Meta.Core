//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

/// <summary>
/// Defines the available tuple format styles that may
/// be applied when representing a tuple as text
/// </summary>
public enum TupleFormatStyle
{
    /// <summary>
    /// Indicates a tuple text representation of the form "(x1,...xn)"
    /// </summary>
    Coordinate,

    /// <summary>
    /// Indicates a tuple text representation of the form "[x1,...xn]"
    /// </summary>
    List,

    /// <summary>
    /// Indicates a tuple text representation of the form "{x1,...xn}"
    /// </summary>
    Record
}
