//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public class Category : ClassModule<Category,ICategory>
    {
        
        public static ICategory<X> make<X>()
            => Category<X>.instance;
    }


}