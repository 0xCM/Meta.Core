//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public readonly struct ShowTBool : IShow<TBool>
    {
        public static readonly ShowTBool instance = default;

        public string show(TBool value)
            => value.ToString();
    }


    public static class ShowX
    {
        public static string Show(this TBool x)
            => ShowTBool.instance.show(x);

    }
}