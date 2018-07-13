//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents an alias for an existing type of kind <see cref="Kind{A}"/> parameterized by <typeparamref name="A"/>
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public readonly struct Alias<A> : IAlias<A>
    {
        public static readonly Alias<A> instance = default;
        static readonly Kind<A> _subject = Kind<A>.instance;

        /// <summary>
        /// The kind on which the alias is predicated
        /// </summary>
        public IKind<A> subject
            => subject;
    }

    /// <summary>
    /// Represents an alias for an existing type of kind <see cref="Kind{A1,A2}"/> with two parameters
    /// </summary>
    /// <typeparam name="A1">The type of the first parameter</typeparam>
    /// <typeparam name="A2">The type of the second parameter</typeparam>
    public readonly struct Alias<A1, A2> : IAlias<A1, A2>
    {
        public static readonly Alias<A1, A2> instance = default;
        static readonly Kind<A1,A2> _subject = Kind<A1,A2>.instance;

        public IKind<A1, A2> subject
            => _subject;
    }

    /// <summary>
    /// Represents an alias for an existing type of kind <see cref="Kind{A1,A2,A3}"/> with three parameters
    /// </summary>
    /// <typeparam name="A1">The type of the first parameter</typeparam>
    /// <typeparam name="A2">The type of the second parameter</typeparam>
    /// <typeparam name="A3">The type of the third parameter</typeparam>
    public readonly struct Alias<A1, A2, A3> : IAlias<A1, A2, A3>
    {
        static readonly Kind<A1, A2, A3> _subject = Kind<A1, A2, A3>.instance;
        public static readonly Alias<A1, A2, A3> instance = default;

        public IKind<A1, A2, A3> subject
            => _subject;

    }

    /// <summary>
    /// Represents an alias for an existing type of kind <see cref="Kind{A1,A2,A3,A4}"/> with four parameters
    /// </summary>
    /// <typeparam name="A1">The type of the first parameter</typeparam>
    /// <typeparam name="A2">The type of the second parameter</typeparam>
    /// <typeparam name="A3">The type of the third parameter</typeparam>
    /// <typeparam name="A4">The type of the fourth parameter</typeparam>
    public readonly struct Alias<A1, A2, A3, A4> : IAlias<A1, A2, A3, A4>
    {
        static readonly Kind<A1, A2, A3, A4> _subject = Kind<A1, A2, A3, A4>.instance;
        public static readonly Alias<A1, A2, A3, A4> instance = default;

        public IKind<A1, A2, A3, A4> subject
            => _subject;

    }

}