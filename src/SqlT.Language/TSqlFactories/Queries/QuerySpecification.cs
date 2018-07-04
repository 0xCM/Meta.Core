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

    partial class TSqlFactory
    {
        /// <summary>
        /// Produces a <see cref="TSql.QuerySpecification"/> initialized with a set of <see cref="TSql.SelectElement"/> elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static TSql.QuerySpecification TSqlQuerySpecification<T>(this IEnumerable<T> src)
            where T : TSql.SelectElement
        {
            var dst = new TSql.QuerySpecification();
            dst.SelectElements.AddRange(src);
            return dst;
        }

        [TSqlBuilder]
        public static TSql.QuerySpecification Query<T>(this IEnumerable<T> src)
            where T : TSql.SelectElement
                => src.TSqlQuerySpecification();
    }
}