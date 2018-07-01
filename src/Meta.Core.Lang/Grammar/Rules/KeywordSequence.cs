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
    /// Specifies a rule that requires the presence of a sequence of space-delimited keywords
    /// </summary>
    public class KeywordSequence : SyntaxRule<KeywordSequence>
    {

        static IEnumerable<SyntaxRule> CreateRules(IEnumerable<string> keywords)
            => from k in keywords
               select new KeywordReference(k);

        public KeywordSequence(string Name, IEnumerable<string> Keywords, string Description = null)
            : base(Name, CreateRules(Keywords),Description)
        {

        }

        public KeywordSequence(IEnumerable<string> Keywords)
            : base(string.Empty, CreateRules(Keywords))
        {

        }

        protected override KeywordSequence Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new KeywordSequence(RuleName, Terms.Select(x => x.RuleName), Description);
    }

}