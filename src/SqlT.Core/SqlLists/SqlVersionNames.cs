//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

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
}