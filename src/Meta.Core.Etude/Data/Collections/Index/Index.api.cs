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

    /// <summary>
    /// Implements the <![CDATA[<|>]]> operator for indexes
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="l1">The first index</param>
    /// <param name="l2">The second index</param>
    /// <returns></returns>
    public static Index<X> alt<X>(Index<X> s1, Index<X> s2)
        => Index.concat(s1, s2);

}


