//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using Meta.Core;
using System;
using System.Linq;

partial class etude
{

    public static Index<X> alt<X>(Index<X> s1, Index<X> s2)
        => Seq.Alt<X>().alt(s1, s2);

}


