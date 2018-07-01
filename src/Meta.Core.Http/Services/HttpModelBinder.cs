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
    using System.Text;
    using System.Threading.Tasks;

    using Nancy;
    using Nancy.Owin;
    using Nancy.Extensions;
    using Nancy.ModelBinding;

    /// <summary>
    /// Binds an HTTP model to a dynamic dictionary
    /// </summary>
    /// <remarks>
    /// See https://gist.github.com/thecodejunkie/5521941
    /// </remarks>
    public class HttpModelBinder : IModelBinder
    {
        static IDictionary<string, string> ConvertDynamicDictionary(DynamicDictionary dictionary)
            => dictionary.GetDynamicMemberNames().ToDictionary(
                    memberName => memberName,
                    memberName => (string)dictionary[memberName]);

        static IDictionary<string, object> GetDataFields(NancyContext context)
        {
            return Merge(new IDictionary<string, string>[]
            {
                ConvertDynamicDictionary(context.Request.Form),
                ConvertDynamicDictionary(context.Request.Query),
                ConvertDynamicDictionary(context.Parameters)
            });
        }

        /// <summary>
        /// Merges an arbitrary number of dictionaries into a single dictionary
        /// </summary>
        /// <param name="dictionaries">The sequence of dictionaries to merge</param>
        /// <returns></returns>
        static IDictionary<string, object> Merge(IEnumerable<IDictionary<string, string>> dictionaries)
        {
            var output =
                new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var dictionary in dictionaries.Where(d => d != null))
            {
                foreach (var kvp in dictionary)
                {
                    if (!output.ContainsKey(kvp.Key))
                    {
                        output.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            return output;
        }

        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            var data = GetDataFields(context);
            var model = DynamicDictionary.Create(data);
            return model;
        }
        
        public bool CanBind(Type modelType)
            => modelType == typeof(DynamicDictionary);        
    }
}
