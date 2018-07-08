//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static minicore;

    public static class TimeX
    {
        public static IEnumerable<DateRange> Partition(this DateRange Period, int MaxLen)
            => from dates in Period.GetDates().Partition(MaxLen)
               let min = dates.First()
               let max = dates.Last()
               select min.To(max);

        /// <summary>
        /// Creates an integer of the form YYYYMMDD corresponding to a supplied date
        /// </summary>
        /// <param name="d">The date whose integer representation will be determined</param>
        /// <returns></returns>
        public static int ToDateKey(this DateTime d)
        {
            if (d.Date > new DateTime(2050, 1, 1))
                return 99991231;
            else if (d.Date < new DateTime(2000, 1, 1))
                return 0;
            else
                return Int32.Parse(d.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// Creates an integer of the form YYYYMMDD corresponding to a supplied date if the date 
        /// is not null and returns 0 otherwise
        /// </summary>
        /// <param name="d">The date whose integer representation will be determined</param>
        /// <returns></returns>
        public static int ToDateKey(this DateTime? d)
            => d != null ? d.Value.ToDateKey() : 0;

        public static int ToDateKey(this Date d)
        {
            if (d > new Date(2050, 1, 1))
                return 99991231;
            else if (d < new Date(2000, 1, 1))
                return 0;
            else
                return Int32.Parse(d.ToString("yyyyMMdd"));
        }

        public static int ToDateKey(this Date? d)
            => d != null ? d.Value.ToDateKey() : 0;

        public static int[] GetItemArray(this DateTime x, DateTimeAccuracy accuracy = DateTimeAccuracy.Millisecond)
        {
            switch (accuracy)
            {
                case DateTimeAccuracy.Date:
                    return array(x.Year, x.Month, x.Day);
                case DateTimeAccuracy.Hour:
                    return array(x.Year, x.Month, x.Day, x.Hour);
                case DateTimeAccuracy.Minute:
                    return array(x.Year, x.Month, x.Day, x.Hour, x.Minute);
                case DateTimeAccuracy.Second:
                    return array(x.Year, x.Month, x.Day, x.Hour, x.Minute, x.Second);
                case DateTimeAccuracy.Millisecond:
                    return array(x.Year, x.Month, x.Day, x.Hour, x.Minute, x.Second, x.Millisecond);
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// Represents a date value as an array of integers
        /// </summary>
        /// <param name="x">The date to convert to an array</param>
        /// <returns></returns>
        public static int[] GetItemArray(this Date x)
            => array(x.Year, x.Month, x.Day);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime x)
            => x.AddDays(-1);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DateTime LastMonth(this DateTime x)
            => x.AddMonths(-1);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DateTime NextMonth(this DateTime x)
            => x.AddMonths(1);

        public static Date EndOfYear(this Date x)
            => new Date(x.Year, 12, 31);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Date Yesterday(this Date x)
            => x.AddDays(-1);

        /// <summary>
        /// Returns the instant that is one day more than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime x)
            => x.AddDays(1);

        /// <summary>
        /// Returns the instant that is one day more than the specified instant
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Date Tomorrow(this Date x)
            => x.AddDays(1);

        public static Date FirstDayOfNextMonth(this Date x)
            => x.LastDayOfMonth.AddDays(1);

        public static Date LastDayOfPriorMonth(this Date x)
            => x.FirstDayOfMonth.AddDays(-1);


        /// <summary>
        /// Gets the time at which the day ends
        /// </summary>
        /// <param name="d">The instant in time</param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime d)
            => new DateTime(d.Year, d.Month, d.Day, 23, 59, 59, 999);

        /// <summary>
        /// Gets the time at which the day begins
        /// </summary>
        /// <param name="d">The instant in time</param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime d)
            => d.Date;


        /// <summary>
        /// Creates a contiguous range of dates within a supplied range
        /// </summary>
        /// <param name="min">The first date in the range</param>
        /// <param name="max">The last date in the range</param>
        /// <returns></returns>
        public static IReadOnlyList<DateTime> ContiguousDatesTo(this DateTime min, DateTime max)
        {
            var dates = new List<DateTime>();
            var currentDate = new DateTime(min.Year, min.Month, min.Day, 0, 0, 0, DateTimeKind.Local);
            while (currentDate <= max)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1.0);
            }
            return dates;
        }

        /// <summary>
        /// Creates a contiguous range of dates within a supplied range
        /// </summary>
        /// <param name="min">The first date in the range</param>
        /// <param name="max">The last date in the range</param>
        /// <returns></returns>
        public static IReadOnlyList<Date> ContiguousDatesTo(this Date min, Date max)
        {
            var dates = new List<Date>();
            var currentDate = new Date(min.Year, min.Month, min.Day);
            while (currentDate <= max)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }
            return dates;
        }

        /// <summary>
        /// Determines whether the <see cref="DateTime"/> values occur on the same day
        /// </summary>
        /// <param name="d">One subject</param>
        /// <param name="other">The other subject</param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime d, DateTime other)
            => d.Date == other.Date;

        /// <summary>
        /// Returns the number of seconds elapsed since midnight
        /// </summary>
        /// <param name="d">The subject</param>
        /// <returns></returns>
        public static int ToTimeKey(this DateTime d)
            => (int)(d - d.Date).TotalSeconds;

        /// <summary>
        /// Returns the number of seconds elapsed since midnight if date is not null, 0 otherwise
        /// </summary>
        /// <param name="d">The subject</param>
        /// <returns></returns>
        public static int ToTimeKey(this DateTime? d)
            => d != null ? d.Value.ToTimeKey() : 0;

        /// <summary>
        /// Returns the <see cref="Date"/> part of the supplied <see cref="DateTime"/>
        /// </summary>
        /// <param name="d">The subject</param>
        /// <returns></returns>
        public static Date ToDate(this DateTime d)
            => new Date(d.Year, d.Month, d.Day);

        /// <summary>
        /// Renders a <see cref="DateTime"/> to the form YYYY-MM-DD
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToLexicalDateString(this DateTime t)
            => t.ToLexicalString(DateTimeAccuracy.Date);
    }
}
