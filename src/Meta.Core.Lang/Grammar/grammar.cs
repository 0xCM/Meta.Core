//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;

using Meta.Core;
using Meta.Syntax;

using static metacore;
using static Meta.Syntax.AsciiSymbol;

/// <summary>
/// Defines syntax API
/// </summary>
public static class grammar
{
    /// <summary>
    /// Caches enum literal names/identifiers
    /// </summary>
    static ConcurrentDictionary<Type, IReadOnlyList<string>> _enumIdentifiers { get; }
        = new ConcurrentDictionary<Type, IReadOnlyList<string>>();

    /// <summary>
    /// Returns the identifiers as determined by defined enum literals and/or attributions
    /// </summary>
    /// <typeparam name="E">The enum type</typeparam>
    /// <returns></returns>
    public static IReadOnlyList<string> identifiers<E>()
        where E : Enum
        => _enumIdentifiers.GetOrAdd(typeof(E), _ => ClrEnum.Get<E>().Identifiers.Stream().ToReadOnlyList());

    /// <summary>
    /// Specifies a named rule with no content
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static RuleSequence rule([CallerMemberName] string name = null)
        => new RuleSequence(name);

    /// <summary>
    /// Defines a <see cref="KeywordReference"/>
    /// </summary>
    /// <param name="keyword">The keyword for which a reference will be created</param>
    /// <returns></returns>
    public static TokenRule token(IKeyword keyword)
            => Token.Define(keyword.KeywordName);

    /// <summary>
    /// Defines a rule of the form "choice1 | ... | choiceN
    /// </summary>
    /// <param name="choices">Mutually exclusive choices</param>
    /// <returns></returns>
    public static OneOf oneOf(IEnumerable<SyntaxRule> choices)
        => new OneOf(choices);

    /// <summary>
    /// Defines a rule of the form "choice1 | ... | choiceN
    /// </summary>
    /// <param name="choices">Mutually exclusive choices</param>
    /// <returns></returns>
    public static OneOf oneOf(params SyntaxRule[] choices)
        => new OneOf(choices);

    /// <summary>
    /// Specifies a nonempty rule collection
    /// </summary>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static OneOrMore oneOrMore(SyntaxRule rule)
        => +rule;

    /// <summary>
    /// Specifies a nonempty rule collection
    /// </summary>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static ZeroOrMore zeroOrMore(SyntaxRule rule)
        => new ZeroOrMore(rule);

    /// <summary>
    /// Specifies an optional rule corresponding the the form [rule]
    /// </summary>
    /// <param name="rule">The rule</param>
    /// <returns></returns>
    public static OptionalRule maybe(ISyntaxRule rule)
        => new OptionalRule((SyntaxRule)rule);

    /// <summary>
    /// Specifies an optional rule corresponding the the form [keyword]
    /// </summary>
    /// <param name="keyword">The keyword to be wrapped</param>
    /// <returns></returns>
    public static OptionalRule maybe(IKeyword keyword)
        => maybe(token(keyword));

    /// <summary>
    /// Specifies a rule that renders an expression of the form [(r1,r2)]
    /// </summary>
    /// <param name="r">The composite rule</param>
    /// <returns></returns>
    public static OptionalRule maybe((SyntaxRule r1, SyntaxRule r2) r)
        => new OptionalRule(paren(delimit(r.r1, r.r2)));

    /// <summary>
    /// Specifies a rule that renders an expression of the form [(r1,r2,r3)]
    /// </summary>
    /// <param name="r">The composite rule</param>
    /// <returns></returns>
    public static OptionalRule maybe((SyntaxRule r1, SyntaxRule r2, SyntaxRule r3) r)
        => new OptionalRule(paren(delimit(r.r1, r.r2, r.r3)));

    /// <summary>
    /// Specifies a rule that renders an expression of the form [(r1,r2,r3,r4)]
    /// </summary>
    /// <param name="r">The composite rule</param>
    /// <returns></returns>
    public static OptionalRule maybe((SyntaxRule r1, SyntaxRule r2, SyntaxRule r3, SyntaxRule r4) r)
        => new OptionalRule(paren(delimit(r.r1, r.r2, r.r3, r.r4)));

    /// <summary>
    /// Specifies a rule that requires one or more adjacent <see cref="AsciiDigit"/> values
    /// </summary>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static SyntaxRule integerU([CallerMemberName] string ruleName = null)
        => define(oneOrMore(AsciiDigit.AnyDigit));

