//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Meta.Core;
   
    

    /// <summary>
    /// Creates an index that correlates parameter specifications and representations
    /// </summary>
    public class HttpParameterIndex
    {
        readonly IReadOnlyDictionary<string, ReadOnlyList<HttpParameterSpec>> Parameters;

        HttpParameterIndex(IEnumerable<HttpParameterSpec> parameters)
        {
            this.Parameters = (from p in parameters
                     group p by p.EntityName into g
                     let key = g.Key
                     let specs = g.Select(x => x)
                     select (key, specs.ToReadOnlyList())).ToDictionary(x => x.key, x => x.Item2);
                                
        }

        public static HttpParameterIndex Create(IEnumerable<HttpParameterSpec> parameters) 
            => new HttpParameterIndex(parameters);


        public Option<HttpParameterSpec> TryFindByParameterName(string entityName, string parameterName)
            => (from p in Parameters.TryFind(entityName)
               where p.ParameterName == parameterName
               select p).Items().FirstOrDefault();

        public Option<HttpParameterSpec> TryFindByAttributeName(string entityName, string attributeName)
            => (from p in Parameters.TryFind(entityName)
                where p.AttributeName == attributeName
                select p).Items().FirstOrDefault();

        /// <summary>
        /// Looks for a parameter via an attribute selection expression
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="selector">The attribute selector</param>
        /// <returns></returns>
        public Option<HttpParameterSpec> TryFindParameter<T>(Expression<Func<T, object>> selector) 
            => TryFindByAttributeName(typeof(T).Name, selector.GetMember().Name);


    }
}
