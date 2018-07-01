//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using NJSerializer = Newtonsoft.Json.JsonSerializer;

/// <summary>
/// Defines container for <see cref="JsonConverter"/> specializations
/// </summary>
static partial class JsonConverters
{
    /// <summary>
    /// Implements JSON serialization support for anonymous types
    /// </summary>
    public class AnonymousObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsAnonymous();

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
        {
            var j = JObject.FromObject(value);
            writer.WriteRaw(j.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
        {
            return existingValue;
        }
    }

}