//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using static minicore;
using Meta.Core;

/// <summary>
/// Represents a contiguous finite interval of time with calendar day resolution
/// </summary>
public readonly struct DateRange : IInterval<Date>
{
    /// <summary>
    /// Converts a <see cref="DateRange"/> value to a <see cref="TimestampRange"/> value
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator TimestampRange(DateRange x)
        => new TimestampRange(x.Min.ToDateTime().StartOfDay(), x.Min.ToDateTime().EndOfDay());

    /// <summary>
    /// Converts a <see cref="DateRange"/> value to a <see cref="Range{DateTime}"/> value
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator Range<DateTime>(DateRange x)
        => new Range<DateTime>(x.Min.ToDateTime().StartOfDay(), x.Max.ToDateTime().EndOfDay());

    /// <summary>
    /// Produces a <see cref="DateRange"/> that [begins | ends] on the [first | last] day of a given year
    /// </summary>
    /// <param name="Year">The year on which the range will be based</param>
    /// <returns></returns>
    public static DateRange FY(int Year)
        => new DateRange(new Date(Year, 1, 1), new Date(Year, 12, 1).EndOfMonth());

    /// <summary>
    /// Produces a <see cref="DateRange"/> that begins on the first day of the year
    /// and ends on the last day of the sixth month of that year
    /// </summary>
    /// <param name="Year">The year on which the range will be based</param>
    /// <returns></returns>
    public static DateRange Q1(int Year)
        => new DateRange(new Date(Year, 1, 1), new Date(Year, 3, 1).EndOfMonth());

    /// <summary>
    /// Produces a <see cref="DateRange"/> that begins on the first day of the fourth month 
    /// and ends on the last day of the sixth month of a specified year
    /// </summary>
    /// <param name="Year">The year on which the range will be based</param>
    /// <returns></returns>
    public static DateRange Q2(int Year)
        => new DateRange(new Date(Year, 4, 1), new Date(Year, 6, 1).EndOfMonth());

    /// <summary>
    /// Produces a <see cref="DateRange"/> that begins on the first day of the seventh month 
    /// and ends on the last day of the ninth month of a specified year
    /// </summary>
    /// <param name="Year">The year on which the range will be based</param>
    /// <returns></returns>
    public static DateRange Q3(int Year)
        => new DateRange(new Date(Year, 7, 1), new Date(Year, 9, 1).EndOfMonth());

    /// <summary>
    /// Produces a <see cref="DateRange"/> that begins on the first day of the tenth month 
    /// and ends on the last day of the of a specified year
    /// </summary>
    /// <param name="Year">The year on which the range will be based</param>
    /// <returns></returns>
    public static DateRange Q4(int Year)
        => new DateRange(new Date(Year, 10, 1), new Date(Year, 12, 1).EndOfMonth());

    /// <summary>
    /// Produces a date range from a 2-tuple
    /// </summary>
    /// <param name="x"></param>
    public static implicit operator DateRange((Date Min, Date Max) x)
        => new DateRange(x.Min, x.Max);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DateRange"/> type
    /// </summary>
    /// <param name="min">The inclusive lower bound of the period</param>
    /// <param name="max">The inclusive upper bound of the period</param>
    public DateRange(Date min, Date max)
    {
        this.Min = min;
        this.Max = max;
    }

    /// <summary>
    /// The inclusive lower bound
    /// </summary>
    public Date Min { get; }

    /// <summary>
    /// The inclusive upper bound
    /// </summary>
    public Date Max { get; }

    /// <summary>
    /// Determines whether the test value is within the range
    /// </summary>
    /// <param name="test"></param>
    /// <returns></returns>
    public bool In(Date test)
        => test >= Min && test <= Max;

    /// <summary>
    /// Determines whether the test value is outside the range
    /// </summary>
    /// <param name="test"></param>
    /// <returns></returns>
    public bool Out(Date test)
        => test < Min || test > Max;

    /// <summary>
    /// Produces a montnly <see cref="DateRange"/> sequence 
    /// </summary>
    /// <param name="min">The inclusive minimum month</param>
    /// <param name="max">The inclusive maximum month</param>
    /// <returns></returns>
    public static IEnumerable<DateRange> Months(Date min, Date max)
    {
        var start = new DateRange(min.FirstDayOfMonth, min.LastDayOfMonth);
        var end = new DateRange(max.FirstDayOfMonth, max.LastDayOfMonth);
        var next = start;
        if (next.Min == end.Min)
            yield return start;
        else
        {
            while (next.Min <= end.Max)
            {
                yield return next;
                next = next.AddMonth().Round();
            }
        }
    }

    DateRange Round()
        => new DateRange(Min.FirstDayOfMonth, Max.LastDayOfMonth);

    /// <summary>
    /// Creates the points in a range partition satisfying the specified width
    /// </summary>
    /// <param name="width">The width between partition points</param>
    /// <returns></returns>
    public IReadOnlyList<Date> CreatePartitionPoints(int width)
    {
        var points = MutableList.FromItems(stream(Min));
        var last = Min;
        var finished = false;
        while (!finished)
        {
            var next = last.AddDays(width);
            if (next >= Max)
            {
                points.Add(Max);
                finished = true;
            }
            else
            {
                points.Add(next);
                last = next;
            }
        }

        return points;
    }

    public DateRange AddMonth()
        => new DateRange(Min.AddMonths(1), Max.AddMonths(1));

    /// <summary>
    /// The days that comprise the range
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Date> GetDates()
    {
        foreach (var i in Enumerable.Range(0, TotalDays + 1))
            yield return Min.AddDays(i);
    }

    /// <summary>
    /// The number of days in the range
    /// </summary>
    public int TotalDays 
        => Max.DaysSince(Min);


    bool IInterval.LeftInclusive
        => true;

    bool IInterval.RightInclusive
        => true;

    /// <summary>
    /// Returns the range intersection where, if empty, none is returned
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public Option<DateRange> Intersect(DateRange y)
    {
        var dates = GetDates().Intersect(y.GetDates()).ToList();
        return dates.Any() 
            ? dates.Min().To(dates.Max()) 
            : none<DateRange>();
    }

    /// <summary>
    /// Specifies whether the left and right boundaries are equal
    /// </summary>
    public bool IsDegenerate
        => Min == Max;

    object IInterval.Min
        => Min;

    object IInterval.Max
        => Max;

    public override string ToString()
        => $"[{Min.ToIsoString()},{Max.ToIsoString()}]";

    public string ToIntervalString()
        => ToString();

    public string ToDelimitedString(char delimiter = '.')
        => $"{Min.ToIsoString()}{delimiter}{Max.ToIsoString()}";

}

