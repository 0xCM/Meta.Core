//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
