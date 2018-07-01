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
    /// Defines a directed association from s source link to a target link
    /// </summary>
    /// <typeparam name="X">The domain of the first link</typeparam>
    /// <typeparam name="Y">The codomain of the first link and the domain of the second</typeparam>
    /// <typeparam name="Z">The codomain of the second link</typeparam>
    public readonly struct Chain<X, Y, Z> : ILink<Link<X, Y>, Link<Y, Z>>
    {
        /// <summary>
        /// Canonical <see cref="Chain{X, Y, Z}"/> factory method
        /// </summary>
        /// <param name="x"></param>
        public static explicit operator Chain<X, Y, Z>((Link<X, Y> Source, Link<Y, Z> Target) x)
            => new Chain<X, Y, Z>(x.Source, x.Target);

        Chain(in Link<X, Y> Source, in Link<Y, Z> Target)
        {
            this.Source = Source;
            this.Target = Target;
        }

        /// <summary>
        /// The source link
        /// </summary>
        public Link<X, Y> Source { get; }

        /// <summary>
        /// The target link
        /// </summary>
        public Link<Y, Z> Target { get; }

        /// <summary>
        /// Specifies the chain identifier
        /// </summary>
        public LinkIdentifier Name
            => (LinkIdentifier)(Source, Target);

        public override string ToString()
            => Name.ToString();
    }

}