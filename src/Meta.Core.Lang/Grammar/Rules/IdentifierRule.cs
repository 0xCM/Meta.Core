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
    /// Specifies a rule determined by an identifier
    /// </summary>
    public class IdentifierRule : SyntaxRule<IdentifierRule>
    {
        public IdentifierRule(string Identifier, string Description = null)
            : base(Identifier)
        {
            
        }

        protected override bool FenceName
            => false;

        protected override IdentifierRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new IdentifierRule(RuleName, Description);

    }

}