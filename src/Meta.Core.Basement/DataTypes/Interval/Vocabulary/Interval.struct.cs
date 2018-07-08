//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    using static minicore;

    /// <summary>
    /// Represents the content of a contiguous interval between comparable lower and upper bounds of the same type
    /// </summary>
    /// <typeparam name="X">The interval data type</typeparam>
    public readonly struct Interval<X> : IInterval<X>
    {
        public static readonly Interval<X> Zero = new Interval<X>();

        static IntervalType Classify(bool MinIncluded, bool MaxIncluded)
        {
            if (MinIncluded && MaxIncluded)
                return IntervalType.Closed;

            if (not(MinIncluded) && not(MaxIncluded))
                return IntervalType.Open;

            if (not(MinIncluded) && MaxIncluded)
                return IntervalType.LeftOpen;

            return IntervalType.RightOpen;
        }

        public Interval(X Min, X Max, bool MinIncluded = true, bool MaxIncluded = true)
        {
            this.Min = Min;
            this.Max = Max;
            this.MinIncluded = MinIncluded;
            this.MaxIncluded = MaxIncluded;
            this.IntervalType = Classify(MinIncluded, MaxIncluded);
        }

        public Interval(X Min, X Max, IntervalType IntervalType = IntervalType.Closed)
        {
            this.Min = Min;
            this.Max = Max;
            this.MinIncluded = (IntervalType == IntervalType.Closed || IntervalType == IntervalType.RightOpen);
            this.MaxIncluded = (IntervalType == IntervalType.Closed || IntervalType == IntervalType.LeftOpen);
            this.IntervalType = IntervalType;
        }

        /// <summary>
        /// Specifies the interval's lower bound
        /// </summary>
        public X Min { get; }

        /// <summary>
        /// Specifies the interval's upper bound
        /// </summary>
        public X Max { get; }

        /// <summary>
        /// Specifies the interval's classification
        /// </summary>
        public IntervalType IntervalType { get; }

        /// <summary>
        /// specifies whether the interval includes its lower bound
        /// </summary>
        public bool MinIncluded { get; }

        /// <summary>
        /// Specifies whether the interval includes its upper bound
        /// </summary>
        public bool MaxIncluded { get; }


        object IInterval.Min
            => Min;

        object IInterval.Max
            => Max;

        bool IInterval.LeftInclusive
            => MinIncluded;

        bool IInterval.RightInclusive
            => MaxIncluded;

        /// <summary>
        /// Specifies whether the interval is closed
        /// </summary>
        public bool Closed
            => MinIncluded && MaxIncluded;

        public bool Open
            => not(MinIncluded) && not(MaxIncluded);

        public override string ToString()
            => (MinIncluded ? "[" : "(") + $"{Min}, {Max}" + (MaxIncluded ? "]" : ")");
    }
}

