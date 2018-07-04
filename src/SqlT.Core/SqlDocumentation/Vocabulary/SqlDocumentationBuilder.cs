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
    using System.Linq.Expressions;


    public static class SqlDocumentationBuilder
    {
        static Dictionary<string, ISqlTableDocumentationBuilder> Tables
            = new Dictionary<string, ISqlTableDocumentationBuilder>();

        public static SqlTableDocumentationBuilder<T> DescribeTable<T>(string Label, string Description, string Identifier = null)
            where T : ISqlTableProxy, new()
        {
            var builder = new SqlTableDocumentationBuilder<T>(Label, Description, Identifier);
            Tables.Add(builder.TableName, builder);
            return builder;
        }

        public static IEnumerable<SqlTableProxyDocumentation> GetTableDocumentation()
            => Tables.Values.Select(x => x.Documentation);

    }


}