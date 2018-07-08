//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public class FacetConverter<TDst> : IFacet<TDst>
{

    public FacetConverter(IFacet Source, Func<object, TDst> Transformer = null)
    {
        this.Source = Source;
        this.Transformer = Transformer ?? (s => (TDst)Convert.ChangeType(s, typeof(TDst)));
    }
    IFacet Source { get; }

    Func<object, TDst> Transformer { get; }

    string IFacet.FacetName
        => Source.FacetName;

    TDst IFacet<TDst>.FacetValue
        => Transformer(Source.FacetValue);

    object IFacet.FacetValue
        => Transformer(Source.FacetValue);

}

public static class FacetConverter
{
    public static IFacet<TDst> Create<TDst>(IFacet src, Func<object, TDst> Transformer = null)
        => new FacetConverter<TDst>(src);
}

