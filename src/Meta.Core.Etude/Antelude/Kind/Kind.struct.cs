//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    /// <summary>
    /// Represents a type of kind <typeparamref name="K"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public readonly struct Kind<K> : IKind<K>
    {
        public static readonly Kind<K> instance = default;
    }

    public readonly struct Kind<K1,K2> : IKind<K1,K2>
    {
        public static readonly Kind<K1,K2> instance = default;
    }

    public readonly struct Kind<K1, K2, K3> : IKind<K1, K2, K3>
    {
        public static readonly Kind<K1, K2, K3> instance = default;
    }

    public readonly struct Kind<K1, K2, K3, K4> : IKind<K1, K2, K3, K4>
    {
        public static readonly Kind<K1, K2, K3, K4> instance = default;
    }

}