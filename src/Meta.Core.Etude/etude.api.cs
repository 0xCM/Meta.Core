//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using static metacore;
    using ops = classops;

    public static partial class etude
    {
        internal static IApplicationMessage NotLeft<L, R>(Either<L, R> e)
           => error($"The either valeu {e} is not a left value");

        internal static IApplicationMessage NotRight<L, R>(Either<L, R> e)
            => error($"The either valeu {e} is not a right value");



    }



    public static class O
    {
        public static readonly ops.fmap fmap = ops.fmap.op;
        public static readonly ops.fcompose fcompose = ops.fcompose.op;
        public static readonly ops.rcompose rcompose = ops.rcompose.op;
        public static readonly ops.plus plus = ops.plus.op;
        public static readonly ops.alt alt = ops.alt.op;
        public static readonly ops.bind bind = ops.bind.op;
        public static readonly ops.apply apply = ops.apply.op;

    }


    public static partial class classops
    {



    }
}