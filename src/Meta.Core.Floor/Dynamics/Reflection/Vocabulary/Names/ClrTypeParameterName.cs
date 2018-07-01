//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


public sealed class ClrTypeParameterName : ClrElementName<ClrTypeParameterName>
{
    /// <summary>
    /// Defines the canonical empty type parameter name
    /// </summary>
    public static readonly ClrTypeParameterName Empty 
        = new ClrTypeParameterName(string.Empty);

    public static implicit operator ClrTypeParameterName(string x)
        => new ClrTypeParameterName(x);

    public ClrTypeParameterName(ClrItemIdentifier Text)
        : base(Text)
    { }

}
