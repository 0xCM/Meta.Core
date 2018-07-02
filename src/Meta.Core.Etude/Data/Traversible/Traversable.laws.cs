//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public interface ITraversable : ITypeClass
    {

    }

    public interface ITraversable<X, CX, Y, CY> : IFunctor<X, CX, Y, CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>

    {
        CY traverse(Func<X, CY> f, CX cx);
    }
}