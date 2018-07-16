//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Text
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines a suite of common parser combinators and utility functions
    /// </summary>
    public static class Parsers
    {
        /// <summary>
        /// Constructs a <see cref="ParseError"/> to represent a parser failure
        /// </summary>
        /// <param name="input">The input that could not be parsed</param>
        /// <param name="message">The reason for the failure</param>
        /// <returns></returns>
        static ParseError error(TextBlock input, string message)
            => new ParseError(input, message);

        /// <summary>
        /// Constructs a <see cref="ParseError"/> to represent a parser failure
        /// </summary>
        /// <param name="input">The input that could not be parsed</param>
        /// <param name="message">The reason for the failure</param>
        /// <returns></returns>
        static ParseError error(TextBlock input, IAppMessage message)
            => new ParseError(input, message);

        /// <summary>
        /// Constructs a <see cref="ParseError"/> to represent a parser failure
        /// </summary>
        /// <param name="input">The input that could not be parsed</param>
        /// <param name="message">The reason for the failure</param>
        /// <returns></returns>
        /// <typeparam name="A">The type of value for which a parse attempt was made</typeparam>
        static ParseResult<A> error<A>(TextBlock input, IAppMessage message)
            => new ParseResult<A>(error(input, message));

        /// <summary>
        /// Constructs a parse result that encodes failure
        /// </summary>
        /// <param name="input">The input that could not be parsed</param>
        /// <param name="message">The reason for the failure</param>
        /// <returns></returns>
        /// <typeparam name="A">The type of value for which a parse attempt was made</typeparam>
        static ParseResult<A> error<A>(TextBlock input, string message)
            => new ParseResult<A>(error(input, message));

        /// <summary>
        /// Constructs a parse result that encodes success
        /// </summary>
        /// <param name="parsed">The parsed value</param>
        /// <param name="remainder">The text that remains to be parsed</param>
        static ParseResult<A> success<A>(A parsed, TextBlock remainder)
            => new ParseResult<A>(parsed, remainder);

        /// <summary>
        /// Constructs a parser value from a parsing function
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        static Parser<A> makeParser<A>(Func<TextBlock, ParseResult<A>> f)
            => new Parser<A>(f);

        /// <summary>
        /// Adjudicates success/failure and advances the parser upon success
        /// </summary>
        /// <typeparam name="A">The type of value for which a parse attempt was made</typeparam>
        /// <param name="input"></param>
        /// <param name="attempt"></param>
        /// <returns></returns>
        static ParseResult<A> process<A>(TextBlock input, Option<A> attempt)
            => attempt.Map(parsed => success(parsed, input.Advance()), message => error<A>(input, message));


        static ParseResult<char> _character(TextBlock input)
                => not(input.Finished)
                    ? success(input.Current, input.Advance())
                    : error<char>(input, "There are no input data to parse");

        /// <summary>
        /// Retrieves a <see cref="char"/> parser that succeeds for any character; failure should occur only
        /// when there is nothing to parse
        /// </summary>
        public static Parser<char> character
            => makeParser(_character);

        static ParseResult<Digit> _digit(TextBlock input)
            => from c in _character(input).Value
               let attempt = Digit.Parse(c.Parsed)
               let result = process(input, attempt)
               select result;

        /// <summary>
        /// Retrieves a <see cref="Digit"/> parser that succeeds when the current character is one of 0..9
        /// </summary>
        public static Parser<Digit> digit
            => makeParser(_digit);

        static ParseResult<char> _satisfy(TextBlock input, Func<char, bool> predicate)
            => from c in character.parse(input).Value
               select predicate(c.Parsed)
                   ? success(c.Parsed, c.Remainder)
                   : error<char>(input, AppMessage.Error("Predicate was not satisfied"));

        /// <summary>
        /// Retrieves a <see cref="char"/> parser that succeeds when the current character satisfies a supplied predicate
        /// </summary>
        /// <param name="f">The predicate to evaluate</param>
        /// <returns></returns>
        public static Parser<char> satisfy(Func<char, bool> f)
            => makeParser(input => _satisfy(input, f));

        static ParseResult<char> _match(TextBlock input, char value)
            => from c in character.parse(input).Value
               select c.Parsed == value ? success(c.Parsed, c.Remainder)
                   : error<char>(input, AppMessage.Error($"The character '{value}' was not matched"));

        /// <summary>
        /// Succeeds when the current character matches a supplied value
        /// </summary>
        /// <param name="value">The value to match on</param>
        /// <returns></returns>
        public static Parser<char> match(char value)
            => makeParser(input => _match(input, value));


 
        

    }

}