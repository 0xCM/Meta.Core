//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using V1 = SqlSyntax.from_table_or_view;
    using V2 = SqlSyntax.from_rowset_function;
    using V3 = SqlSyntax.from_udf;
    using V4 = SqlSyntax.openxml_clause;
    using V5 = SqlSyntax.joined_table;
    using V6 = SqlSyntax.for_system_time;
    using V7 = SqlSyntax.from_table_variable;
    using DU = SqlSyntax.table_source;

    using sxc = contracts;


    using SqlT.Core;

    partial class SqlSyntax
    {

        [url("https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql")]
        public class table_source : du<V1, V2, V3, V4, V5, V6, V7>, sxc.table_source
        {

            public static implicit operator DU(SqlTableName table)
                => new DU(new V1(table));

            public static implicit operator DU(SqlViewName view)
                => new DU(new V1(view));


            public static implicit operator DU(V1 x)
                => new DU(x);

            public static implicit operator DU(V2 x)
                => new DU(x);

            public static implicit operator DU(V3 x)
                => new DU(x);

            public static implicit operator DU(V4 x)
                => new DU(x);

            public static implicit operator DU(V5 x)
                => new DU(x);

            public static implicit operator DU(V6 x)
                => new DU(x);

            public static implicit operator DU(V7 x)
                => new DU(x);

            public table_source(V1 v)
                : base(v) { }

            public table_source(V2 v)
                : base(v) { }

            public table_source(V3 v)
                : base(v) { }

            public table_source(V4 v)
                : base(v) { }

            public table_source(V5 v)
                : base(v) { }

            public table_source(V6 v)
                : base(v) { }

            public table_source(V7 v)
                : base(v) { }
        }
    }

}