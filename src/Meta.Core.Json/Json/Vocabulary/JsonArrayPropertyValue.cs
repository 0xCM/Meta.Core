//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
