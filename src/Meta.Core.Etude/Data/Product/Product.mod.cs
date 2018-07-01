//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    public class Product : TypeModule<Product>
    {        

        internal static string component<X>(X x)
            => $"{typeof(X).DisplayName()}:{x}";

    }
}