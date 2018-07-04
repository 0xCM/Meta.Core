//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using SqlT.Core;
    using sxc = contracts;

    partial class SqlSyntax
    {


        public sealed class column_ref : ElementReference<SqlColumnName>, sxc.column_ref
        {

            public static implicit operator column_ref(SqlColumnName x)
                => new column_ref(x);

            public static implicit operator SqlColumnName(column_ref x)
                => x.Referent;


            public column_ref(SqlColumnName ColumnName, SqlAliasName alias = null)
                : base(ColumnName, alias ?? SqlAliasName.Empty)

            {
                
            }

            public column_ref(sxc.column_name ColumnName, SqlAliasName alias = null)
                : base(new SqlColumnName(ColumnName), alias ?? SqlAliasName.Empty)

            {

            }

        }


    }
}