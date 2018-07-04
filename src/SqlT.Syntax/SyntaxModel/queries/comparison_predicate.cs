namespace SqlT.Syntax
{
    using System;
    using sxc = contracts;

    partial class SqlSyntax
    {
        public sealed class comparison_predicate : predicate<comparison_expression>
        {
            public static implicit operator predicate(comparison_predicate p)
                => new predicate(p);

            public static implicit operator comparison_expression(comparison_predicate p)
                => new comparison_expression(p.expression.op, p.expression.Left, p.expression.Right);

            public comparison_predicate(comparison_expression e)
                : base(e)
            { }
        }

    }
}