    /// <summary>
    /// Specifies a rule that requires one or more adjacent <see cref="AsciiDigit"/> values
    /// </summary>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static SyntaxRule integer([CallerMemberName] string ruleName = null)
        => define(maybe(Plus | Minus) + oneOrMore(AsciiDigit.AnyDigit));

    /// <summary>
    /// Defines a group that encloses a supplied rule
    /// </summary>
    /// <param name="rule">The rule to be grouped</param>
    /// <param name="ruleName">The name of the rule</param>
    /// <returns></returns>
    public static RuleGroup define(SyntaxRule rule, [CallerMemberName] string ruleName = null)
        => new RuleGroup(ruleName, rule);

    /// <summary>
    /// Defines a choice group 
    /// </summary>
    /// <param name="rule">The rule to be grouped</param>
    /// <param name="ruleName">The name of the rule</param>
    /// <returns></returns>
    public static ChoiceGroup choices(OneOf rule, [CallerMemberName] string ruleName = null)
        => new ChoiceGroup(ruleName, rule);

    /// <summary>
    /// Defines a rule of the form L1 | ... | LN where each Li is a literal defined by
    /// the enumeration <typeparamref name="E"/>
    /// </summary>
    /// <typeparam name="E">The enum type</typeparam>
    /// <param name="ruleName">The name of the resulting rule</param>
    /// <returns></returns>
    public static EnumSyntaxChoice<E> choices<E>([CallerMemberName] string ruleName = null)
        where E : Enum
            => new EnumSyntaxChoice<E>(ruleName);

    /// <summary>
    /// Defines a rule of the form item1 | ... | itemN where each item is a member of a specified <see cref="ITypedItemList{T}"/>
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="list">The item list</param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static ListedChoiceGroup<T> choices<T>(ITypedItemList<T> list, [CallerMemberName] string ruleName = null)
        => new ListedChoiceGroup<T>(ruleName, list);

    /// <summary>
    /// Defines an anonymous rule of the form "choice1 | ... | choiceN
    /// </summary>
    /// <param name="choices">The mutually exclusive choices</param>
    /// <returns></returns>
    public static OneOf oneof(params IKeyword[] choices)
        => new OneOf(choices.Select(token));

    /// <summary>
    /// Defines an anonymous group that encloses a supplied rule
    /// </summary>
    /// <param name="rule">The rule to be grouped</param>
    /// <returns></returns>
    public static RuleGroup group(SyntaxRule rule)
        => new RuleGroup(rule);

    /// <summary>
    /// Defines a syntax place holder
    /// </summary>
    /// <param name="name">The palceholder name</param>
    /// <returns></returns>
    public static Slot slot([CallerMemberName] string name = null)
        => new Slot(name);

    /// <summary>
    /// Specifies an adjacency of the form "<paramref name="first"/> {<paramref name="second"/>}"
    /// </summary>
    /// <param name="first">The first item in the pair</param>
    /// <param name="second">The second item in the pair</param>
    /// <returns></returns>
    public static SyntaxRule pair(IKeyword first, SyntaxRule second, [CallerMemberName] string ruleName = null)
        => new Spaced(ruleName, stream<SyntaxRule>(token(first), new RuleGroup(second)));

    /// <summary>
    /// Specifies a rule of the form r1 r2
    /// </summary>
    /// <param name="r1">The first rule</param>
    /// <param name="r2">The second rule</param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static SyntaxRule spaced(SyntaxRule r1, SyntaxRule r2, [CallerMemberName] string ruleName = null)
        => new Spaced(ruleName, stream(r1, r2));

    /// <summary>
    /// Specifies a rule of the form r1r2
    /// </summary>
    /// <param name="r1">The first rule</param>
    /// <param name="r2">The second rule</param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static SyntaxRule adjacent(SyntaxRule r1, SyntaxRule r2, [CallerMemberName] string ruleName = null)
        => new Adjacent(ruleName, stream(r1, r2));

    /// <summary>
    /// Specifies a rule of the form r1r2r3
    /// </summary>
    /// <param name="r1">The first rule</param>
    /// <param name="r2">The second rule</param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static SyntaxRule adjacent(SyntaxRule r1, SyntaxRule r2, SyntaxRule r3, [CallerMemberName] string ruleName = null)
        => new Adjacent(ruleName, stream(r1, r2, r3));

