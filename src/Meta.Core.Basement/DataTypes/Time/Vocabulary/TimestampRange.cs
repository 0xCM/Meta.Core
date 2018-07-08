//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using Meta.Core;

    using static minicore;

    /// <summary>
    /// Represents a finite interval of time with (at least) millisecond resolution
    /// </summary>
    public struct TimestampRange : IRange<DateTime>
    {
        /// <summary>
        /// Converts the range to a 2-tuple
        /// </summary>
        /// <param name="x">The range to convert</param>
        public static implicit operator (DateTime Min, DateTime Max) (TimestampRange x)
            => (x.Min, x.Max);

        /// <summary>
        /// Converts a 2-tuple to a range
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator TimestampRange((DateTime Min, DateTime Max) x)
            => new TimestampRange(x.Min, x.Max);

        /// <summary>
        /// Creates a <see cref="TimestampRange"/> from the supplied lower and upper bounds
        /// </summary>
        /// <param name="Min">The inclusive minimum</param>
        /// <param name="Max">The inclusive maximum</param>
        /// <returns></returns>
        public static TimestampRange Create(DateTime Min, DateTime Max)
            => new TimestampRange(Min, Max);

        /// <summary>
        /// Initializes a new instance of the <see cref="TimestampRange"/> type
        /// </summary>
        /// <param name="Min">The inclusive lower bound of the interval</param>
        /// <param name="Max">The inclusive upper bound of the interval</param>
        public TimestampRange(DateTime Min, DateTime Max)
        {
            this.Min = Min;
            this.Max = Max;
        }

        /// <summary>
        /// The inclusive lower bound
        /// </summary>
        public DateTime Min { get; }

        /// <summary>
        /// The inclusive upper bound
        /// </summary>
        public DateTime Max { get; }

        bool IInterval.LeftInclusive
            => true;

        bool IInterval.RightInclusive
            => true;

        object IInterval.Min
            => Min;

        object IInterval.Max
            => Max;

        public override string ToString()
                => concat("[", Min.ToLexicalString(), ",", space(), Max.ToLexicalString(), "]");
    }
}