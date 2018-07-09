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


    public readonly struct Parser<A>
    {

        public Parser(Func<TextBlock, ParseResult<A>> p)
            => this.P = p;

        Func<TextBlock, ParseResult<A>> P { get; }

        public ParseResult<A> parse(TextBlock input)
            => P(input);

    }


}