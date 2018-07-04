//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlVersions
    {
        public static readonly SqlVersion Sql2005 = SqlVersionNames.Sql2005;
        public static readonly SqlVersion Sql2008 = SqlVersionNames.Sql2008;
        public static readonly SqlVersion Sql2008R2 = SqlVersionNames.Sql2008R2;
        public static readonly SqlVersion Sql2012 = SqlVersionNames.Sql2012;
        public static readonly SqlVersion Sql2014 = SqlVersionNames.Sql2014;
        public static readonly SqlVersion Sql2016 = SqlVersionNames.Sql2016;
        public static readonly SqlVersion Sql2017 = SqlVersionNames.Sql2017;
        public static readonly SqlVersion Latest = Sql2017;

        static HashSet<SqlVersion> _all
            = new HashSet<SqlVersion>(new[] { Sql2005, Sql2008, Sql2008R2, Sql2012, Sql2014, Sql2016, Sql2017 });

        public static readonly SqlVersion Default = _all.Last();

        public static bool Exists(SqlVersion version)
            => _all.Contains(version);

        public static SqlVersion Get(string VersionName)
            => _all.Single(x => x.Name == VersionName);
    }
}
