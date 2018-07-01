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

    /// <summary>
    /// Encapsulates the outcome of rule evaluation
    /// </summary>
    /// <typeparam name="R">The rule that was evaluated</typeparam>
    /// <typeparam name="S">The subject under evaluation</typeparam>
    public class EvaluatedRule<R, S> : IEvaluatedRule 
        where R : IValidationRule  
    {
        /// <summary>
        /// The subject against which the <see cref="Rule"/> was evaluated
        /// </summary>
        public readonly S Subject;

        /// <summary>
        /// The rule that was evaluated
        /// </summary>
        public readonly R Rule;


        /// <summary>
        /// Specified whether the <see cref="Subject"/> adheres to the rule
        /// </summary>
        public readonly bool Succeeded;

        public EvaluatedRule(R Rule, S Subject, bool Succeeded)
        {
            this.Rule = Rule;
            this.Subject = Subject;
            this.Succeeded = Succeeded;
        }

        public string Description =>
            $"{Rule.RuleName} rule evaluation over {Subject} " + (Succeeded ? "succeeded" : "failed");

        IValidationRule IEvaluatedRule.Rule 
            => Rule;

        object IEvaluatedRule.Subject 
            => Subject;

        bool IEvaluatedRule.Succeeded 
            => Succeeded;
    }


}
