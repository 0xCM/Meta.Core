//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;

    using static metacore;
    using static JsonConverters;

    /// <summary>
    /// Provides default implementation of <see cref="IJsonSerializer"/>
    /// </summary>
    class JsonSerializer : ApplicationService<JsonSerializer, IJsonSerializer>, IJsonSerializer
    {
        static Option<IJsonValue> TryParsePrimitive(string name, JToken token)
        {
            var result = none<IJsonValue>();
            switch (token.Type)
            {
                case JTokenType.Boolean:
                case JTokenType.Date:
                case JTokenType.Float:
                case JTokenType.Guid:
                case JTokenType.Integer:
                case JTokenType.Raw:
                case JTokenType.TimeSpan:
                case JTokenType.Uri:
                case JTokenType.String:
                    result = new JsonPrimitiveValue(name, token.Value<string>());
                    break;
            }
            return result;

        }

        static string ParseName(JToken token)
            => token.Path.Split('.').Last();

        static Option<IJsonValue> TryParse(string name, JToken token)
        {

            var result = none<IJsonValue>();
            switch (token.Type)
            {
                case JTokenType.Array:
                    result = TryParseArray(name, token);
                    break;
                case JTokenType.Object:
                    result = TryParseObject(name, token);
                    break;
                case JTokenType.Property:
                    result = TryParseProperty(name, token);
                    break;
                default:
                    result = TryParsePrimitive(name, token);
                    break;
            }
            return result;
        }

        static Option<IJsonValue> TryParseArray(string name, JToken value)
        {
            var result = none<IJsonValue>();
            if (value.Type == JTokenType.Array)
            {
                var jArray = value as JArray;
                var items = MutableList.Create<IJsonValue>();

                var i = 0;
                foreach (var jItem in jArray.Children())
                    TryParse($"array_item {i++}", jItem).OnSome(item => items.Add(item));
                result = new JsonArrayValue(name, items);
            }
            return result;
        }

        static Option<IJsonValue> TryParseProperty(string name, JToken token)
        {
            var result = none<IJsonValue>();
            if (token.Type == JTokenType.Property)
            {
                var children = rovalues(ParseChildren(token));
                if (children.Count == 1 && children.First() is JsonPrimitiveValue)
                    result = new JsonPrimtivePropertyValue(name, cast<JsonPrimitiveValue>(children.First()));
                else if (children.Count == 1 && children.First() is JsonArrayValue)
                    result = new JsonArrayPropertyValue(name, cast<JsonArrayValue>(children.First()));
                else
                    result = new JsonCompositePropertyValue(name, children);
            }

            return result;
        }

        static IEnumerable<IJsonValue> ParseChildren(JToken token)
        {
            var children = MutableList.Create<IJsonValue>();
            foreach (var jChild in token.Children())
                TryParse(ParseName(jChild), jChild).OnSome(child => children.Add(child));
            return children;
        }

        static Option<IJsonValue> TryParseObject(string name, JToken token)
        {
            var result = none<IJsonValue>();
            if (token.Type == JTokenType.Object)
                result = new JsonObjectValue(name, ParseChildren(token));
            return result;
        }

        static IEnumerable<JsonConverter> CreateDefaultConverters()
        {
            foreach (var t in typeof(JsonConverters).GetNestedTypes())
                yield return (JsonConverter)Activator.CreateInstance(t);

            yield return new StringEnumConverter();

        }

        static readonly JsonConverter[] DefaultConverters = CreateDefaultConverters().ToArray();

        static JsonSerializerSettings DefineSettings(IEnumerable<JsonConverter> converters)
            => new JsonSerializerSettings
            {
                Converters = converters.ToArray(),
                ContractResolver = new JsonContractResolver()
            };


        JsonSerializerSettings settings;

        public JsonSerializer()
            => settings = DefineSettings(DefaultConverters);

        public void RegisterConverter(IJsonConverter converter)
        {
            var newConverter
                = (converter is JsonConverter)
                ? (converter as JsonConverter)
                : DelegatingConverter.DelegateTo(converter);
            settings = DefineSettings(settings.Converters.Union(stream(newConverter)));
        }

        public JsonSerializer(IApplicationContext context)
            : base(context) => settings = DefineSettings(DefaultConverters);

        public IReadOnlyDictionary<string, object> DeserializeAttributes(Json j)
            => JsonConvert.DeserializeObject<Dictionary<string, object>>(j, settings);

        public T ObjectFromJson<T>(Json j)
            => JsonConvert.DeserializeObject<T>(j, settings);

        public T ObjectFromFile<T>(string path)
            => ObjectFromJson<T>(File.ReadAllText(path));

        public Json SerializeAttributes(IReadOnlyDictionary<string, object> attributes)
            => JsonConvert.SerializeObject(attributes, Formatting.Indented, settings);

        Json IJsonSerializer.ObjectToJson(object o, bool indented)
            => JsonConvert.SerializeObject(o,
                    indented ? Formatting.Indented : Formatting.None, settings);

        Option<IFilePath> IJsonSerializer.ObjectToFile(object o, FilePath dst, bool indented)
            => Try(() => dst.TryWriteAllText(JsonConvert.SerializeObject(o,
                            indented ? Formatting.Indented : Formatting.None, settings)));

        public object ObjectFromJson(Type t, Json json)
            => JsonConvert.DeserializeObject(json.Text, t);

        public object ObjectFromFile(Type t, string path)
           => ObjectFromJson(t, File.ReadAllText(path));

        public JsonDocument ParseDocument(string json)
        {
            var values = MutableList.Create<IJsonValue>();
            foreach (var kvp in JsonConvert.DeserializeObject<JObject>(json, settings))
                TryParse(kvp.Key, kvp.Value).OnSome(v => values.Add(v));
            return new JsonDocument(values, json);
        }
    }
}