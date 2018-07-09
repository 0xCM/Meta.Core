//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    public static partial class SqlTFactory
    {
        /// <summary>
        /// Yields the names of the tables participating in a join with the subject
        /// </summary>
        /// <param name="reference">The subject</param>
        /// <returns></returns>
        [SqlTBuilder]
        public static IEnumerable<SqlTableName> JoiningTables(this TSql.TableReference reference)
        {
            if (reference.GetType() == typeof(TSql.NamedTableReference))
            {
                var ntr = (TSql.NamedTableReference)reference;
                yield return
                    ntr.SchemaObject.ToTableName();
            }
            else if (reference.GetType() == typeof(TSql.QualifiedJoin))
            {
                var qj = (TSql.QualifiedJoin)reference;
                foreach (var x in JoiningTables(qj.FirstTableReference))
                    yield return x;
                foreach (var x in JoiningTables(qj.SecondTableReference))
                    yield return x;
            }
            else if (reference.GetType() == typeof(TSql.JoinTableReference))
            {
                var qj = (TSql.JoinTableReference)reference;
                foreach (var x in JoiningTables(qj.FirstTableReference))
                    yield return x;
                foreach (var x in JoiningTables(qj.SecondTableReference))
                    yield return x;
            }
        }

        public static IReadOnlyList<SqlTableName> SourceTableNames(this TSql.SelectStatement src)
        {
            var tables = new List<SqlTableName>();
            if (src.QueryExpression is TSql.QuerySpecification)
            {
                var querySpec = src.QueryExpression as TSql.QuerySpecification;
                foreach (var sourceTable in querySpec.FromClause.TableReferences)
                {
                    tables.AddRange(sourceTable.JoiningTables());
                }
            }
            return tables;
        }

    }

}