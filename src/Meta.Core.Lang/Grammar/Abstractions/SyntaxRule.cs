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
    /// Defines a syntax production rule
    /// </summary>
    public abstract class SyntaxRule : ISyntaxRule
    {
        /// <summary>
        /// Combines two rules r1 and r2 to form a rule r1 | r2
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static OneOf operator |(SyntaxRule r1, SyntaxRule r2)
        {
            var r1Terms = (r1 is OneOf ? (r1 as OneOf).Terms : stream(r1));
            var r2Terms = (r2 is OneOf ? (r2 as OneOf).Terms : stream(r2));
            return new OneOf(r1Terms.Concat(r2Terms));
        }

        /// <summary>
        /// Promotes a rule to a <see cref="OneOrMore"/> value
        /// </summary>
        /// <param name="r">The rule to be promoted</param>
        /// <returns></returns>
        public static OneOrMore operator +(SyntaxRule r)
            => new OneOrMore(r);

        /// <summary>
        /// Combines two rules r1 and r2 to form a rule r1 r2
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static RuleSequence operator +(SyntaxRule r1, SyntaxRule r2)
            => Append(r1, r2);

        /// <summary>
        /// Concatenates the rules defined by the supplied arguments
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static RuleSequence operator +(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2) r2)
            => Append(r1, r2);

        /// <summary>
        /// Concatenates the rules defined by the supplied arguments
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static RuleSequence operator +(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2, SyntaxRule x3) r2)
            => Append(r1, r2);

        /// <summary>
        /// Concatenates the rules defined by the supplied arguments
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static RuleSequence operator +(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2, SyntaxRule x3, SyntaxRule x4) r2)
            => Append(r1, r2);

        /// <summary>
        /// Concatenates two rules to form a <see cref="RuleSequence"/>
        /// </summary>
        /// <param name="r1">The first rule</param>
        /// <param name="r2">The second rule</param>
        /// <returns></returns>
        public static RuleSequence Append(SyntaxRule r1, SyntaxRule r2)
            => new RuleSequence(stream(r1, r2));

        /// <summary>
        /// Concatentates the supplied rules to form a <see cref="RuleSequence"/>
        /// </summary>
        /// <param name="r1">The first rule</param>
        /// <param name="r2">The second (composite) rule</param>
        /// <returns></returns>
        public static RuleSequence Append(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2) r2)
            => new RuleSequence(stream(r1, Parenthetical.Define(DelimitedList.Define(r2.x1, r2.x2))));

        /// <summary>
        /// Concatenates the supplied rules to form a <see cref="RuleSequence"/>
        /// </summary>
        /// <param name="r1">The first rule</param>
        /// <param name="r2">The second (composite) rule</param>
        /// <returns></returns>
        public static RuleSequence Append(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2, SyntaxRule x3) r2)
            => new RuleSequence(stream(r1, Parenthetical.Define(DelimitedList.Define(r2.x1, r2.x2, r2.x3))));

        /// <summary>
        /// Concatenates the supplied rules to form a <see cref="RuleSequence"/>
        /// </summary>
        /// <param name="r1">The first rule</param>
        /// <param name="r2">The second (composite) rule</param>
        /// <returns></returns>
        public static RuleSequence Append(SyntaxRule r1, (SyntaxRule x1, SyntaxRule x2, SyntaxRule x3, SyntaxRule x4) r2)
            => new RuleSequence(stream(r1, Parenthetical.Define(DelimitedList.Define(r2.x1, r2.x2, r2.x3, r2.x4))));
        
        /// <summary>
        /// Defines an anonymous rule that encapsulates no terms
        /// </summary>
        public SyntaxRule()
        {
            this.RuleName = String.Empty;
            this.Terms = new List<SyntaxRule>();
        }

        /// <summary>
        /// Defines an rule that encapsulates no terms
        /// </summary>
        /// <param name="RuleName"></param>
        public SyntaxRule(string RuleName, string Description = null)
        {
            this.RuleName = RuleName;
            this.Terms = new List<SyntaxRule>();
            this.Description = Description;
        }

        /// <summary>
        /// Defines a rule that encapsulates 0 or more terms
        /// </summary>
        /// <param name="Terms">The terms encapsulated by the rule</param>
        /// <param name="RuleName">The name of the rule</param>
        protected SyntaxRule(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
        {
            this.RuleName = RuleName  ?? string.Empty;
            this.Terms = metacore.rolist(Terms);
            this.Description = Description;
        }

        /// <summary>
        /// The name of the rule that appears on the LHS of a production
        /// </summary>
        public string RuleName { get; }

        /// <summary>
        /// The list of terms, if any, encapsulated by the rule
        /// </summary>
        public IReadOnlyList<SyntaxRule> Terms { get; }

        /// <summary>
        /// Describes the purpose/intent of the rule
        /// </summary>
        public Option<string> Description { get; }

        /// <summary>
        /// Specifies whether the rule has been given a name
        /// </summary>
        public bool IsAnonymous
           => isBlank(RuleName);

        /// <summary>
        /// Specifies the delitmer to use when rendering concatenanted terms
        /// </summary>
        protected virtual string TermDelimiter
            => space();

        /// <summary>
        /// Specifies the rule body as text
        /// </summary>
        protected virtual string Body
            => concat(LeftBodyDelimiter, 
                join(TermDelimiter, Terms), 
                RightBodyDelimiter
                );

        /// <summary>
        /// Adjacent text that immediately precedes the body
        /// </summary>
        protected virtual string LeftBodyDelimiter 
            => space();

        /// <summary>
        /// Adjacent text that immediately folows the body
        /// </summary>
        protected virtual string RightBodyDelimiter
            => space();

        /// <summary>
        /// Adjacent text that immediately precedes the name
        /// </summary>
        protected virtual string LeftNameDelimiter
            => "<";

        /// <summary>
        /// Adjacent text that immediately folows the name
        /// </summary>
        protected virtual string RightNameDelimiter
            => ">";

        /// <summary>
        /// Text that separates the name and body
        /// </summary>
        protected virtual string NameBodySeparator
            => " ::= ";

        /// <summary>
        /// Specifies whether the <see cref="RuleName"/> should fenced when rendered 
        /// </summary>
        protected virtual bool FenceName
            => true;
       
        /// <summary>
        /// The rendered rule name
        /// </summary>
        protected virtual string NameFormat
            => IsAnonymous 
            ? string.Empty 
            : (FenceName ?  $"{LeftNameDelimiter}{RuleName}{RightNameDelimiter}" : RuleName);
            
        public override string ToString()
        {
            var body = Body;
            if (isNotBlank(body))
            {
                if (not(IsAnonymous))
                    return concat(NameFormat, NameBodySeparator,  body);
                else
                    return body;
            }
            else
                return RuleName;
        }

        public virtual SyntaxRule FillTypedSlot(SlotValue Value)
            => this;
    }

    public abstract class SyntaxRule<R> : SyntaxRule
        where R : SyntaxRule<R>
    {

        /// <summary>
        /// Defines an anonymous rule that encapsulates no terms
        /// </summary>
        protected SyntaxRule()
        {
        }

        /// <summary>
        /// Defines an rule that encapsulates no terms
        /// </summary>
        /// <param name="RuleName"></param>
        public SyntaxRule(string RuleName, string Description = null)
            : base(RuleName,Description)
        { }

        /// <summary>
        /// Defines a rule that encapsulates 0 or more terms
        /// </summary>
        /// <param name="Terms">The terms encapsulated by the rule</param>
        /// <param name="RuleName">The name of the rule</param>
        public SyntaxRule(string RuleName, IEnumerable<SyntaxRule> Terms, string Description = null)
            : base(RuleName, Terms, Description)
        {

        }

        /// <summary>
        /// Clones the existing rule while redefining its name
        /// </summary>
        /// <param name="NewName">The new name</param>
        /// <returns></returns>
        public R Rename(string NewName)
            => Define(NewName, Terms, Description.ValueOrDefault());

        /// <summary>
        /// Clones the existing rule while redefining its description
        /// </summary>
        /// <param name="NewDescription">The new description</param>
        /// <returns></returns>
        public R Describe(string NewDescription)
            => Define(RuleName, Terms, NewDescription);

        /// <summary>
        /// Defines a rule of type <typeparamref name="R"/>
        /// </summary>
        /// <param name="Terms"></param>
        /// <param name="RuleName"></param>
        /// <returns></returns>
        protected abstract R Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description);


        public override SyntaxRule FillTypedSlot(SlotValue Value)
            => FillSlot(Value);

        public R FillSlot(SlotValue value)
        {
            if (this is Slot)
                return cast<R>((this as Slot).FillIfSelected(value));

            var rewritten = new List<SyntaxRule>();
            foreach(var term in Terms)
            {
               switch(term)
                {
                    case Slot s:
                        rewritten.Add(s.FillIfSelected(value));
                        break;
                    default:
                        rewritten.Add(term.FillTypedSlot(value));                                                
                        break;
                }
            }

            return Define(RuleName, rewritten, Description.ValueOrDefault());
        }

    }
}