﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Operators
{
    using System;
    using System.Linq.Expressions;

    using static metacore;

    public static partial class Ops
    {

        public static class Divide<T>
        {
            static readonly Func<T, T, T> _OP
                = lambda<T, T, T>(Expression.Divide).Compile();

            public static T Apply(T x, T y)
                => _OP(x, y);
        }


    }

}