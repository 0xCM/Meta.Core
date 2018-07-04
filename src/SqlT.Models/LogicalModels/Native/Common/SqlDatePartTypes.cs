//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    /// <summary>
    /// See https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql
    /// </summary>
    public class SqlDatePartTypes : TypedItemList<SqlDatePartTypes, SqlDatePartType>
    {
        public static readonly SqlDatePartType year = new SqlDatePartType("year", "yy", "yyyy");
        public static readonly SqlDatePartType quarter = new SqlDatePartType("quarter", "qq", "q");
        public static readonly SqlDatePartType month = new SqlDatePartType("month", "mm", "m");
        public static readonly SqlDatePartType dayofyear = new SqlDatePartType("dayofyear", "dy", "y");
        public static readonly SqlDatePartType day = new SqlDatePartType("day", "dd", "d");
        public static readonly SqlDatePartType week = new SqlDatePartType("week", "dw", "");
        public static readonly SqlDatePartType weekday = new SqlDatePartType("weekday", "", "");
        public static readonly SqlDatePartType hour = new SqlDatePartType("hour", "hh", "");
        public static readonly SqlDatePartType minute = new SqlDatePartType("minute", "mi", "n");
        public static readonly SqlDatePartType second = new SqlDatePartType("second", "ss", "s");
        public static readonly SqlDatePartType millisecond = new SqlDatePartType("millisecond", "ms", "");
        public static readonly SqlDatePartType microsecond = new SqlDatePartType("microsecond", "mcs", "");
        public static readonly SqlDatePartType nanosecond = new SqlDatePartType("nanosecond", "ns");
        public static readonly SqlDatePartType TZoffset = new SqlDatePartType("TZoffset", "tz");
        public static readonly SqlDatePartType ISO_WEEK = new SqlDatePartType("ISO_WEEK", "isowk", "isoww");

    }
}
