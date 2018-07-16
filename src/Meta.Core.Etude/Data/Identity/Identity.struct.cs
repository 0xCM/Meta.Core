//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public readonly struct Identity<X> : IIdentity<X>
    {
        public static readonly Identity<X> instance = default;

    }

}