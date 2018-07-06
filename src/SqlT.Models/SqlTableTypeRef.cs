//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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