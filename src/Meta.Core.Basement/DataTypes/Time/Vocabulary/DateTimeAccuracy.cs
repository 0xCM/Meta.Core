//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Classifies the precision with which <see cref="DateTime"/> value should be interpreted
/// </summary>
public enum DateTimeAccuracy
{
    /// <summary>
    /// Specifies that only the date part is meaningful
    /// </summary>
    Date,
    /// <summary>
    /// Specifies that the date and hour components are meaningful
    /// </summary>
    Hour,
    /// <summary>
    /// Specifies that the date, hour and minute components are meaningful
    /// </summary>
    Minute,
    /// <summary>
    /// Specifies that the date, hour, minute and second components are meaningful
    /// </summary>
    Second,
    /// <summary>
    /// Specifies that the time represented by a <see cref="DateTime"/> value 
    /// has millisecond accuracy
    /// </summary>
    Millisecond
}
