//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public sealed class JsonCompositePropertyValue : JsonValue<JsonCompositePropertyValue>
{
    public JsonCompositePropertyValue(string Name, IEnumerable<IJsonValue> Children)
        : base(Name, Children)
    {

    }

    public IReadOnlyList<IJsonValue> Children 
        => cast<IReadOnlyList<IJsonValue>>(Value);
}
