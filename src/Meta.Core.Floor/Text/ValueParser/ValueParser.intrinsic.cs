//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;
    using static express;


    /// <summary>
    /// Realizes <see cref="IValueParser{X}"/> predicated on conventional intrinsics
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct ValueParserI<X> : IValueParser<X>
    {
        public static readonly Option<IValueParser<X>> Defalt = Intrinsic();

        static Option<IValueParser<X>> Intrinsic()
            => from method in method<X>("Parse", type<string>())
               from f in func<string, X>(method)
               let converter = new TextConverter<X>(s => Try(() => f(s)))
               select new ValueParserI<X>(converter) 
                as IValueParser<X>;
                                                     
        ValueParserI(TextConverter<X> converter)
            => _converter = converter;

        TextConverter<X> _converter { get; }

        public Option<X> Parse(string text)
            => _converter(text);
    }


}