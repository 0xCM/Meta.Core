//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;


    /// <summary>
    /// Encapsulates a monoidal value
    /// </summary>
    /// <typeparam name="A">The type of encapsulated value</typeparam>
    public readonly struct Sum<A> : ISum<A>, IEquatable<Sum<A>>
    {
        static readonly Combiner<A> add = operators.add;
        static readonly Equator<A> eq = operators.eq;
        static readonly Printer<Sum<A>> printer 
            = s => s.IsZero ? "Sum(0)" : concat("Sum", paren($"{s.value}"));

        public static readonly Sum<A> Zero = default;

        public static Sum<A> operator +(Sum<A> a1, Sum<A> a2)
            => new Sum<A>(a1.combiner(a1.value, a2.value));

        public static bool operator ==(Sum<A> a1, Sum<A> a2)
            => a1.Equals(a2);

        public static bool operator !=(Sum<A> a1, Sum<A> a2)
            => !a1.Equals(a2);

        public Sum(A value, IMonoid<A> monoid)
        {
            this.value = value;
            this.IsNonempty = true;
            this.combiner = monoid.combine;
            this.equator = monoid.eq;            
        }

        public Sum(A value)
        {
            this.value = value;
            this.IsNonempty = true;
            this.combiner = add;
            this.equator = eq;        
        }

        bool IsNonempty { get; }

        Combiner<A> combiner { get; }

        Equator<A> equator { get; }
            
        A value { get; }

        public bool IsZero
            => !IsNonempty;

        public override string ToString()
            => printer(this);

        public A unwrap()
            => value;

        public override bool Equals(object obj)
            => (obj is Sum<A> s) ? Equals(s) : false;

        public bool Equals(Sum<A> other)
            => this.IsZero && other.IsZero 
            ? true : equator(this.value, other.value);

        public override int GetHashCode()
            => this.IsZero ? 0 : value.GetHashCode();
    }
}
