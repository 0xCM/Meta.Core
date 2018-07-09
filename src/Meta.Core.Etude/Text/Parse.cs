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


    public static class Parse
    {
        public static ParseResult<A> run<A>(Parser<A> p, string s)
            => p.parse(new TextBlock(s, TextPosition.Initial));

    }
}