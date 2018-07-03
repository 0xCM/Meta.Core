//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;
    using static etude;

    public delegate List<(A output, string Remaining)> ParseFunction<A>(string input);

    public readonly struct TextParser<A>
    {
        public TextParser(ParseFunction<A> Parse)
            => this.parse = Parse;

        public ParseFunction<A> parse { get; }

    }

    public static class TextParser
    {
        public static Option<A> run<A>(TextParser<A> tp, string input)
            => from x in tp.parse(input).Last()
               where isBlank(x.Remaining)
               select x.output;


        
        //public static IEnumerable<(char c, string s)> item(TextParser<char> tp, string input)
        //{
        //    foreach(var c in input)
        //}

        //public static List<(char c, string cs)> item(TextParser<char> tp, string input)
        //    => from x in tp.parse(input)
        //       where 
    }

}