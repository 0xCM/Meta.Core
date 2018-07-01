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
    /// Requires the presence of a specified sequence of characters without adornment, 
    /// quoting, escaping, binding, spindling or other form of mutilation
    /// </summary>
    public class VerbatimRule : SyntaxRule<VerbatimRule>
    {
        /// <summary>
        /// Constructs a verbatim rule with the supplied value
        /// </summary>
        /// <param name="Value"></param>
        public VerbatimRule(string Value, string Description = null)
            : base(Value)
        {

        }

        public override string ToString()
            => RuleName;

        protected override VerbatimRule Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new VerbatimRule(RuleName, Description);
    }
}