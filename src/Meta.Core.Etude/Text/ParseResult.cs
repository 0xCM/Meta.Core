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
    /// Encapsulates the outcome of a parsing operation
    /// </summary>
    /// <typeparam name="A">The type of the value for which parsing was attempted</typeparam>
    public readonly struct ParseResult<A>
    {
        public static implicit operator Option<A>(ParseResult<A> result)
            => result.Succeeded ? some(result.Value.Right.Parsed) : none<A>(result.Value.Left.Message);

        public static implicit operator ParseResult<A>(Either<ParseError, ParseResult<A>> either)
            => either.IsLeft ? new ParseResult<A>(either.Left) : either.Right;
        
        /// <summary>
        /// Initializer invoked upon a successful parse operation
        /// </summary>
        /// <param name="parsed">The successfully parsed value</param>
        /// <param name="Remainder">The remainder block</param>
        public ParseResult(A parsed, TextBlock Remainder)
            => Value = Either.make<ParseError, ParsedValue<A>>(new ParsedValue<A>(parsed, Remainder));

        /// <summary>
        /// Initializer invoked upon a parse operation failure
        /// </summary>
        /// <param name="error">The parse error depicting the error</param>
        public ParseResult(ParseError error)
            => Value = Either.make<ParseError, ParsedValue<A>>(error);

        /// <summary>
        /// The output defining failure | success
        /// </summary>
        public Either<ParseError, ParsedValue<A>> Value { get; }

        public bool Succeeded
            => Value.IsRight;

        public override string ToString()
            => Value.ToString();

       
    }


}