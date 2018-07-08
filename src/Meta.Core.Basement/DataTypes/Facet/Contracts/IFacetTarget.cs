//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public interface IFacetTarget
{
    IEnumerable<IFacet> Facets { get; }

    bool HasFacet(IFacet Facet);

    void SetFacet(IFacet Facet);

    IFacet GetFacet(string FacetName);

    IFacet<V> GetFacet<V>(string FacetName);

}

