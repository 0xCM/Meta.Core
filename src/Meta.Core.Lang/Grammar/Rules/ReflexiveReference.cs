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
    /// Annotats a refernece to self, i.e. a recursive reference
    /// </summary>
    public class ReflexiveReference : SyntaxRule<ReflexiveReference>
    {
        public ReflexiveReference(string Name, string Description = null)
            : base(Name, Description)
        {

        }

        public override string ToString()
            => angled(RuleName);

        protected override ReflexiveReference Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new ReflexiveReference(RuleName, Description);
    }



}