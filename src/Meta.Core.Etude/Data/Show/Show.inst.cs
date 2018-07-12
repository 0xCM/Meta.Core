//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public readonly struct ShowTBool : IShow<TriBool>
    {
        public static readonly ShowTBool instance = default;

        public string show(TriBool value)
            => value.ToString();
    }


    public static class ShowX
    {
        public static string Show(this TriBool x)
            => ShowTBool.instance.show(x);

    }
}