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
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;

    using static metacore;

    /// <summary>
    /// Base type for rules that require an aspect of encapsulated content to
    /// match a specified regular expression
    /// </summary>
    /// <typeparam name="S">The item under evaluation</typeparam>
    public class PatternRule<S> : ValidationRule<PatternRule<S>, S>
    {
        /// <summary>
        /// The regular expression to which adherence is required
        /// </summary>
        public string RequiredPattern { get; }

        public PatternRule(string RequiredPattern, [CallerMemberName] string caller = null)
            : base(caller)
        {
            
            this.RequiredPattern = RequiredPattern;
        }

        public override string ToString() 
            => $"The {RuleName} rule requires a {typeof(S).Name} to satisfy {RequiredPattern}";
    }

}
