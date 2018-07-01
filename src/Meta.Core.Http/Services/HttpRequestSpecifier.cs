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

    using System.Reflection;

    using static metacore;

    /// <summary>
    /// Responsible for producing an <see cref="HttpRequestSpec"/> from a description expressed
    /// in a specialized service domain vocabulary. Note that it is called a "Request Specifier"
    /// instead of a "Request Builder" because it doesn't actually build an HTTP request but,
    /// rather, constructs a <see cref="HttpRequestSpec"/> that characterizes a request
    /// </summary>
    public class HttpRequestSpecifier : IHttpRequestSpecifier
    {

        static BindingFlags DefaultFlags =
                BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.Static;

        static Option<object> TryGetMemberValue(object o, string name)
        {
            var t = o.GetType();
            var f = t.GetField(name, DefaultFlags);
            return isNull(f) ? t.GetProperty(name, DefaultFlags)?.GetValue(o)
                             : f.GetValue(o);
        }

        static IEnumerable<HttpRequestParameter> SpecifyParameters(object entity, IReadOnlyList<HttpParameterSpec> mappings)
        {
            foreach (var mapping in mappings)
            {
                var value = TryGetMemberValue(entity, mapping.AttributeName);
                if (value)
                    yield return new HttpRequestParameter(mapping, value.ValueOrDefault());
            }
        }

        static Tuple<string, List<HttpRequestParameter>> replace(string text, IEnumerable<HttpRequestParameter> parameters)
        {
            var result = text;
            var e = parameters.GetEnumerator();
            var replaced = new List<HttpRequestParameter>();
            while (result.Contains("{") && e.MoveNext())
            {
                var parameter = e.Current;
                var replacement = result.Replace("{" + parameter.ParameterName + "}", parameter.ParameterValue);
                
                if (replacement != result)
                    //Conditional check prevents a parameter that is mapped to part of a URI from being sent in the body
                {
                    replaced.Add(parameter);
                    result = replacement;
                }              
            }
            return Tuple.Create(result, replaced);
        }

        /// <summary>
        /// The supported actions as defined by a service specification
        /// </summary>
        readonly IReadOnlyDictionary<string, HttpActionSpec> actions;

        /// <summary>
        /// A parameter type index derived from a service specification
        /// </summary>
        readonly IReadOnlyDictionary<string, ReadOnlyList<HttpParameterSpec>> types;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSpecifier"/> type
        /// </summary>
        /// <param name="spec">Specifies the service for which request specifications will be constructed</param>
        public HttpRequestSpecifier(HttpServiceSpec spec)
        {
            this.actions = spec.Actions.ToDictionary(x => x.ActionName);
            this.types = spec.Parameters.GroupBy(x => x.EntityName)
                                        .ToDictionary(x => x.Key, x => rolist(x.Select(y => y)));
        }
        
        /// <summary>
        /// Derives the request specification from the contracted method and supplied parameter values
        /// </summary>
        /// <param name="baseuri">The base URI</param>
        /// <param name="m">The contracted method</param>
        /// <param name="paramValues">The values that will be supplied as HTTP parameters</param>
        /// <returns></returns>
        public HttpRequestSpec SpecifyRequest(Uri baseuri, MethodInfo m, params object[] paramValues)
        {
            var parameters = mapi(m.GetParameters(), 
                (i, p) => SpecifyParameters(paramValues[i], types.TryFind(p.ParameterType.Name).Require())).SelectMany(x => x);

            var action = actions.TryFind(m.Name).Require();
            var replacement = replace(action.UriPath, parameters);
            var relativeUri = replacement.Item1;
            
            return new HttpRequestSpec
                (
                   Method: action.HttpMethod, 
                   RequestUri: new Uri(baseuri, relativeUri),
                   ContentType: action.ContentType,
                   Parameters:  parameters.Except(replacement.Item2)   
               );
        }

    }
}
