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
    using System.Linq.Expressions;


    public interface ISyntaxRule
    {
        /// <summary>
        /// The name of the rule, if specified
        /// </summary>
        string RuleName { get; }

        /// <summary>
        /// The terms that define the rule
        /// </summary>
        IReadOnlyList<SyntaxRule> Terms { get; }
    }

}