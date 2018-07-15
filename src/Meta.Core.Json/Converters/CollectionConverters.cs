//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
    using System;
    using System.Linq;
using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Meta.Core;
using Meta.Core.Modules;

static partial class JsonConverters
{
    public class LstConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType.IsLst();



        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {

            var itemType = objectType.GenericTypeArguments.Single();
            var arrayType = Array.CreateInstance(itemType,0).GetType();            
            var arrayData = (serializer.Deserialize(reader, arrayType) as IEnumerable).Cast<object>();
            return Lst.make(itemType, arrayData);
           

            //var arrayType = Array.CreateInstance(itemType, 0).GetType();
            //var data = (serializer.Deserialize(reader, arrayType) as Array).Cast<object>();
            //return Lst.make(itemType, data);

            

        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is ILst l)
            {
                var gl = new List<object>(l.AsArray().Cast<object>());
                serializer.Serialize(writer, gl);
            }

        }
    }

}