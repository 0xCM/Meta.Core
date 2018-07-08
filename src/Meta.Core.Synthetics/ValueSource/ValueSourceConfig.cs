//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
   
    /// <summary>
    /// Encapsulates value factory setting values
    /// </summary>
    public class ValueSourceConfig
    {
        public ValueSourceConfig()
        {
            Facets = new FacetSet();
        }

        public ValueSourceConfig(FacetSet set)
        {
            Facets = set;
        }


        public ValueSourceConfig(int seed)
        {
            this.Seed = seed;
        }

        public ValueSourceConfig(int? seed, params IFacet[] facets)
        {
            this.Seed = seed;
            this.Facets = new FacetSet(facets);
        }

        public IFacetSet Facets { get; }

        public int? Seed { get; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ValueGeneratorAttribute : Attribute
    {
                    
    }

}
