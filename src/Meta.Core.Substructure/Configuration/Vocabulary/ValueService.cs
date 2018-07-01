//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static minicore;

class ValueService : ApplicationService<ValueService, IValueService>, IValueService
{
    readonly Dictionary<string, object> values = new Dictionary<string, object>();

    public ValueService(IApplicationContext C)
        : base(C)
    { }

    public void SetValue(string name, object value)
        => values[name] = value;

    public Option<T> TryGetValue<T>(string name)
    {
        if (values.TryGetValue(name, out object value))
        {
            if (value is T)
                return (T)value;
        }
        return none<T>();
    }
}
