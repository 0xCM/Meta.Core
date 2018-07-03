//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using static metacore;
using ops = classops;
using Meta.Core;

public static partial class etude
{
    internal static IApplicationMessage NotLeft<L, R>(Either<L, R> e)
        => error($"The either valeu {e} is not a left value");

    internal static IApplicationMessage NotRight<L, R>(Either<L, R> e)
        => error($"The either valeu {e} is not a right value");


}


public static partial class classops
{



}
