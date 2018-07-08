//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
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

