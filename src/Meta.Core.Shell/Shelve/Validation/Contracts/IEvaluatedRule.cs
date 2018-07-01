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
    /// Defines contract for rule validation results
    /// </summary>
    public interface IEvaluatedRule
    {
        /// <summary>
        /// The evaluated rule
        /// </summary>
        IValidationRule Rule { get; }
        /// <summary>
        /// The subject under evaluation
        /// </summary>
        object Subject { get; }
        /// <summary>
        /// Whether the rule evaluated to true
        /// </summary>
        bool Succeeded { get; }
        /// <summary>
        /// A non-semantic description of the result
        /// </summary>
        string Description { get; }
    }

    public interface IEvaluatedParameterRule : IEvaluatedRule
    {
        string ParameterValue { get; }
    }
}
