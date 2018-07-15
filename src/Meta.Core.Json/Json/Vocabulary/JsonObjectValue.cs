//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public sealed class JsonObjectValue : JsonValue<JsonObjectValue>, IJsonCompositeValue
{
    /// <summary>
    /// Initializes an anonymous <see cref="JsonObjectValue"/>
    /// </summary>
    /// <param name="children">The parsed attributes</param>
    public JsonObjectValue(IEnumerable<IJsonValue> children)
        : this(String.Empty, children)
    {

    }

    /// <summary>
    /// Initializes a named <see cref="JsonObjectValue"/>
    /// </summary>
    /// <param name="Name">The name of the object</param>
    /// <param name="children">The parsed attributes</param>
    public JsonObjectValue(string Name, IEnumerable<IJsonValue> children)
        : base(Name, children)
    {

    }

    public IReadOnlyList<IJsonValue> Items 
        => cast<IReadOnlyList<IJsonValue>>(Value);
}
