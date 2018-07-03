//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;    

    /// <summary>
    /// Represents a logical conjunction; i.e., the and conective that evaluates to true if and only if all of its operands are true
    /// </summary>
    public sealed class Conjunction : Junction
    {
        public Conjunction(Junction Parent = null)
            : base(new IPredicateAplication[] { }, Parent)
        { }

        public Conjunction(IEnumerable<IPredicateAplication> Predicates, Junction Parent = null)
            : base(Predicates, Parent)
        { }

        protected override ILogicalOperator Connective
            => StandardOperators.And;
    }

}
