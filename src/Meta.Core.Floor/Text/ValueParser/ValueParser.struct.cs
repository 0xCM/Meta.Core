//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    /// <summary>
    /// Realizes <see cref="IValueParser{X}"/> predicated on supplied data
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public readonly struct ValueParser<X> : IValueParser<X>
    {

        internal ValueParser(TextConverter<X> converter)
            => _converter = converter;

        TextConverter<X> _converter { get; }

        public Option<X> Parse(string text)
            => _converter(text);
    }


}