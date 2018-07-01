//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Minimal delimited text format specification
/// </summary>
public class DelimitedTextDescription
{
    public DelimitedTextDescription(bool HasHeader = true, char? Delimiter = null)
    {
        this.HasHeader = HasHeader;
        this.Delimiter = Delimiter ?? ',';
    }

    /// <summary>
    /// Indicates whether a header is present
    /// </summary>
    public bool HasHeader { get; }

    /// <summary>
    /// Specifies the delimting character
    /// </summary>
    public char Delimiter { get; }

    public override string ToString()
        => $"nameof{HasHeader} = {HasHeader}, Delimiter={Delimiter}";
}


