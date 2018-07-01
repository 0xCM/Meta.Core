//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public class FacetConverter<TDst> : IFacet<TDst>
{
   IFacet Source { get; }
   Func<object, TDst> Transformer { get; }

    public FacetConverter(IFacet Source, Func<object, TDst> Transformer = null)
    {
        this.Source = Source;
        this.Transformer = Transformer ?? (s => (TDst)Convert.ChangeType(s, typeof(TDst)));
    }

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

