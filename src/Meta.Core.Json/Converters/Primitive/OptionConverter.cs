//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines container for <see cref="JsonConverter"/> specializations
/// </summary>
static partial class JsonConverters
{

    /// <summary>
    /// Implements JSON serialization support for the <see cref="Option{T}"/> type
    /// </summary>
    public class OptionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsOption();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            var option = value as IOption;
            if (option != null && option.IsSome)
            {
                serializer.Serialize(writer, option.Value);
            }
            else
            {
                serializer.Serialize(writer, String.Empty);
            }
        }

    }
}