//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
