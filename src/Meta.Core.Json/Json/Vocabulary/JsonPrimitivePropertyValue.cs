//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

public sealed class JsonPrimtivePropertyValue : JsonValue<JsonPrimtivePropertyValue>
{
    public JsonPrimtivePropertyValue(string Name, JsonPrimitiveValue Value)
        : base(Name, Value)
    {

    }

    public JsonPrimitiveValue PrimitiveValue => cast<JsonPrimitiveValue>(Value);

    public override string ToString() => $"{Name} = {Value}";

}
