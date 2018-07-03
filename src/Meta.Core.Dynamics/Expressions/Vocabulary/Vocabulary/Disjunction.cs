//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// Represents a logical disjunction; i.e., the or conective that evaluates to true if and only if one or more of it's operands are true
    /// </summary>
    public sealed class Disjunction : Junction
    {
        public Disjunction(Junction Parent = null)
            : base(new IPredicateAplication[] { }, Parent)
        { }

        public Disjunction(IEnumerable<IPredicateAplication> Predicates, Junction Parent = null)
            : base(Predicates, Parent)
        { }

        protected override ILogicalOperator Connective
            => StandardOperators.Or;

    }
}
