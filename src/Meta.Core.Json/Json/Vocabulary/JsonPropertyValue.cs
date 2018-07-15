//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public class JsonPropertyValue : JsonValue<JsonPropertyValue>, IJsonValue
{
    public JsonPropertyValue(string Name, object Value)
        : base(Name, Value)
    {

    }

}
