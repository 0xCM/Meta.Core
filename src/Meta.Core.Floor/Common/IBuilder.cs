//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Contract for monadic builders
/// </summary>
/// <typeparam name="X">The subject of construction</typeparam>
public interface IBuilder<X>
{
    Builder<Y> Select<Y>(Func<X, Y> selector);

    Builder<Z> SelectMany<Y, Z>(Func<X, Builder<Y>> select, Func<X, Y, Z> project);
}


