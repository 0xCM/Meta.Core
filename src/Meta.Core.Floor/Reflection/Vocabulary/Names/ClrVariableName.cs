//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Specifies the name of a variable
/// </summary>
public sealed class ClrVariableName : ClrElementName<ClrVariableName>
{
    /// <summary>
    /// Defines the canonical empty type parameter name
    /// </summary>
    public static readonly ClrVariableName Empty
        = new ClrVariableName();

    public static implicit operator ClrVariableName(string x)
        => new ClrVariableName(x);

    ClrVariableName()
    { }


    public ClrVariableName(ClrItemIdentifier identifier)
        : base(identifier)
    { }

}
