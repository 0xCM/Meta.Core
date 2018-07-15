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

public sealed class DelegatingConverter : JsonConverter
{
    public static JsonConverter DelegateTo(IJsonConverter receiver)
        => new DelegatingConverter(receiver);

    readonly IJsonConverter receiver;

    DelegatingConverter(IJsonConverter receiver)
        => this.receiver = receiver;

    public override bool CanConvert(Type objectType)
        => receiver.Supports(objectType);

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
        => receiver.FromJson(reader.Value?.ToString() ?? String.Empty);

    public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
        => serializer.Serialize(writer, receiver.ToJson(value));

}




