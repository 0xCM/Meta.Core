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

    /// <summary>
    /// Constructs and manipulates <see cref="ISemigroup{X}"/> types and values
    /// </summary>
    public sealed class Semigroup : ClassModule<Semigroup, ISemigroup>
    {
        public Semigroup()
            : base(typeof(Semigroup<>))
        { }


        static ClassInstanceIndex<ISemigroup> ClassInstances { get; }
            = new ClassInstanceIndex<ISemigroup>();

        /// <summary>
        /// Attempts to construct a <see cref="ISemigroup"/> over <typeparamref name="X"/>
        /// </summary>
        /// <typeparam name="X">The semigroup element type</typeparam>
        /// <returns></returns>
        public static Option<ISemigroup<X>> make<X>()
            => Try(() => ClassInstances.TryFind<ISemigroup<X>>((typeof(X)))
                    .ValueOrElse(() => DefaultSemigroup<X>.instance));

        static void RegisterInstance(ISemigroup instance)
            => ClassInstances.Register(instance.GetType(), instance);

        static Semigroup()
            => iter(Factories(), f => RegisterInstance(f()));

        /// <summary>
        /// Returns known semigroup instance factories
        /// </summary>
        /// <returns></returns>
        static Seq<Func<ISemigroup>> Factories()
            => from m in type<Semigroup>().DeclaredStaticMethods
               where m.ReturnsAssignableType<ISemigroup>()
               select m.Func<ISemigroup>();
    }
}