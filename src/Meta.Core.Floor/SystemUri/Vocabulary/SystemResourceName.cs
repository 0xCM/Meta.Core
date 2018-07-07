//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using Meta.Core;
using static metacore;

public abstract class SystemResourceName<X> : SemanticIdentifier<X, (SystemResourceScheme scheme, string other)>
    where X : SystemResourceName<X>
{

    protected const string path_separator = "/";
    protected const string scheme_separator = "://";
    
    public SystemResourceScheme Scheme
        => Identifier.scheme;

    public string EverythingButScheme
        => Identifier.other;

    protected static (SystemResourceScheme, string) Join(SystemResourceScheme scheme, params object[] components)
    {
        if (components.Length == 0)
            return (scheme, String.Empty);
        
        return  (scheme, path_separator + string.Join(path_separator, components));
    }

    SystemResourceName()
        : base(("system",String.Empty))
    { }

    public SystemResourceName(SystemResourceScheme scheme, params object[] Components)
        : base(Join(scheme, Components))
    {

    }

   

    protected SystemResourceName(SystemResourceScheme scheme, string EverythingButScheme)
        : base((scheme, EverythingButScheme))
    {

    }

    public string[] NonSchemeComponents
        => EverythingButScheme.Split(new string[] { path_separator }, StringSplitOptions.RemoveEmptyEntries);


    public X Prepend(SystemResourceScheme scheme)
        => New(scheme, EverythingButScheme);

    public X Remove(X y)
        => New(this.IdentifierText.Replace(y.IdentifierText, String.Empty));

    public Option<X> ParentName
        => NonSchemeComponents.Length > 1 
        ? New(Scheme,  Join(Scheme, NonSchemeComponents.Subset(0, NonSchemeComponents.Length - 2)).Item2)
        : none<X>();

    static IEnumerable<X> Ancestors(X descendent)
    {
        var ancestor = descendent.ParentName;
        while(ancestor.Exists)
        {
            yield return ~ ancestor;
            ancestor.OnSome(a => ancestor = a.ParentName);
        }
    }

    public bool IsRoot
        => ReferenceEquals(this, Empty) || ParentName.IsNone();

    public Meta.Core.Lst<X> Lineage
        => list(Ancestors((X)this).Reverse().Concat(stream( (X)this)));

    protected abstract X New(SystemResourceScheme scheme, string EverythingButScheme);
}


public sealed class SystemResourceName : SystemResourceName<SystemResourceName>
{

    public static implicit operator Uri(SystemResourceName n)
        => new Uri($"{n.Scheme}:/{n.EverythingButScheme}");

    public static SystemResourceName FromComponents(SystemResourceScheme scheme, params object[] Components)
        => new SystemResourceName(scheme, Components);

    protected override SystemResourceName New(string IdentifierText)
        => new SystemResourceName(IdentifierText);

    public static SystemResourceName operator +(SystemResourceScheme x, SystemResourceName y)
        => y.Prepend(x);


    protected override SystemResourceName New(SystemResourceScheme scheme, string EverythingButScheme)
        => new SystemResourceName(scheme, EverythingButScheme);

    public SystemResourceName(SystemResourceScheme scheme, params object[] Components)
        : base(scheme, Components)
    {

    }


    public SystemResourceName(SystemResourceScheme scheme, string path)
        : base(scheme, path)
    {

    }



    
}

