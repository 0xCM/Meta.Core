//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public sealed class JsonArrayValue : JsonValue<JsonArrayValue>, IJsonCompositeValue
{

    public JsonArrayValue(string Name, IEnumerable<IJsonValue> Children)
        : base(Name, rovalues(Children))
    {

    }

    public IReadOnlyList<IJsonValue> Items 
        => cast<IReadOnlyList<IJsonValue>>(Value);
}
