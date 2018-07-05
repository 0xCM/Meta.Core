//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using SqlT.Models;
    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Identifies a table type
    /// </summary>
    public sealed class SqlTableTypeRef : SqlModel<SqlTableTypeRef>, sxc.table_type_ref
    {
        public SqlTableTypeRef(SqlTableTypeName type_name)
        {
            this.type_name = type_name;
            this.nullable = false;
        }

        SqlTypeName sxc.type_ref.type_name { get; }

        public bool nullable { get; }


        public bool is_table_type
            => true;

        public SqlTableTypeName type_name { get; }            
    }
}