//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Confers identity on a conversion X->Y such that two converters
    /// A:X1->Y1 and B:X1->Y2 are identical if and only if
    /// (typeof(X1),typeof(Y1)) and (typeof(X2),typeof(Y2)) are equal
    /// </summary>
    public readonly struct ConversionKey : IEquatable<ConversionKey>
    {
        public static implicit operator long(ConversionKey key)
            => key.KeyValue;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ConversionKey FromTypes(Type srcType, Type dstType)
        {
            var x = (long)srcType.GetHashCode();
            var y = (long)dstType.GetHashCode();
            var key = (x << 32) | y;
            return new ConversionKey(srcType, dstType, key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FromTypes<TSrc, TDst>()
        {
            var srcType = typeof(TSrc);
            var dstType = typeof(TDst);
            var x = (long)srcType.GetHashCode();
            var y = (long)dstType.GetHashCode();
            var key = (x << 32) | y;
            return new ConversionKey(srcType, dstType, key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ConversionKey FromMethod(MethodInfo method)
        {
            var srcType = method.GetParameters().First().ParameterType;
            var dstType = method.ReturnType;
            return FromTypes(srcType, dstType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FromFunction<TSrc, TDst>(Func<TSrc, TDst> projector)
            => FromTypes<TSrc, TDst>();

        ConversionKey(Type SourceType, Type TargetType, long KeyValue)
        {
            this.SourceType = SourceType;
            this.TargetType = TargetType;
            this.KeyValue = KeyValue;
        }

        /// <summary>
        /// The source value type
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// The target value type
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// The key value
        /// </summary>
        public long KeyValue { get; }

        public override bool Equals(object obj)
            => obj is ConversionKey
            ? Equals((ConversionKey)obj) : false;

        public bool Equals(ConversionKey other)
            => this.KeyValue == other.KeyValue;

        public override int GetHashCode()
            => KeyValue.GetHashCode();

        public override string ToString()
            => $"{KeyValue}:{SourceType} => {TargetType}";
    }
}