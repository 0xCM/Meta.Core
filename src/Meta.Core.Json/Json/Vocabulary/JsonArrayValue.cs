//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