    /// <summary>
    /// Specifies a <see cref="AssignmentRule"/> that requires the presence of an expression of the form
    /// "<paramref name="lhs"/> = <paramref name="rhs"/>"
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static AssignmentRule assign(IKeyword lhs, SyntaxRule rhs, [CallerMemberName] string ruleName = null)
        => new AssignmentRule(ruleName, token(lhs), rhs);

    /// <summary>
    /// Specifies a <see cref="AssignmentRule"/> that requires the presence of an expression of the form
    /// "<paramref name="lhs"/> = <paramref name="rhs"/>"
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <param name="ruleName"></param>
    /// <returns></returns>
    public static AssignmentRule assign(ISyntaxRule lhs, SyntaxRule rhs, [CallerMemberName] string ruleName = null)
        => new AssignmentRule(ruleName, (SyntaxRule)lhs, rhs);

    /// <summary>
    /// Creates a <see cref="Parenthetical"/> rule of the form "(rule)"
    /// </summary>
    /// <param name="rule">The rule to be parenthesized</param>
    /// <returns></returns>
    public static Parenthetical paren(SyntaxRule rule)
        => new Parenthetical(rule);

    /// <summary>
    /// Creates a parenthical delimited list rule of the form (r1, r2, ..., rN)
    /// </summary>
    /// <param name="r1">The first rule</param>
    /// <param name="r2">The second rule</param>
    /// <param name="more">Additional rules</param>
    /// <returns></returns>
    public static Parenthetical paren(SyntaxRule r1, SyntaxRule r2, params SyntaxRule[] more)
        => new Parenthetical(new DelimitedList(stream(r1, r2).Concat(more)));

    /// <summary>
    /// Creates a <see cref="Parenthetical"/> rule group of the form "({rule})"
    /// </summary>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static Parenthetical parenG(SyntaxRule rule)
        => new Parenthetical(new RuleGroup(rule));

    /// <summary>
    /// Specifies a <see cref="DelimitedList"/> rule of the form "rule1, ..., ruleN"
    /// </summary>
    /// <param name="rules">The rules to be delimited</param>
    /// <returns></returns>
    public static DelimitedList delimit(params SyntaxRule[] rules)
        => new DelimitedList(rules);


    /// <summary>
    /// Specifies a recursion step
    /// </summary>
    /// <param name="rule">The name of the recursive rule</param>
    /// <returns></returns>
    public static SyntaxRule recurse([CallerMemberName] string rule = null)
        => new ReflexiveReference(rule);

    /// <summary>
    /// Produces a rule that requires either a single digit or a sequence of one or more digits
    /// </summary>
    /// <param name="oneOrMore">True if a sequence of digits is desired; false otherwise</param>
    /// <returns></returns>
    public static SyntaxRule digits(bool oneOrMore = true)
        => oneOrMore  ? +(AsciiDigit.AnyDigit)  : AsciiDigit.AnyDigit as SyntaxRule;

    /// <summary>
    /// Creates a <typeparamref name="V"/>-valued token
    /// </summary>
    /// <typeparam name="V">The underlying token type</typeparam>
    /// <param name="value">The token value</param>
    /// <returns></returns>
    static Token<V> token<V>(string name, V value)
        => Token.Define(name, value);

    /// <summary>
    /// Defines a <see cref="TokenRule"/> based on a string-valued token
    /// </summary>
    /// <param name="name">The token name</param>
    /// <returns></returns>
    public static TokenRule token([CallerMemberName] string name = null)
        => new TokenRule(Token.Define(name, name));


    /// <summary>
    /// Applies a description to an existing rule
    /// </summary>
    /// <typeparam name="R">The target rule type</typeparam>
    /// <param name="rule">The target rule</param>
    /// <param name="description">The description to apply</param>
    /// <returns></returns>
    public static R describe<R>(R rule, string description)
        where R : SyntaxRule<R>
            => rule.Describe(description);

    /// <summary>
    /// Defines a verbatim rule that requires the existence of a specified sequence of characters
    /// exactly as specified by the verbatim text
    /// </summary>
    /// <param name="text">The text that must appear verbatim</param>
    /// <returns></returns>
    public static VerbatimRule verbatim([CallerMemberName] string text = null)
        => new VerbatimRule(text);    
}
