//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Mediates access to <see cref="HttpParameterSpec"/> definitions and facilitates their specification
    /// via a fluent API pattern
    /// </summary>
    /// <typeparam name="T">The type that defines the attributes that will be bound to URI parameters</typeparam>
    public class HttpParameterSpecProvider<T> : IEnumerable<HttpParameterSpec>
    {
        public static HttpParameterSpecProvider<T> Create() 
            => new HttpParameterSpecProvider<T>();

        readonly string name;
        readonly List<HttpParameterSpec> parameters;

        HttpParameterSpecProvider()
        {
            this.parameters = new List<HttpParameterSpec>();
        }

        HttpParameterSpecProvider(IEnumerable<HttpParameterSpec> parameters)
            : this(String.Empty, parameters)
        {
            this.parameters = new List<HttpParameterSpec>(parameters);
        }

        HttpParameterSpecProvider(string name, IEnumerable<HttpParameterSpec> parameters )
        {
            this.name = name;
            this.parameters = new List<HttpParameterSpec>(parameters);
            this.parameters.Add(new HttpParameterSpec(typeof(T).Name, name, name));
        }

        public HttpParameterSpecProvider<T> Parameter<TResult>(
            Expression<Func<T, TResult>> selector, string name, string format = null)
        {
            parameters.Add(new HttpParameterSpec(typeof(T).Name, selector.GetMember().Name, name, format));
            return this;
        }

        /// <summary>
        /// Identifies an attribute with a URI parameter and optionally specifies the formatting convention
        /// to apply to the parameter when rendered
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector">Selects the attribute to bind to the identified parameter</param>
        /// <param name="name">The name of the URI parameter</param>
        /// <param name="format">An optional format string to apply when rendering the parameter value</param>
        /// <returns></returns>
        public HttpParameterSpecProvider<T> UriParameter<TResult>(
            Expression<Func<T, TResult>> selector, string name, string format = null)
        {
            parameters.Add(new HttpParameterSpec(typeof(T).Name, selector.GetMember().Name, name, format,true));
            return this;
        }

        public string Name 
            => name;

        public HttpParameterSpecProvider<S> Next<S>() 
            => new HttpParameterSpecProvider<S>(parameters);

        public HttpParameterSpecProvider<S> Next<S>(string name) 
            => new HttpParameterSpecProvider<S>(name, parameters);

        IEnumerator IEnumerable.GetEnumerator() 
            => parameters.GetEnumerator();

        IEnumerator<HttpParameterSpec> IEnumerable<HttpParameterSpec>.GetEnumerator() 
            =>  parameters.GetEnumerator();
    }
}
