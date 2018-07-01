//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Represents an assembly's simple name
/// </summary>
public sealed class ClrSimpleAssemblyName : DomainPrimitive<ClrSimpleAssemblyName, string>
{
    public static ClrSimpleAssemblyName Parse(string Value)
        => new ClrSimpleAssemblyName(Value);

    public ClrSimpleAssemblyName(string Value)
        : base(Value)
    { }
}
