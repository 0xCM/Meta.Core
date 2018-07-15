//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using Newtonsoft.Json;

using Meta.Core;
using NJSerializer = Newtonsoft.Json.JsonSerializer;

static partial class JsonConverters
{
    public sealed class FolderPathConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(FolderPath);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
            => FolderPath.Parse(reader.Value.ToString());

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
            => serializer.Serialize(writer, value.ToString());
    }
}