//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using static metacore;

    public class Number : DataModule<Number, INumber>
    {

        public Number()
            : base(typeof(Number<>))
        { }

        /// <summary>
        /// Retrieves the intrinsic numeric types
        /// </summary>
        /// <returns></returns>
        public static ClrType[] intrinsics()
            => types<byte,sbyte,short,ushort,int,uint,
                    long,ulong,decimal,float,decimal>();

        /// <summary>
        /// Gets the number's additive identity
        /// </summary>
        /// <typeparam name="X">The number type</typeparam>
        /// <returns></returns>
        public static Number<X> zero<X>()
            where X : struct
            => Number<X>.Zero;

        /// <summary>
        /// Gets the number's multiplicative identity
        /// </summary>
        /// <typeparam name="X">The number type</typeparam>
        /// <returns></returns>
        public static Number<X> one<X>()
            where X : struct
            => Number<X>.One;

        /// <summary>
        /// Determines whether a number type admits signed numbers
        /// </summary>
        /// <typeparam name="X">The type to test</typeparam>
        /// <returns></returns>
        public bool signed<X>()
            where X : struct
                => info<X>().Require().Signed;

        /// <summary>
        /// Determines whether a specified type is an intrinsic numeric type
        /// </summary>
        /// <typeparam name="X">The type to test</typeparam>
        /// <returns></returns>
        public bool intrinsic<X>()
            where X : struct
            => intrinsics().Contains(type<X>());

        /// <summary>
        /// Describes a numeric type
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <returns></returns>
        public static Option<NumberInfo<X>> info<X>()
            where X : struct
            => same<X, byte>() ? cast<NumberInfo<X>>(UInt8Info)
            : same<X, sbyte>() ? cast<NumberInfo<X>>(Int8Info)
            : same<X, ushort>() ? cast<NumberInfo<X>>(UInt16Info)
            : same<X, short>() ? cast<NumberInfo<X>>(Int16Info)
            : same<X, uint>() ? cast<NumberInfo<X>>(UInt32Info)
            : same<X, int>() ? cast<NumberInfo<X>>(Int32Info)
            : same<X, ulong>() ? cast<NumberInfo<X>>(UInt64Info)
            : same<X, long>() ? cast<NumberInfo<X>>(Int64Info)
            : same<X, float>() ? cast<NumberInfo<X>>(Float32Info)
            : same<X, double>() ? cast<NumberInfo<X>>(Float64Info)
            : same<X, decimal>() ? cast<NumberInfo<X>>(DecimalInfo)
            : none<NumberInfo<X>>();

        /// <summary>
        /// Computes the absolute value of a number
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Number<X> abs<X>(Number<X> x)
            where X : struct
                => x < zero<X>() ? -x : x;

        /// <summary>
        /// Represents an integer as a <typeparamref name="X"/>-value
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Number<X> fromInt<X>(int i)
            where X : struct
                => (X)Convert.ChangeType(i, typeof(X));

        /// <summary>
        /// Gets the smallest number representable by <typeparamref name="X"/>
        /// </summary>
        public static Number<X> min<X>()
            where X : struct
                => Number<X>.Min;

        /// <summary>
        /// Gets the largest number representable by <typeparamref name="X"/>
        /// </summary>
        public static Number<X> max<X>()
            where X : struct
                => Number<X>.Max;

        /// <summary>
        /// Computes the predecessor, if possible
        /// </summary>
        /// <typeparam name="X">The underlying type</typeparam>
        /// <param name="x">The value for which a predecessor will potentially be computed</param>
        /// <returns></returns>
        public static Number<X>? prior<X>(Number<X> x)
            where X : struct
                => x > min<X>() ? --x : Number<X>.None;

        /// <summary>
        /// Computes the successor, if possible
        /// </summary>
        /// <typeparam name="X">The underlying type</typeparam>
        /// <param name="x">The value for which a successor will potentially be computed</param>
        /// <returns></returns>
        public static Number<X>? next<X>(Number<X> x)
            where X : struct
                => x < max<X>() ? ++x : Number<X>.None;


        static readonly NumberInfo<byte> UInt8Info = new NumberInfo<byte>(false, true, false, 8);
        static readonly NumberInfo<sbyte> Int8Info = new NumberInfo<sbyte>(true, true, false, 8);
        static readonly NumberInfo<ushort> UInt16Info = new NumberInfo<ushort>(false, true, false, 16);
        static readonly NumberInfo<short> Int16Info = new NumberInfo<short>(true, true, false, 16);
        static readonly NumberInfo<uint> UInt32Info = new NumberInfo<uint>(false, true, false, 32);
        static readonly NumberInfo<int> Int32Info = new NumberInfo<int>(true, true, false, 32);
        static readonly NumberInfo<ulong> UInt64Info = new NumberInfo<ulong>(false, true, false, 64);
        static readonly NumberInfo<long> Int64Info = new NumberInfo<long>(true, true, false, 64);
        static readonly NumberInfo<float> Float32Info = new NumberInfo<float>(true, false, true, 32);
        static readonly NumberInfo<double> Float64Info = new NumberInfo<double>(true, false, true, 64);
        static readonly NumberInfo<decimal> DecimalInfo = new NumberInfo<decimal>(true, false, false, 128);

    }

}

