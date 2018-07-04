//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Services;

    using static SqlT.Models.SqlModelBuilders;
    using static metacore;

    public static class SqlProxyX
    {
        static readonly IApplicationContext C = ApplicationContext.Create(Dependencies);

        static IEnumerable<Assembly> Dependencies
            => stream(SqlTServices.CoreDependencies, stream(SqlTServices.Assembly, SqlTModels.Assembly, SqlTCore.Assembly));

        public static SqlModelScript MergeFrom(this SqlTableTypeProxyInfo SourceType, SqlProcedureName Name, Type TargetType, ClrPropertyName MatchColumn, bool Sync)
            => ~ from p in Procedure(Name)
               from m in Merge(SourceType.RuntimeType, TargetType, true, Sync)
               from x in m.Map(MatchColumn, MatchColumn, true)
               let merge = m.Complete()
               let recordType = PXM.TableTypeName(SourceType.RuntimeType).Reference()
               from s in p.WithStatements(merge)
               from args in p.WithParameters(new SqlRoutineParameter("Records", recordType, true))
               let proc = p.Complete()
               let sql = C.SqlGenerator().GenerateScript(proc)
               select sql;

        public static string ToDelimitedString<P>(this P proxy, char delimiter = '|')
            where P : class, ISqlTabularProxy, new()
            => C.SqlProxyFormatter().FormatDelimited(stream(proxy), new DelimitedTextDescription(true, delimiter)).Single().Target.Data;

        public static IEnumerable<Link<P,TextLine>> ToDelimitedText<P>(this IEnumerable<P> proxies, char delimiter = '|')
            where P : class, ISqlTabularProxy, new()
                => C.SqlProxyFormatter().FormatDelimited(proxies, new DelimitedTextDescription(true, delimiter));

        public static Json ToJson<P>(this P proxy)
            where P : class, ISqlTabularProxy, new()
                => C.JsonSerializer().ObjectToJson(proxy);

        public static Json ToJson<P>(IEnumerable<P> proxies)
            where P : class, ISqlTabularProxy, new()
                => C.JsonSerializer().ObjectToJson(proxies.ToList());
    }
}