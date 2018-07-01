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
    using System.Linq.Expressions;

    using static metacore;

    /// <summary>
    /// Requires the presence of exactly one choice among two or more choices
    /// </summary>
    public class OneOf : SyntaxRule<OneOf>
    {
        public static OneOf operator + (OneOf x, OneOf y)
            => new OneOf(x.Terms.Concat(y.Terms));

        public OneOf(IEnumerable<SyntaxRule> Choices, string Description = null)
            : base(string.Empty, Choices, Description)
        {

        }

        public OneOf(string RuleName, IEnumerable <SyntaxRule> Choices, string Description = null)
            : base(RuleName, Choices, Description)
        {
            
        }

        protected override string TermDelimiter
            => " | ";

        protected override OneOf Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new OneOf(RuleName, Terms,Description);
    }


}