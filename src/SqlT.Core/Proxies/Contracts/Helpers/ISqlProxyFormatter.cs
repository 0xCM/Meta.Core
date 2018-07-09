//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using static metacore;

    public interface ISqlProxyFormatter
    {
        Seq<Link<P,TextLine>> FormatDelimited<P>(Seq<P> proxies, DelimitedTextDescription Config = null)
            where P : class, ISqlTabularProxy, new();
    }


}