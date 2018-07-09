//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static SqlT.Models.SqlModelBuilders;
    using static metacore;

    public static class SqlProxyX
    {
        static readonly IApplicationContext C = ApplicationContext.Create(Dependencies);

        static IEnumerable<Assembly> Dependencies
            => stream(SqlTServices.CoreDependencies, stream(SqlTServices.Assembly, SqlTModels.Assembly, SqlTCore.Assembly));

        /// <summary>
        /// Constructs a proxy-based merge procedure
        /// </summary>
        /// <param name="SourceType">The proxy source type</param>
        /// <param name="ProcName">The name of the generated procedure</param>
        /// <param name="TargetType">The proxy target type</param>
        /// <param name="MatchColumn">The merge match column</param>
        /// <param name="Sync">Specifies whether the source and target should be syhnchronized via the "if not matched by source then delete" construct</param>
        /// <returns></returns>
        public static SqlModelScript MergeFrom(this SqlTableTypeProxyInfo SourceType, SqlProcedureName ProcName, Type TargetType, ClrPropertyName MatchColumn, bool Sync)
            => ~ from p in Procedure(ProcName)
               from m in Merge(SourceType.RuntimeType, TargetType, true, Sync)
               from x in m.Map(MatchColumn, MatchColumn, true)
               let merge = m.Complete()
               let recordType = PXM.TableTypeName(SourceType.RuntimeType).Reference()
               from s in p.WithStatements(merge)
               from args in p.WithParameters(new SqlRoutineParameter("Records", recordType, true))
               let proc = p.Complete()
               let sql = C.SqlGenerator().GenerateScript(proc)
               select sql;

        /// <summary>
        /// Renders a proxy value to delimited text
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="proxy">The proxy value to format</param>
        /// <param name="delimiter">The field value demarcator</param>
        /// <returns></returns>
        public static string ToDelimitedString<P>(this P proxy, char delimiter = '|')
            where P : class, ISqlTabularProxy, new()
            => C.SqlProxyFormatter().FormatDelimited(seq(proxy),
                new DelimitedTextDescription(true, delimiter)).Single().Require().Target.Data;

        /// <summary>
        /// Renders a sequence of proxy values to delimited text
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="proxies">The proxy values</param>
        /// <param name="delimiter">The field value demarcator</param>
        /// <returns></returns>
        public static Seq<Link<P,TextLine>> ToDelimitedText<P>(this Seq<P> proxies, char delimiter = '|')
            where P : class, ISqlTabularProxy, new()
                => C.SqlProxyFormatter().FormatDelimited(proxies, new DelimitedTextDescription(true, delimiter));

        /// <summary>
        /// Renders a proxy value to Json
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="proxy">The proxy value to render</param>
        /// <returns></returns>
        public static Json ToJson<P>(this P proxy)
            where P : class, ISqlTabularProxy, new()
                => C.JsonSerializer().ObjectToJson(proxy);

        /// <summary>
        /// Renders a stream of proxy values to json
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <param name="proxies">The proxy values</param>
        /// <returns></returns>
        public static Json ToJson<P>(Seq<P> proxies)
            where P : class, ISqlTabularProxy, new()
                => C.JsonSerializer().ObjectToJson(proxies.AsList());
    }
}