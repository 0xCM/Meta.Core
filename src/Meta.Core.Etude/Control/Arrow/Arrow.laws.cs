//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public interface IArrow : ICategory
    {

    }

    public interface IArrow<A,B> 
    {

        Arrow<(A, C), (B, C)> first<C>(Arrow<A, C> ab);

        Arrow<(C, A), (C, B)> second<C>(Arrow<A, C> ab);
        
    }


    public class Arrow
    {
        public static Arrow<A, B> make<A, B>(Func<A, B> f)
            => new Arrow<A, B>(f);
    }

}
