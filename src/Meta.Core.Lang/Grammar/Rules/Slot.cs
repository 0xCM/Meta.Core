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
    /// Specifies a named placeholder
    /// </summary>
    public class Slot : SyntaxRule<Slot>
    {
        public Slot(string Name, string Description = null)
            : base(Name, Description)
        { }

        protected override string NameFormat
            => RuleName;

        /// <summary>
        /// If matched, replaces slot with a verbatim as specified by the supplied value; otherwise, returns self
        /// </summary>
        /// <param name="value">The slotted value</param>
        /// <returns></returns>
        public SyntaxRule FillIfSelected(SlotValue value)
        {
            if (RuleName == value.Selection.RuleName)
                return new VerbatimRule(value.Value);
            else
                return this;
        }

        protected override Slot Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new Slot(RuleName, Description);
    }
}