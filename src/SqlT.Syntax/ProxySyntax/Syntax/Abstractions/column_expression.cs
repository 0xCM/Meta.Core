//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Models;

    partial class SqlProxySyntax
    {

        public class column_expression<T> : proxy_expression<SqlColumnProxySelection, T>, sxc.column_name
               where T : ISqlTabularProxy, new()

        {
            public column_expression(SqlColumnProxyInfo ColumnInfo)
                : base(new SqlColumnProxySelection(ColumnInfo))
            {

            }


            public string Format()
                => Operand.HasColumnAlias
                ? $"{ Operand.ColumnName} as {Operand.ColumnAlias}"
                : Operand.ColumnName.ToString();

            public SqlIdentifier Identifier
                => new SqlIdentifier(Operand.ColumnName.UnquotedLocalName, Operand.ColumnName.quoted);

            public override string ToString()
                => Format();
        }

    }
}