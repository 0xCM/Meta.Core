//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public enum SqlVersionIndicator : byte
    {
        Sql2005 = 90,
        Sql2008 = 100,
        Sql2008R2 = 105,
        Sql2012 = 110,
        Sql2014 = 120,
        Sql2016 = 130,
        Sql2017 = 140
    }

    public struct SqlVersion 
    {

        public static implicit operator SqlVersion(string x) 
            => new SqlVersion(x);

        public SqlVersion(Version v)
        {
            Name = $"{v.Major}.{v.Minor.ToString().PadRight(2, '0')}";
        }

        public SqlVersion(string Name)
        {
            if (!SqlVersionNames.Contains(Name))
                throw new ArgumentException($"The version {Name} is not recognized");

            this.Name = Name;
        }

        public string Name { get; }

        public override string ToString() 
            => Name;
    }

    public class SqlVersionNames : TypedItemList<SqlVersionNames, string>
    {
        public const string Sql2005 = "9.00";
        public const string Sql2008 = "10.00";
        public const string Sql2008R2 = "10.50";
        public const string Sql2012 = "11.00";
        public const string Sql2014 = "12.00";
        public const string Sql2016 = "13.00";
        public const string Sql2017 = "14.00";
    }

    public static class SqlVersionExtensions
    {
        public static string GetVersionName(this SqlVersionIndicator indicator)
        {
            switch (indicator)
            {
                case SqlVersionIndicator.Sql2005: return SqlVersionNames.Sql2005;
                case SqlVersionIndicator.Sql2008: return SqlVersionNames.Sql2008;
                case SqlVersionIndicator.Sql2008R2: return SqlVersionNames.Sql2008R2;
                case SqlVersionIndicator.Sql2012: return SqlVersionNames.Sql2012;
                case SqlVersionIndicator.Sql2014: return SqlVersionNames.Sql2014;
                case SqlVersionIndicator.Sql2016: return SqlVersionNames.Sql2016;
                case SqlVersionIndicator.Sql2017: return SqlVersionNames.Sql2017;
                default:
                    throw new NotSupportedException($"The SQL Version {indicator} is unrecognized");
            }
        }

        public static SqlVersion GetVersion(this SqlVersionIndicator indicator)
            => new SqlVersion(indicator.GetVersionName());

    }

}
