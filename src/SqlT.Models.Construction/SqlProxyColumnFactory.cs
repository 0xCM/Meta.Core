//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Meta.Core;
    using SqlT.Models;
    using SqlT.Core;

    using static SqlT.Core.SqlProxyMetadataProvider;

    using sxc = contracts;

    public static class SqlProxyColumnFactory
    {
        static ISqlProxyMetadataProvider metadata<P>()
           where P : ISqlProxy
               => typeof(P).Assembly.SqlProxyMetadataIndex();

        static SqlColumnProxyInfo column_proxy<P>(string member)
            where P : ISqlTabularProxy
                => metadata<P>().Column<P>(member);

        static SqlColumnProxyInfo column_proxy<P, C>(Expression<Func<P, C>> selector)
            where P : ISqlTabularProxy
                => metadata<P>().Column(selector);

        static IReadOnlyList<SqlColumnProxyInfo> column_proxies<P>()
            where P : ISqlTabularProxy
                => metadata<P>().Columns<P>();

        public static SqlColumnDefinition column<P>(string member, int? newpos = null)
            where P : ISqlTabularProxy, new()
                => column_proxy<P>(member).DefineSqlColumn(newpos: newpos);

        public static SqlColumnDefinition column<P>(Expression<Func<P, object>> selector, string newname = null, int? newpos = null)
            where P : ISqlTabularProxy, new()
                => column_proxy(selector).DefineSqlColumn(newname, newpos);

        public static ReadOnlyList<SqlColumnDefinition> columns<P>(int startpos = 0)
            where P : ISqlTabularProxy, new()
                => SqlTableColumn.ReplicateAll<P>(startpos).Map(x => x.Definition);

        public static ReadOnlyList<SqlColumnDefinition> columns<P>(IEnumerable<string> members, int startpos = 0)
            where P : ISqlTabularProxy, new()
                => SqlTableColumn.ReplicateSelected<P>(startpos, members.ToArray()).Map(x => x.Definition);

        public static ReadOnlyList<SqlColumnDefinition> columns<P>(int startpos, params Expression<Func<P, object>>[] selectors)
            where P : ISqlTabularProxy, new()
                => columns<P>(selectors.Map(s => s.GetValueMember().Name), startpos);

        public static ReadOnlyList<SqlColumnDefinition> columns<P>(params Expression<Func<P, object>>[] selectors)
            where P : ISqlTabularProxy, new()
                => columns(0, selectors);

        public static ReadOnlyList<SqlColumnDefinition> columns<P>(IEnumerable<Expression<Func<P, object>>> selectors, int startpos = 0)
            where P : ISqlTabularProxy, new()
                => columns<P>(selectors.Map(s => s.GetValueMember().Name), startpos);
    }
}