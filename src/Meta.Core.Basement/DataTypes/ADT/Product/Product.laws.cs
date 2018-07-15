//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;


	public interface IProduct : ITuple
    {
		

    }

	public interface IProduct<X1> : IProduct
    {
		X1 x1 { get; }

        ValueTuple<X1> AsTuple();
    }

    public interface IProduct<X1,X2> : IProduct
    {
        X1 x1 { get; }

        X2 x2 { get; }

        (X1 x1, X2 x2) AsTuple();
    }

    public interface IProduct<X1, X2, X3> : IProduct
    {
        X1 x1 { get; }

        X2 x2 { get; }

		X3 x3 { get; }

        (X1 x1, X2 x2, X3 x3) AsTuple();
    }

    public interface IProduct<X1, X2, X3, X4> : IProduct
    {
        X1 x1 { get; }

        X2 x2 { get; }

        X3 x3 { get; }

        X4 x4 { get; }

        (X1 x1, X2 x2, X3 x3, X4 x4) AsTuple();

    }

}