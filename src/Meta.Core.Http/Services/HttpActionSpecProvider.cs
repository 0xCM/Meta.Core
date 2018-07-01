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
    using System.Collections;

    using static metacore;

    /// <summary>
    /// Mediates access to <see cref="HttpActionSpec"/> definitions and facilitates their specification
    /// </summary>
    /// <typeparam name="TContract">The type service contract for which behavior is being specified</typeparam>
    public class HttpActionSpecProvider<TContract> : IEnumerable<HttpActionSpec>
    {
        public static HttpActionSpecProvider<TContract> Create() 
            => new HttpActionSpecProvider<TContract>();

        readonly List<HttpActionSpec> actions;

        HttpActionSpecProvider()
        {
            this.actions = new List<HttpActionSpec>();
        }

        IEnumerator<HttpActionSpec> IEnumerable<HttpActionSpec>.GetEnumerator()
         => ((IEnumerable<HttpActionSpec>)actions).GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable<HttpActionSpec>)actions).GetEnumerator();
        
        /// <summary>
        /// Specifies an HTTP POST action
        /// </summary>
        /// <param name="selector">Selects the operation being described</param>
        /// <param name="path">The relative path to which the POST will be directed</param>
        /// <param name="contentType">The type of content being transmitted</param>
        /// <returns></returns>
        public HttpActionSpecProvider<TContract> Post(Expression<Func<TContract, string>> selector, string path, HttpMediaType contentType)
        {
            var name = cast<string>(cast<ConstantExpression>(selector.Body).Value);
            actions.Add(new HttpActionSpec(name, HttpMethods.POST,  path, contentType));
            return this;
        }

        /// <summary>
        /// Specifies an HTTP DELETE action
        /// </summary>
        /// <param name="selector">Selects the operation being described</param>
        /// <param name="path">The relative path to which the POST will be directed</param>
        /// <param name="contentType">The type of content being transmitted</param>
        /// <returns></returns>
        public HttpActionSpecProvider<TContract> Delete(Expression<Func<TContract, string>> selector, string path, HttpMediaType contentType)
        {
            var name = cast<string>(cast<ConstantExpression>(selector.Body).Value);
            actions.Add(new HttpActionSpec(name, HttpMethods.DELETE, path, contentType));
            return this;
        }


    }
}
