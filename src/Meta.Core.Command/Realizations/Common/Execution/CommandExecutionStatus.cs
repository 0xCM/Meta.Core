//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Enumerates the potential command execution states
/// </summary>
public enum CommandExecutionStatus
{
    /// <summary>
    /// Indicates the lack of status
    /// </summary>
    None = 0,

    /// <summary>
    /// The command has been submitted and is ready for dispatch
    /// </summary>
    Submitted = 1,

    /// <summary>
    /// The command is on route to, or in the embrace of, an executor
    /// </summary>
    Dispatched = 2,

    /// <summary>
    /// The command has completed execution
    /// </summary>
    Completed = 3
}
