//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IUnion
    {
        /// <summary>
        /// Specifies the number of the occupied slot
        /// </summary>
        int n { get; }

        /// <summary>
        /// The encapsulated value
        /// </summary>
        object value { get; }

    }

    public interface IUnion<X1> : IUnion
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

    }

    public interface IUnion<X1, X2> : IUnion
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

    }

    public interface IUnion<X1, X2, X3> : IUnion
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }

    }

    public interface IUnion<X1, X2, X3, X4> : IUnion
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }

        /// <summary>
        /// The fourth slot
        /// </summary>
        Option<X4> x4 { get; }
    }

    public interface ILabledUnion : IUnion
    {

    }
    public interface ILabeledUnion<L> : ILabledUnion
    {
        L label { get; }

    }

    public interface ILabeledUnion<L, X1> : ILabeledUnion<L>
    {

        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

    }

    public interface ILabeledUnion<L, X1, X2> : ILabeledUnion<L>
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }
    }

    public interface ILabeledUnion<L, X1, X2, X3> : ILabeledUnion<L>
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }
    }

    public interface ILabeledUnion<L, X1, X2, X3, X4> : ILabeledUnion<L>
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }

        /// <summary>
        /// The fourth slot
        /// </summary>
        Option<X4> x4 { get; }
    }

    public interface IConstrainedUnion : IUnion
    {

    }

    public interface IConstrainedUnion<K> : IConstrainedUnion
        where K : class
    {
        /// <summary>
        /// The encapsulated value
        /// </summary>
        new K value { get; }
    }

    public interface IConstrainedUnion<K, X1> : IConstrainedUnion<K>
        where K : class
        where X1 : K
    {

        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

    }

    public interface IConstrainedUnion<K, X1, X2> : IConstrainedUnion<K>
        where K : class
        where X1 : K
        where X2 : K
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }
    }

    public interface IConstrainedUnion<K, X1, X2, X3> : IConstrainedUnion<K>
        where K : class
        where X1 : K
        where X2 : K
        where X3 : K
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }
    }

    public interface IConstrainedUnion<K, X1, X2, X3, X4> : IConstrainedUnion<K>
        where K : class
        where X1 : K
        where X2 : K
        where X3 : K
        where X4 : K
    {
        /// <summary>
        /// The first slot
        /// </summary>
        Option<X1> x1 { get; }

        /// <summary>
        /// The second slot
        /// </summary>
        Option<X2> x2 { get; }

        /// <summary>
        /// The third slot
        /// </summary>
        Option<X3> x3 { get; }

        /// <summary>
        /// The fourth slot
        /// </summary>
        Option<X4> x4 { get; }
    }


}