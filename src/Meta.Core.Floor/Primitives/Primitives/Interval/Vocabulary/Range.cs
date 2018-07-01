//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    public static class Range
    {
        public static Range<T> Create<T>(T Min, T Max)
            where T : IComparable => new Range<T>(Min, Max);
    }

    /// <summary>
    /// Defines inclusive lower and upper bounds for a comparable set of values
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    public struct Range<T> : IInterval<T>
        where T : IComparable
    {
        public Range(T Min, T Max)
        {
            this.Min = Min;
            this.Max = Max;
        }

        /// <summary>
        /// The minimum value in the range
        /// </summary>
        public T Min { get; }

        /// <summary>
        /// The maximum value in the range
        /// </summary>
        public T Max { get; }

        bool IInterval.LeftInclusive
            => true;

        bool IInterval.RightInclusive
            => true;

        object IInterval.Min
            => Min;

        object IInterval.Max
            => Max;

        /// <summary>
        /// Tests whether a value is in the range
        /// </summary>
        /// <param name="candidate">The value to test</param>
        /// <returns></returns>
        public bool In(T candidate)
            => candidate.CompareTo(Min) >= 0 
                && candidate.CompareTo(Max) <= 0;

        public override string ToString()
            => $"[{Min}, {Max}]";
    }
}