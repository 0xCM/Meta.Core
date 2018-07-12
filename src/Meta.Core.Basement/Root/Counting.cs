//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------


public enum Multiplicity
{
    Unknown = 0,
    ZeroOrOne,
    One,
    MoreThanOne
}

/// <summary>
/// Defines computationally relevant cardinality classifications
/// </summary>
/// <remarks>
/// Cardinality, by definition, is the number of elmenents in a set. 
/// This enumeration defines relevant cardinatly classifications
/// </remarks>
public enum Cardinality
{
    /// <summary>
    /// Specifies that a set has an unknown number of elements
    /// </summary>
    Unknown,

    /// <summary>
    /// Specifies that a set has no elements and is thus empty
    /// </summary>
    Zero,

    /// <summary>
    /// Specifies than a set has a finite number of elements
    /// </summary>
    Finite,

    /// <summary>
    /// Specifies that a set has an infinite number of elements
    /// </summary>
    Infinite
}

