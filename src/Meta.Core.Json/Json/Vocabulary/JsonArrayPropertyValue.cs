//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


public sealed class JsonArrayPropertyValue : JsonValue<JsonArrayPropertyValue>
{
    public JsonArrayPropertyValue(string Name, JsonArrayValue Value)
        : base(Name, Value)
    {

    }
    public JsonArrayValue ArrayValue 
        => Value as JsonArrayValue;

    public IReadOnlyList<object> Items 
        => ArrayValue.Items;


}
