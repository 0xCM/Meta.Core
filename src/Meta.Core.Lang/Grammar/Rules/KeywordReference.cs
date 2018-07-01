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
    /// Lifts a keyword to syntactic space
    /// </summary>
    public class KeywordReference : SyntaxRule<KeywordReference>
    {
        public KeywordReference(string Keyword, string Description = null)
            : base(Keyword, Description)
        {
            
        }

        protected override bool FenceName
            => false;

        protected override KeywordReference Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new KeywordReference(RuleName, Description);
    }
}