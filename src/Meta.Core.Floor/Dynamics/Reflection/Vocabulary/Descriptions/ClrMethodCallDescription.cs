//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System.Linq;
using System.Collections.Generic;

using static metacore;

/// <summary>
/// Describes a method invocation
/// </summary>
public class ClrMethodCallDescription
{
    public ClrMethodCallDescription(ClrMethodDescription Operation, ReadOnlyList<ClrMethodArgumentDescription> Arguments)
    {
        this.Operation = Operation;
        this.Arguments = Arguments;
    }

    /// <summary>
    /// The operation to be invoked
    /// </summary>
    public ClrMethodDescription Operation { get; }

    /// <summary>
    /// The arguments to supply to the operation upon invocation
    /// </summary>
    public ReadOnlyList<ClrMethodArgumentDescription> Arguments { get; }

    public override string ToString()
        => $"{Operation}({Arguments})";
}



