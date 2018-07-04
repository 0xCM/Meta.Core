//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using static metacore;

    class SqlProxyAttributionIndex
    {
        IDictionary<SqlProxyKind, IReadOnlyList<SqlProxyAttribution>> Lookup { get; }

        internal SqlProxyAttributionIndex(Assembly a)
        {
            this.Lookup = (from x in a.GetTypes()
                           let attrib = x.GetCustomAttribute<SqlProxyAttribute>()
                           where attrib != null
                           let attribution = new SqlProxyAttribution(x, attrib)
                           group attribution by attribution.Attribute.ProxyKind into g
                           select g
              ).ToDictionary(x => x.Key, x => x.Select(y => y).ToReadOnlyList()); ;
        }


        public IReadOnlyList<SqlProxyAttribution> Find(SqlProxyKind Kind)
        {            
            if (Lookup.ContainsKey(Kind))         
                return Lookup[Kind];                
            else
                return new SqlProxyAttribution[] { };            
        }           
    }
}