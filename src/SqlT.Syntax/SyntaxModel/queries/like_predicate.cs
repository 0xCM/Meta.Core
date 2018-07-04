namespace SqlT.Syntax
{
    using System;

    using Meta.Syntax;

    using sxc = contracts;

    partial class SqlSyntax
    {

        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/queries/search-condition-transact-sql
        /// </summary>
        public sealed class like_expression : BooleanExpression<like_expression>
        {

            public like_expression(ISyntaxExpression match_expression, string pattern, bool not = false,  char? escape_character = null)
            {
                this.match_expression = match_expression;
                this.pattern = pattern;
                this.escape_character = escape_character;
                this.not = not;
                
            }

            public ISyntaxExpression match_expression { get; }

            public string pattern { get; }

            public bool not { get; }

            public char? escape_character { get; }

            public override string ToString()
                => not 
                ? $"{match_expression} {NOT} {LIKE} {pattern}"
                : $"{match_expression} {LIKE} {pattern}";

        }

        public sealed class like_predicate : predicate<like_expression>
        {

            public static implicit operator like_predicate(like_expression e)
                => new like_predicate(e);

            public like_predicate(like_expression e)
                : base(e)
            {


            }
        }

    }
}