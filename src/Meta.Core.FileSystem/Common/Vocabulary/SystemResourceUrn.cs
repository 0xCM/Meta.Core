using System;

public sealed class SystemResourceUrn : SystemResourceName<SystemResourceUrn>
{
    
    public static implicit operator RelativePath(SystemResourceUrn urn)
        => RelativePath.FromComponents(urn.NonSchemeComponents);

    public static SystemResourceUrn FromComponents(SystemResourceScheme scheme, params object[] Components)
        => new SystemResourceUrn(scheme, Components);

    protected override SystemResourceUrn New(string Identifier)
        => new SystemResourceUrn(SystemResourceScheme.Default, Identifier);

    protected override SystemResourceUrn New(SystemResourceScheme scheme, string EverythingButScheme)
        => new SystemResourceUrn(scheme, EverythingButScheme);


    public static SystemResourceUrn operator + (SystemResourceUrn urn, string filename)
        => new SystemResourceUrn(urn.Scheme, $"/{urn.EverythingButScheme}/{filename}");

    
    public SystemResourceUrn(SystemResourceScheme scheme, params object[] Components)
        : base(scheme, Components)
    {

    }

    public SystemResourceUrn(SystemResourceScheme scheme, string Identifier)
        : base(scheme, Identifier)
    {


    }

    public override string ToString()
        => new Uri($"{Scheme}:/{EverythingButScheme}").ToString();

}

