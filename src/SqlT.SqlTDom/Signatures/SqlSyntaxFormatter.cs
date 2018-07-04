//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{

    using static metacore;
    using System.Linq;
    using System.Text;
    using SqlT.Language;
    using SqlT.Services;
    using System.Collections.Generic;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using Microsoft.SqlServer.TransactSql.ScriptDom;
    static class SqlSyntaxFormatter
    {


        public static string SyntaxFileHeader()
            => $"--Syntax representation conjured on {today()} at {now().ToString("T")}{eol()}";


        public static string Format(this FragmentToken token)
            => toString(token.TokenizedValue);


        public static string Format(this SqlSyntaxSignature sig)
            => $"{sig.SourceScript.ScriptName}:=>{eol()}{tab()}{sig.Transpilation}";

        public static string Format(this CollectionAssignment assignment)
            => SyntaxBlockFormatter.FormatBlock(assignment);

        public static string Format(this FragmentAssignment assignment)
            => SyntaxBlockFormatter.FormatBlock(assignment);

        public static string Format(this ScalarAssignment assignment)
            => SyntaxBlockFormatter.FormatBlock(assignment);
        public static string Format(this ScalarAssignments assignments, int TokenLevel)
            => SyntaxBlockFormatter.FormatBlock(assignments);

        public static string Format(this FragmentAssignments assignments, int TokenLevel)
            => SyntaxBlockFormatter.FormatBlock(assignments);

        public static string Format(this CollectionAssignments assignments, int TokenLevel)
            => SyntaxBlockFormatter.FormatBlock(TokenLevel, assignments, false);

        public static string Format(this SignatureToken token, int level)
            => SyntaxBlockFormatter.FormatBlock(level, token.ToString());

        public static string Format(this LiteralToken token)
        {

            switch (token.LiteralType)
            {
                case 
                    LiteralType.String:                    
                    return $"literal({squote(token.LiteralValue)})";
                default:
                    return $"literal({token.LiteralValue})"; 

            }

        }

        static string FormatRaw(this IdentifierToken token)
            => token.Identifier.TSqlQuote(token.QuoteType);

        static string FormatRaw(this CompositeIdentifierToken token)
            => string.Join(".", token.Identifiers.Select(FormatRaw));

        public static string Format(this IdentifierToken token)
            => $"identifier({token.FormatRaw()})";

        public static string Format(this ValueExpressionToken expressionToken)
            => $"{expressionToken.Expression}";


        public static string Format(this CompositeIdentifierToken token)
            => $"identifier({token.FormatRaw()})";
    }

    class SyntaxBlockFormatter
    {

        const char indent_char = '\t';
        static readonly string block_opener = "{";
        static readonly string block_closer = "}";

        static string indent(int level)
            => new string(indent_char, level);

        static string FormatTokenBlock(int BlockLevel, FragmentTokens content, bool embrace = true)
            => string.Join(",", (from c in content
                                 let fmt = c.Format()
                                 where not(isBlank(fmt))
                                 select FormatBlock(BlockLevel, fmt, embrace)));

        public static string FormatBlock(ScalarAssignments assignments)
            => string.Join("", assignments.Select(t => FormatBlock(t).ToArray()));

        public static string FormatBlock(FragmentAssignments assignments)
            => string.Join("", assignments.Select(t => FormatBlock(t).ToArray()));

        public static string FormatBlock(ScalarAssignment token)
            => $"{eol()}{indent(token.TokenLevel + 1)}{token.Property.Name}:={token.Value}";

        public static string FormatBlock(FragmentAssignment token)
            => $"{eol()}{indent(token.TokenLevel + 1)}{token.Property.Name}->"
                + FormatTokenBlock(
                    token.TokenLevel + 1, FragmentTokens.One(token.Fragment), true);

        public static string FormatBlock(CollectionAssignment assignment)
        {
            var sb = new StringBuilder();

            sb.Append($"{eol()}{indent(assignment.TokenLevel + 1)}{assignment.Property.Name}->*");
            sb.Append($"{eol()}{indent(assignment.TokenLevel + 1)}{block_opener}");
            for (int i = 0; i< assignment.Tokens.Count; i++)
            {
                var token = assignment.Tokens[i];
                sb.Append($"{eol()}{indent(token.TokenLevel + 2)}" + token.Format());
                if (i < assignment.Tokens.Count - 1)
                    sb.Append(",");
                
            }
            sb.Append($"{eol()}{indent(assignment.TokenLevel + 1)}{block_closer}");
            return sb.ToString();
        }

        public static string FormatBlock(int BlockLevel, CollectionAssignments assignments, bool embrace = true)
            => string.Join(",", (from c in assignments
                                 let fmt = c.Format(BlockLevel)
                                 where not(isBlank(fmt))
                                 select FormatBlock(BlockLevel, fmt, embrace)));


        public static string FormatBlock(int level, string content, bool embrace = true)
        {

            var blockOffset = new string(indent_char, level);
            var contentOffset = new string(indent_char, level + 1);
            var blockOpener = embrace ? block_opener : string.Empty;
            var blockCloser = embrace ? block_closer : string.Empty;
            var openBlock = $"{eol()}{blockOffset}{blockOpener}{eol()}";
            var contentBlock = $"{contentOffset}{content}";
            var closeBlock = $"{eol()}{blockOffset}{blockCloser}";
            return $"{openBlock}{contentBlock}{closeBlock}";

        }

    }

}