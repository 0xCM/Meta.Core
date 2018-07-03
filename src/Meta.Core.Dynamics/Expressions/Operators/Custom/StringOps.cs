//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static FuncExpression;

    public static class StringOps
    {
        public static Expression<Func<string, string, bool>> LT
            => make((string x, string y) => x.CompareTo(y) < 0 ? true : false);

        public static Expression<Func<string, string, bool>> LTEQ
            => make((string x, string y) => x.CompareTo(y) <= 0 ? true : false);

        public static Expression<Func<string, string, bool>> GT
            => make((string x, string y) => x.CompareTo(y) > 0 ? true : false);

        public static Expression<Func<string, string, bool>> GTEQ
            => make((string x, string y) => x.CompareTo(y) >= 0 ? true : false);
    }

}