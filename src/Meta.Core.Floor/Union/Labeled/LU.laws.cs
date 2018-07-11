//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public interface ILabeledUnion<L, X1>
    {
        L label { get; }

        Option<X1> x1 { get; }

    }

    public interface ILabeledUnion<L, X1, X2> : ILabeledUnion<L, X1>
    {
        Option<X2> x2 { get; }
    }

    public interface ILabeledUnion<L, X1, X2, X3> : ILabeledUnion<L, X1, X2>
    {
        Option<X3> x3 { get; }
    }

    public interface ILabeledUnion<L, X1, X2, X3, X4> : ILabeledUnion<L, X1, X2, X3>
    {
        Option<X4> x4 { get; }
    }

}