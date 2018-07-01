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
    /// Realizes <see cref="IBounded{X}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X">The type of the bounded value</typeparam>
    public readonly struct Bounded<X> : IBounded<X>
    {        
        internal Bounded(X minval, X maxval)
        {
            this.minval = minval;
            this.maxval = maxval;
        }

        /// <summary>
        /// Them minimum value an instance of <typeparamref name="X"/> may attain
        /// </summary>
        public X minval { get; }

        /// <summary>
        /// Them maximum value an instance of <typeparamref name="X"/> may attain
        /// </summary>
        public X maxval { get; }

        public override string ToString()
            => $"[{minval},{maxval}]";
    }
}