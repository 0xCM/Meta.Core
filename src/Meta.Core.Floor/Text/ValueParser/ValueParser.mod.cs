//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    public sealed class ValueParser : ClassModule<ValueParser,IValueParser>, IValueParser
    {
        public ValueParser()
            : base(typeof(ValueParser<>))
        {

        }
        
        /// <summary>
        /// Attemps to construct an intrinsic value parser
        /// </summary>
        /// <typeparam name="X">The type of value for which a parser should be constructed</typeparam>
        /// <returns></returns>
        public static Option<IValueParser<X>> make<X>()
            => ValueParserI<X>.Defalt;
    }
}