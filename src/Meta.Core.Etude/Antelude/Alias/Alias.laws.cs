//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public interface IAlias : IDataType
    {

    }

    public interface IAlias<A> : IAlias, IDataType<A>
    {
        IKind<A> subject { get; }
    }

    public interface IAlias<A1, A2> : IAlias, IDataType<A1, A2>
    {
        IKind<A1, A2> subject { get; }
    }

    public interface IAlias<A1, A2, A3> : IAlias, IDataType<A1, A2, A3>
    {
        IKind<A1, A2, A3> subject { get; }
    }

    public interface IAlias<A1, A2, A3, A4> : IAlias, IDataType<A1, A2, A3, A4>
    {
        IKind<A1, A2, A3, A4> subject { get; }
    }

}