//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    /// <summary>
    /// Constructs and manipulates <see cref="IBounded"/> types and values
    /// </summary>
    public class Bounded : ClassModule<Bounded,IBounded>, IBounded
    {
        public Bounded()
            : base(typeof(Bounded<>))
        { }

        /// <summary>
        /// Attemps to construct a <see cref="IBounded{X}"/> predicated on extant data
        /// </summary>
        /// <typeparam name="X">The bounded type</typeparam>
        /// <returns></returns>
        public static Option<IBounded<X>> make<X>()
            => DefaultBounded<X>.Default;

        /// <summary>
        /// Creates a <see cref="IBounded{X}"/> predicated on supplied data
        /// </summary>
        /// <typeparam name="X">The bounded type</typeparam>
        /// <param name="min">The smallest <typeparamref name="X"/></param> value that can exist
        /// <param name="max">The greatest <typeparamref name="X"/></param> value that can exist
        /// <returns></returns>
        public static Bounded<X> make<X>(X min, X max)
            => new Bounded<X>(min, max);

        /// <summary>
        /// Determines whether a specified type is a member of the <see cref="IBounded"/> class
        /// </summary>
        /// <typeparam name="X">The type to test</typeparam>
        /// <returns></returns>
        public static bool isMember<X>()
            => DefaultBounded<X>.Default.IsSome();

    }
}