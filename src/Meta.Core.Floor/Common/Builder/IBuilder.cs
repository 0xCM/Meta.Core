//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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


