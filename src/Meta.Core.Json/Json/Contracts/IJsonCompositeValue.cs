//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public interface IJsonCompositeValue : IJsonValue
{
    IReadOnlyList<IJsonValue> Items { get; }
}
