//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Indicates the the default access level, relative to some context, should be applied
/// </summary>
public enum ClrAccessKind
{
    Default,
    /// <summary>
    /// Indicates that access to the target is unrestricted
    /// </summary>
    Public,
    /// <summary>
    /// Indicates that the target is accessible only to subclasses (Not supported in F#)
    /// </summary>
    Protected,
    /// <summary>
    /// Indicates that the target is only accessible within its defining scope
    /// </summary>
    Private,
    /// <summary>
    /// Indicates that the target is only accessible within the assembly within which it is defined
    /// </summary>
    Internal,
    /// <summary>
    /// Indicates that the target is accessible to subclasses and the defining assembly
    /// Not supported in F#; supported in C# using the protected internal modifiers
    /// </summary>
    ProtectedOrInternal,
    /// <summary>
    /// Indicates that the target is accessible to subclasses in the defining assembly
    /// Not supported in C# or F#
    /// </summary>
    ProtectedAndInternal
}


