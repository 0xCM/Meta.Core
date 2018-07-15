//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
