//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;

    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    partial class SqlSyntax
    {

        public sealed class identifier_expression : SyntaxExpression<identifier_expression>, 
            sxc.literal_value<identifier_expression>
        {

            public static implicit operator identifier_expression(SqlIdentifier value)
                => new identifier_expression(value);

            public identifier_expression(SqlIdentifier value)
            {
                this.value = value;
            }

            object sxc.literal_value.value
                => this.value;

            public identifier_expression value { get; }

        }

    }
}