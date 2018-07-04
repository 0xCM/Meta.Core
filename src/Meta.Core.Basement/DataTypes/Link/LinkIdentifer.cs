//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using static minicore;

using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// Assigns identity to link values
/// </summary>
public class LinkIdentifier : SemanticIdentifier<LinkIdentifier, string>
{
    static string Format(IEnumerable<object> components)
        => string.Join(Symbol.flowsto.Represenation, components.ToArray());

    public static explicit operator LinkIdentifier((object p1, object p2) parts)
        => new LinkIdentifier(array(parts.p1, parts.p2));

    /// <summary>
    /// Canonical <see cref="LinkIdentifier"/> parser
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    //public static new LinkIdentifier Parse(string text)
    //{
    //    var parts = text.Split(Symbol.flowsto.Represenation, StringSplitOptions.None);
    //    return parts.Length == 0 ? Empty : new LinkIdentifier(parts);        
    //}

    public static implicit operator LinkIdentifier(string x)
        => new LinkIdentifier(x);

    protected override LinkIdentifier New(string IdentifierText)
        => new LinkIdentifier(IdentifierText);

    LinkIdentifier()
        : base(string.Empty)
    {

    }

    LinkIdentifier(IReadOnlyList<object> components)
        : base(Format(components))
    {

    }

    public LinkIdentifier(string name)
        : base(name)
    {

    }

    public LinkIdentifier(string Source, string Target)
        : base(Format(stream(Source,Target)))
    {

    }

}


