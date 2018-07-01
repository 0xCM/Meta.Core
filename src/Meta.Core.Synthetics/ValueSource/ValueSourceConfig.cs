//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
   
    using static metacore;

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
