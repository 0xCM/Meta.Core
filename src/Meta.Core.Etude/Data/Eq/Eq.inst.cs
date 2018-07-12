//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static minicore;



    public readonly struct DefaultEq<X> : IEq<X>
    {
        public static readonly DefaultEq<X> instance = default;

        public bool eq(X x1, X x2)
            => object.Equals(x1, x2);
    }

}