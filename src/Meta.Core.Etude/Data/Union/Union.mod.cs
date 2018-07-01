//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static etude;

    public class Union  
    {
        internal static string format<T>(Option<T> option)
            => option.Map(value => $"{typeof(T).DisplayName()}:{value}", () => typeof(T).DisplayName());

    }
}