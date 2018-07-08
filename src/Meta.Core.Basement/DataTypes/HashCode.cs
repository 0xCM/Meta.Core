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
    using System.Runtime.CompilerServices;
    

    /// <summary>
    /// Represents a (.Net) hash code and defines related operations
    /// </summary>
    public readonly struct HashCode : IEquatable<HashCode>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static HashCode Calc<X1>(X1 x1)
            => new HashCode(x1?.GetHashCode() ?? 0);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2>(X1 x1, X2 x2)
            => Calc(x1) + Calc(x2);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <typeparam name="X3">The type of the third value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
            => Calc(x1) + Calc(x2) + Calc(x3);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <typeparam name="X3">The type of the third value</typeparam>
        /// <typeparam name="X4">The type of the fourth value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <param name="x4">The fourth value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
            => Calc(x1) + Calc(x2) + Calc(x3) + Calc(x4);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <typeparam name="X3">The type of the third value</typeparam>
        /// <typeparam name="X4">The type of the fourth value</typeparam>
        /// <typeparam name="X5">The type of the fifth value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <param name="x4">The fourth value</param>
        /// <param name="x5">The fifth value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
            => Calc(x1) + Calc(x2) + Calc(x3) + Calc(x4) + Calc(x5);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <typeparam name="X3">The type of the third value</typeparam>
        /// <typeparam name="X4">The type of the fourth value</typeparam>
        /// <typeparam name="X5">The type of the fifth value</typeparam>
        /// <typeparam name="X6">The type of the sixth value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <param name="x4">The fourth value</param>
        /// <param name="x5">The fifth value</param>
        /// <param name="x6">The sixth value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2, X3, X4, X5, X6>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
            => Calc(x1) + Calc(x2) + Calc(x3) + Calc(x4) + Calc(x5) + Calc(x6);

        /// <summary>
        /// Computes the hash code of each component value and combines the result
        /// </summary>
        /// <typeparam name="X1">The type of the first value</typeparam>
        /// <typeparam name="X2">The type of the second value</typeparam>
        /// <typeparam name="X3">The type of the third value</typeparam>
        /// <typeparam name="X4">The type of the fourth value</typeparam>
        /// <typeparam name="X5">The type of the fifth value</typeparam>
        /// <typeparam name="X6">The type of the sixth value</typeparam>
        /// <typeparam name="X7">The type of the seventh value</typeparam>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <param name="x4">The fourth value</param>
        /// <param name="x5">The fifth value</param>
        /// <param name="x6">The sixth value</param>
        /// <param name="x7">The seventh value</param>
        /// <returns></returns>
        public static HashCode Calc<X1, X2, X3, X4, X5, X6, X7>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6, X7 x7)
            => Calc(x1) + Calc(x2) + Calc(x3) + Calc(x4) + Calc(x5) + Calc(x6) + Calc(x7);

        /// <summary>
        /// Computes the hash of each item and folds the results into a single <see cref="HashCode"/> value
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="stream">The items to be hashed</param>
        /// <returns></returns>
        public static HashCode Calc<X>(IEnumerable<X> stream)
            => stream.Aggregate(Zero, (x, y) => Calc(x) + Calc(y));

        public static implicit operator int(HashCode h)
            => h.Value;

        public static implicit operator HashCode(int h)
            => new HashCode(h);

        static readonly int RandomSeed = Guid.NewGuid().GetHashCode();        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HashCode operator +(HashCode h1, HashCode h2)
        {
            //Taken from .net framework source: System/Numerics/Hashing/HashHelpers.cs
            unchecked
            {
                // RyuJIT optimizes this to use the ROL instruction
                // Related GitHub pull request: dotnet/coreclr#1830
                uint rol5 = ((uint)h1.Value << 5) | ((uint)h1.Value >> 27);
                return ((int)rol5 + h1) ^ h2;
            }
        }

        public static readonly HashCode Zero = new HashCode(0);


        public HashCode(int Value)
            => this.Value = Value;

        public int Value { get; }

        public bool Equals(HashCode other)
            => Value == other.Value;

        public override string ToString()
            => Value.ToString();

        public override bool Equals(object obj)
            => (obj is HashCode h) ? Equals(h) : false;

        public override int GetHashCode()
            => Value;
    }
}