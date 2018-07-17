//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public interface INumberInfo
    {
        /// <summary>
        /// Specifies whether the type admits signed values
        /// </summary>
        bool Signed { get; }

        /// <summary>
        /// Specifies whether the type admits only integral values
        /// </summary>
        bool Integral { get; }

        /// <summary>
        /// Specifies whether the number is a floating point value
        /// </summary>
        bool Floating { get; }

        /// <summary>
        /// Specifies the number of bits occupied by a value, if appliable
        /// </summary>
        int? BitCount { get; }

    }

    /// <summary>
    /// Describes a numeric type
    /// </summary>
    public readonly struct NumberInfo<T> : INumberInfo
        where T : struct
    {
        public NumberInfo(bool Signed, bool Integral, bool Floating, int? BitCount = null)
        {
            this.Signed = Signed;
            this.Integral = Integral;
            this.Floating = Floating;
            this.BitCount = BitCount;
        }

        /// <summary>
        /// Specifies whether the type admits signed values
        /// </summary>
        public bool Signed { get; }

        /// <summary>
        /// Specifies whether the type admits only integral values
        /// </summary>
        public bool Integral { get; }

        /// <summary>
        /// Specifies whether the number is a floating point value
        /// </summary>
        public bool Floating { get; }

        /// <summary>
        /// Specifies the number of bits occupied by a value, if appliable
        /// </summary>
        public int? BitCount { get; }
    }
}
