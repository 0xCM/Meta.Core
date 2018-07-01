//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using NJSerializer = Newtonsoft.Json.JsonSerializer;

/// <summary>
/// Defines container for <see cref="JsonConverter"/> specializations
/// </summary>
static partial class JsonConverters
{
    /// <summary>
    /// Implements JSON serialization support for the <see cref="CorrelationToken"/> type
    /// </summary>
    public class CorrelationTokenConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        => objectType == typeof(CorrelationToken);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
            => new CorrelationToken(existingValue.ToString());

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
            => serializer.Serialize(writer, value.ToString());
    }
}