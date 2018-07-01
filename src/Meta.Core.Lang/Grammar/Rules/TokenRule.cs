//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Requires the presence of a specific token
    /// </summary>
    public class TokenRule : SyntaxRule<TokenRule>
    {
        public static implicit operator TokenRule(Token t)
            => new TokenRule(t, t.Description.ValueOrDefault());

        public static implicit operator Token(TokenRule r)
            => r.Token;

        public TokenRule(Token t, string Description = null)
            : base(t.Name, Description)
        {
            this.Token = t;            
        }

        public TokenRule(string RuleName, Token t, string Description = null)
            : base(RuleName, Description)
        {
            this.Token = t;
        }

        public Token Token { get; }

        protected override TokenRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new TokenRule(RuleName, Token, Description);

        public override string ToString()
            => Token.Value;
    }
}