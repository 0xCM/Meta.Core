//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public abstract class JsonComponent<T> : ValueObject<T>
    where T : ValueObject<T>
{

}
