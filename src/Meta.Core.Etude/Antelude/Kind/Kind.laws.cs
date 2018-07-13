//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IKind : IDataType { }

    public interface IKind<K> : IKind, IDataType<K> { }

    public interface IKind<K1, K2> : IKind, IDataType<K1, K2> { }

    public interface IKind<K1, K2, K3> : IKind, IDataType<K1, K2, K3> { }

    public interface IKind<K1, K2, K3, K4> : IKind, IDataType<K1, K2, K3, K4> { }

}