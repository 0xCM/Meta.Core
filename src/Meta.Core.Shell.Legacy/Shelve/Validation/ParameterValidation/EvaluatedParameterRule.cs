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


    public class EvaluatedParameterRule<R, S> : EvaluatedRule<R, S>, IEvaluatedParameterRule
       where R : IValidationRule
    {
        public readonly string ParameterValue;

        public EvaluatedParameterRule(R Rule, S Subject, bool Succeeded, string ParameterValue)
            : base(Rule, Subject, Succeeded)
        {
            this.ParameterValue = ParameterValue;
        }


        string IEvaluatedParameterRule.ParameterValue
            => ParameterValue;
    }


}