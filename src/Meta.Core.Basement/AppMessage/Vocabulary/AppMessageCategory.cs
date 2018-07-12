//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

/// <summary>
/// Classifies an application message
/// </summary>
public enum AppMessageCategory : byte
{
    /// <summary>
    /// Notification is unclassified
    /// </summary>
    None = 0,

    /// <summary>
    /// Notification signifies the beginning of an activity
    /// </summary>
    Start = 1,

    /// <summary>
    /// Notification signifies the completion of an activity
    /// </summary>
    Finish = 2,

}
