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
    /// Specifies a rule that requires the presence of a delimited list
    /// </summary>
    public class DelimitedList : SyntaxRule<DelimitedList>
    {

        public static readonly string DefaultDelimiter = ",";

        public static DelimitedList Define(params SyntaxRule[] Terms)
            => new DelimitedList(Terms);


        public static DelimitedList Define(string RuleName, string Delimiter, params SyntaxRule[] Terms)
            => new DelimitedList(RuleName, Terms, Delimiter);

        public DelimitedList(string RuleName, IEnumerable<SyntaxRule> Terms)
            : base(RuleName, Terms)
        {
            this.Delimiter = DefaultDelimiter;
        }

        public DelimitedList(IEnumerable<SyntaxRule> Terms)
            : base(string.Empty, Terms)
        {
            this.Delimiter = DefaultDelimiter;
        }

        DelimitedList(string RuleName, IEnumerable<SyntaxRule> Terms, string Delimiter, string Description = null)
            : base(RuleName, Terms,Description)
        {
            this.Delimiter = Delimiter;
        }

        public string Delimiter { get; }

        protected override string Body
            => join(Delimiter + space(), Terms);

        protected override DelimitedList Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new DelimitedList(RuleName, Terms, DefaultDelimiter, Description);

        public override string ToString()
            => IsAnonymous 
            ? Body 
            : $"{RuleName} ::= " + Body;
    }

}