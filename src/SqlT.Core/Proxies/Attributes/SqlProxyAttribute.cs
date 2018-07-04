//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Base type for proxy attributes
    /// </summary>
    public abstract class SqlProxyAttribute : Attribute
    {
        readonly Dictionary<string, object> index = new Dictionary<string, object>();
        
        /// <summary>
        /// Gets/Sets the value of a facet
        /// </summary>
        /// <param name="name">The name of the facet</param>
        /// <returns></returns>
        protected object this[string name]
        {
            get
            {
                return index.ContainsKey(name) ? index[name] : null;
            }
            set
            {
                index[name] = value;
            }
        }

        protected SqlProxyAttribute()
        {
            
        }

        protected T GetFacetValue<T>(string name) 
            => (T)this[name];

        protected void SetFacetValue<T>(string name, T value) 
            => this[name] = value;

        public IReadOnlyDictionary<string, object> FacetValues { get; }
            

        public abstract SqlProxyKind ProxyKind { get; }
    }
}