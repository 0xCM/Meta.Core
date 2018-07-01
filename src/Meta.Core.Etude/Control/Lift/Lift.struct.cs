//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;
    using System.Collections;


    public readonly struct Lift<X> : ILift<X>, IEquatable<Lift<X>>
    {
        public static implicit operator X(Lift<X> lift)
            => lift.Value;

        public static implicit operator Lift<X>(X value)
            => new Lift<X>(value);


        public Lift(X Value)
            => this.Value = Value;

        /// <summary>
        /// The lifted value
        /// </summary>    
        public X Value { get; }

        /// <summary>
        /// Canonical bind
        /// </summary>
        /// <typeparam name="Y">The base space fro the range of the bound function</typeparam>
        public Lift<Y> Bind<Y>(Func<X, Lift<Y>> f)
            => f(Value);

        /// <summary>
        /// Canonical select
        /// </summary>
        /// <typeparam name="Y">The target base space</typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Lift<Y> Select<Y>(Func<X, Y> selector)
                => selector(Value);

        /// <summary>
        /// Canonical select many
        /// </summary>
        /// <typeparam name="Y">The intermediate base space</typeparam>
        /// <typeparam name="Z">The target base space</typeparam>
        /// <param name="select"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        public Lift<Z> SelectMany<Y, Z>(Func<X, Lift<Y>> select, Func<X, Y, Z> project)
        {
            var x = Value;
            return select(x).Bind<Z>(y => project(x, y));
        }


        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => $"Lift[{Value}]";

        public bool Equals(Lift<X> other)
            => Equals(Value, other.Value);

        public override bool Equals(object obj)
            => (obj is Lift<X>) ? Equals((Lift<X>)obj) : false;

    }


}