﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using NJSerializer = Newtonsoft.Json.JsonSerializer;


static partial class JsonConverters
{

    public sealed class FileNameConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(FilePath);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
            => FileName.Parse(reader.Value.ToString());

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
            => serializer.Serialize(writer, value.ToString());

    }
}
