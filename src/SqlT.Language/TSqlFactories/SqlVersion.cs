//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        public static TSql.SqlVersion TSqlDomVersion(this SqlVersion v)
        {
            switch (v.Name)
            {
                case SqlVersionNames.Sql2005:
                    return TSql.SqlVersion.Sql90;
                case SqlVersionNames.Sql2008:
                case SqlVersionNames.Sql2008R2:
                    return TSql.SqlVersion.Sql100;
                case SqlVersionNames.Sql2012:
                    return TSql.SqlVersion.Sql110;
                case SqlVersionNames.Sql2014:
                    return TSql.SqlVersion.Sql120;
                case SqlVersionNames.Sql2016:
                    return TSql.SqlVersion.Sql130;
                case SqlVersionNames.Sql2017:
                    return TSql.SqlVersion.Sql140;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}