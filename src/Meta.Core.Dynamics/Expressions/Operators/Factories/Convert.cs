//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Linq.Expressions;

    using static minicore;
    using static express;


    public static class Convert<X,Y>
    {
        static Y Cast(X value)
            => (Y)(object)value;

        static FuncExpression<X, Y> Converter()
            => FuncExpression.make((X x) => (Y)Convert.ChangeType(x,typeof(Y)));

        static readonly Func<X, Y> _OP
            = Converter().Fx.Compile();

        public static Y Apply(X x)
            => _OP(x);

    }


}