//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Encapsulates the outcome of a validation operation
    /// </summary>
    public class ValidationResult
    {
        public static implicit operator bool(ValidationResult x) 
            => x.IsValid;

        readonly IReadOnlyList<IEvaluatedRule> rules;

        public ValidationResult(IEnumerable<IEvaluatedRule> rules)
        {
            this.rules = rolist(rules);
        }

        public ValidationResult(params IEvaluatedRule[] rules)
        {
            this.rules = rolist(rules);
        }

        public bool IsValid 
            => rules.All(x => x.Succeeded);

        public IEnumerable<IEvaluatedRule> Evaluations 
            => rules;

        public IEnumerable<IEvaluatedRule> Failures 
            => rules.Where(r => not(r.Succeeded));

        public IEnumerable<IEvaluatedRule> Successes 
            => rules.Where(r => r.Succeeded);
    }
}
