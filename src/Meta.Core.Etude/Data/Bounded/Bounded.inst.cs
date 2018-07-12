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
    /// Realizes a <see cref="IBounded"/> instance predicated on the
    /// existence of convential members
    /// </summary>
    /// <typeparam name="X">The bounded element typed</typeparam>
    readonly struct DefaultBounded<X> : IBounded<X>
    {
        public static readonly Option<IBounded<X>> Default = CreateIntrinsic();

        static Option<IBounded<X>> CreateIntrinsic()
            => from minField in field<X>("MinValue")
               from maxField in field<X>("MaxValue")
               from min in value<X>(minField)
               from max in value<X>(maxField)
               select new DefaultBounded<X>(min, max) 
                    as IBounded<X>;

        DefaultBounded(X minval, X maxval)
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

        public Type BoundType
            => typeof(X);

        public override string ToString()
            => $"[{minval},{maxval}]";
    }
}