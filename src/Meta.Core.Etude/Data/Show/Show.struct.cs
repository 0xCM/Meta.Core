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

    public delegate string TextFormatter<X>(X value);

	public readonly struct Show<X> : IShow<X>
    {
        public static readonly Show<X> instance = default;
	
        public Show(TextFormatter<X> reveal)
            => this.reveal = reveal;

        Option<TextFormatter<X>> reveal { get; }

        public string show(X value)
            => reveal.Map(r => r(value), () => metacore.show(value));

    }


}