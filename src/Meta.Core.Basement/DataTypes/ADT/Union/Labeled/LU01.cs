//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using static minicore;

partial class Union
{

    /// <summary>
    /// A single-cased labeled union 
    /// </summary>
    /// <typeparam name="L">The label type</typeparam>
    /// <typeparam name="X1">The type of the first slot</typeparam>
    public readonly struct LU<L, X1> : IEquatable<LU<L, X1>>, ILabeledUnion<L, X1>
    {
        public static implicit operator LU<L, X1>((L, X1 x1) x)
            => new LU<L, X1>(x);

        public static bool operator ==(LU<L, X1> x, LU<L, X1> y)
            => x.Equals(y);

        public static bool operator !=(LU<L, X1> x, LU<L, X1> y)
            => not(x.Equals(y));

        public static bool operator ==(LU<L, X1> x, X1 y)
            => y == null ? false 
            : y.Equals(x.x1.ValueOrDefault());

        public static bool operator !=(LU<L, X1> x, X1 y)
            => not(x == y);

        public LU((L label, X1 x1) x1)
        {
            this.label = x1.label;
            this.x1 = x1.x1;
            this.n = 1;
        }

        public LU(L label, X1 x1)
        {
            this.label = label;
            this.x1 = x1;
            this.n = 1;
        }

        /// <summary>
        /// Species the number of the occupied slot
        /// </summary>
        public int n { get; }

        /// <summary>
        /// Specifies the assigned label
        /// </summary>
        public L label { get; }

        public Option<X1> x1 { get; }

        object IUnion.value
            => x1.ValueOrDefault();

        public Option<Y1> match<Y1>(Func<X1, Y1> f1)
            => x1.Map(x => f1(x));

        public Y map<Y>(Func<object, Y> f)
            => x1.MapRequired(x => f(x));

        public bool Equals(LU<L, X1> other)
            => x1.Equals(other.x1);

        public override bool Equals(object obj)
            => obj is LU<L, X1>
            ? Equals((LU<L, X1>)obj) : false;


        public override string ToString()
            => format(x1);

        public override int GetHashCode()
            => map(x => x.GetHashCode());           
    } 
}