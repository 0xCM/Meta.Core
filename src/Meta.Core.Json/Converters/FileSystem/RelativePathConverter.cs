//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using NJSerializer = Newtonsoft.Json.JsonSerializer;


static partial class JsonConverters
{


    public sealed class RelativePathConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(RelativePathConverter);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
            => RelativePath.Parse(reader.Value.ToString());

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
            => serializer.Serialize(writer, value.ToString());

    }



}