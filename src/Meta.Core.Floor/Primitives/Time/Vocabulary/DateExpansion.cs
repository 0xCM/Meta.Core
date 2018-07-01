//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   

    public partial struct Date
    {

        /// <summary>
        /// Defines a <see cref="DateRange"/> bounded below by <paramref name="MinDate"/>
        /// and above by <paramref name="MaxDate"/>
        /// </summary>
        /// <param name="MinDate">The range minimum</param>
        /// <param name="MaxDate">The range maximum</param>
        /// <returns></returns>
        public static DateRange Between(Date MinDate, Date MaxDate)
            => new DateRange(MinDate, MaxDate);

        public static Date Jan(int Year, byte Day = 1)
            => new Date(Year, 1, Day);

        public static Date Feb(int Year, byte Day = 1)
            => new Date(Year, 2, Day);

        public static Date Mar(int Year, byte Day = 1)
            => new Date(Year, 3, Day);

        public static Date Apr(int Year, byte Day = 1)
            => new Date(Year, 4, Day);

        public static Date May(int Year, byte Day = 1)
            => new Date(Year, 5, Day);

        public static Date Jun(int Year, byte Day = 1)
            => new Date(Year, 6, Day);

        public static Date Jul(int Year, byte Day = 1)
            => new Date(Year, 7, Day);

        public static Date Aug(int Year, byte Day = 1)
            => new Date(Year, 8, Day);

        public static Date Sep(int Year, byte Day = 1)
            => new Date(Year, 9, Day);

        public static Date Oct(int Year, byte Day = 1)
            => new Date(Year, 10, Day);

        public static Date Nov(int Year, byte Day = 1)
            => new Date(Year, 11, Day);

        public static Date Dec(int Year, byte Day = 1)
            => new Date(Year, 12, Day);

        public Date EndOfMonth()
              => new Date(Year, Month, this.AddMonths(1).AddDays(-1).Day);
            //=> LastDayOfMonth;

        public Date FirstOfMonth()
            => FirstDayOfMonth;

        public DateRange To(Date MaxDate)
            => new DateRange(this, MaxDate);

        public DateRange ToEndOfMonth()
            => new DateRange(this, this.EndOfMonth());

        public DateRange FromFirstOfMonth()
            => new DateRange(FirstOfMonth(), this);

        public DateRange FromFirstDayOfLastMonth()
            => new DateRange(this.AddMonths(-1).FirstOfMonth(), this);

        public DateRange ToLastDayOfNextMonth()
            => new DateRange(this, this.AddMonths(1).EndOfMonth());

        public bool IsBetween(Date MinDate, Date MaxDate)
            => this >= MinDate && this <= MaxDate;

        public bool IsIn(DateRange Range)
            => IsBetween(Range.Min, Range.Max);

        public static IEnumerable<Date> Parse(string first, string second, params string[] more)
        {
            yield return Parse(first);
            yield return Parse(second);
            foreach (var next in more)
                yield return Parse(next);
        }

        public static IEnumerable<Date> Days(Date min, Date max)
        {
            var current = min;
            while (current <= max)
            {
                yield return current;
                current = current.AddDays(1);
            }
        }

        public static IEnumerable<Date> Years(int min, int max)
        {
            var current = new Date(min, 1, 1);
            var maxYear = new Date(max, 1, 1);
            while (current <= maxYear)
            {
                yield return current;
                current = current.AddYears(1);
            }

        }

        public static implicit operator Date(string x) 
            => Date.Parse(x);

        public DateTime ToDateTime() 
            => new Date(Year, Month, Day);

        public Date FirstDayOfMonth
            => new Date(Year, Month, 1);

        public Date LastDayOfMonth
            => new Date(Year, Month + 1, 1).AddDays(-1);

        /// <summary>
        /// Renders a <see cref="Date"/> to the form YYYY-MM-DD
        /// </summary>
        /// <returns></returns>
        public string ToLexicalString()
            => this.ToString("yyyy-MM-dd");

        public Date(string x)
        {
            var _parsed = Date.Parse(x);
            _dayNumber = DateToDayNumber(_parsed.Year, _parsed.Month, _parsed.Day);
        }


    }

}