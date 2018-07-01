//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IFacetSet
{
    Option<IFacet> TryFind(string Name);

    Option<IFacet<V>> TryFind<V>(string Name, bool AllowConversion = true);

    IFacet<V> FindOrElse<V>(string Name, V Else, bool AllowConversion = true);

    V FindValueOrElse<V>(string Name, V Else, bool AllowConversion = true);

    IEnumerable<IFacet> Members { get; }  
}

