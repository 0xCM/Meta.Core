//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;

/// <summary>
/// Captures process exeucution messages
/// </summary>
public class CommandProcessExecutionLog
{
    public CommandProcessExecutionLog(bool Executed = true, IAppMessage Message = null)
    {
        this.ErrorMessages = MutableList.Create<string>();
        this.StatusMessages = MutableList.Create<string>();
        this.Executed = Executed;
        this.AppMessage = Message ?? global::AppMessage.Empty;
    }

    /// <summary>
    /// Specifies the process exist code
    /// </summary>
    public int? ExitCode { get; set; }

    /// <summary>
    /// Specifies the messages that were written to the standard output stream
    /// </summary>
    public MutableList<string> ErrorMessages { get; }

    /// <summary>
    /// Specifies the messages that were written to the error output stream
    /// </summary>
    public MutableList<string> StatusMessages { get; }

    /// <summary>
    /// Indicates whether the tool was executed
    /// </summary>
    public bool Executed {get;}

    /// <summary>
    /// Specifies a summary message
    /// </summary>
    public IAppMessage AppMessage { get; }

    /// <summary>
    /// Retrieves the union of status and error messages
    /// </summary>
    public IEnumerable<string> ExecutionMessages 
        => StatusMessages.Union(ErrorMessages);
}
