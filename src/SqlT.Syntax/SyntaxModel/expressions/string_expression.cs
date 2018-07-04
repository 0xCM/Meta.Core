//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;

    using sx = Syntax.SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class string_expression : SyntaxExpression<string_expression>
        {

            public static implicit operator string(string_expression text)
                => text.text;

            public static implicit operator string_expression(string text)
                => new string_expression(text);

            public string_expression(string text)
            {
                this.text = text;
            }

            public string text { get; }

            public override string ToString()
                => text;
        }

    }
}