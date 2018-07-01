//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;


partial class metacore
{
    /// <summary>
    /// Attempts to construct a value parser for a specified type based on
    /// intrinsics
    /// </summary>
    /// <typeparam name="X">The type for which a parser is needed</typeparam>
    /// <returns></returns>
    public static Option<IValueParser<X>> parser<X>()
        => ValueParser.make<X>();

}


