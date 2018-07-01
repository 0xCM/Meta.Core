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


public class SemanticIdentifierConverter<X, I> : JsonConverter
    where X : SemanticIdentifier<X, I>
{
    public override sealed bool CanConvert(Type objectType)
        => objectType.Realizes(typeof(ISemanticIdentifier));

    protected virtual X FromJson(Json j)
        => (X)(SemanticIdentifier<X, I>.Empty as ISemanticIdentifier).New(j);

    public override sealed object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
        => FromJson(reader.Value.ToString());

    public override sealed void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
        => serializer.Serialize(writer, (value as ISemanticIdentifier).IdentifierText);
}

static partial class JsonConverters
{
    public sealed class SemanticIdentifierConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsSealed && objectType.Realizes<ISemanticIdentifier>();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, NJSerializer serializer)
        {

            return Activator.CreateInstance(objectType, reader.Value);

        }

        public override void WriteJson(JsonWriter writer, object value, NJSerializer serializer)
            => serializer.Serialize(writer, value.ToString());

    }

}