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
    /// Ultimate supertype for validation rule types
    /// </summary>
    /// <typeparam name="R">The derived subtype</typeparam>
    /// <typeparam name="S">The subject under evaluation</typeparam>
    public abstract class ValidationRule<R, S> : IValidationRule
        where R : ValidationRule<R, S>
    {

        protected ValidationRule(string RuleName)
        {
            this.RuleName = RuleName;
        }

        public string RuleName { get; }


        

    }
}
