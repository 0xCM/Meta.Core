//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public sealed class SystemResourceScheme : SemanticIdentifier<SystemResourceScheme, string>
{
    public static SystemResourceScheme Default = new SystemResourceScheme();

    public static implicit operator SystemResourceScheme(string name)
        => new SystemResourceScheme(name);

    protected override SystemResourceScheme New(string Identifier)
        => new SystemResourceScheme(Identifier);

    SystemResourceScheme()
        : base("system")
    { }

    public SystemResourceScheme(string Identifier)

        : base(Identifier)
    { }

}
