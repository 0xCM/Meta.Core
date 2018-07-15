﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using static minicore;

    public static partial class XUnion
    {

        public abstract class XU<U,X1, X2, X3>
            where U : XU<U, X1, X2, X3>, new()
        {
            public static readonly U Empty = new U();
                        
            protected XU()
            {
                this.IsEmpty = true;
            }
                              
            protected XU(X1 x1)
            {
                this.x1 = x1;
                this.IsEmpty = x1 != null;
            }

            protected XU(X2 x2)
            {
                this.x2 = x2;
                this.IsEmpty = x2 != null;
            }

            protected XU(X3 x3)
            {
                this.x3 = x3;
                this.IsEmpty = x3 != null;
            }


            public bool IsEmpty { get; private set; }

            public Option<X1> x1 { get; private set; }

            public Option<X2> x2 { get; private set; }

            public Option<X3> x3 { get; private set; }

            public static U make(X1 x1)
            {
                if (x1 == null)
                    return Empty;

                return new U
                {
                    IsEmpty = false,
                    x1 = x1
                };
            }

            public static U make(X2 x2)
            {
                if (x2 == null)
                    return Empty;

                return new U
                {
                    IsEmpty = false,
                    x2 = x2
                };

            }

            public U make(X3 x3)
            {
                if (x1 == null)
                    return Empty;

                return new U()
                {
                    IsEmpty = false,
                    x3 = x3
                };
            }

            public Option<Y> match<Y>(Func<X1, Option<Y>> f1)
                => from x in x1
                   from y in f1(x)
                   select y;

            public Option<Y> match<Y>(Func<X2, Option<Y>> f2)
                => from x in x2
                   from y in f2(x)
                   select y;

            public Option<Y> match<Y>(Func<X3, Option<Y>> f3)
                => from x in x3
                   from y in f3(x)
                   select y;

            public Option<Y> match<Y>(Func<X1, Option<Y>> f1, Func<X2, Option<Y>> f2, Func<X3, Option<Y>> f3)
                => x1 ? match(f1)
                 : x2 ? match(f2)
                 : x3 ? match(f3)
                 : none<Y>();                

            public Y match<Y>(Func<X1, Y> f1, Func<X2, Y> f2, Func<X3, Y> f3)
                => (x1 ? x1.Map(f1)
                : x2 ? x2.Map(f2)
                : x3 ? x3.Map(f3)
                : fail<Y>(AppMessage.Error("No match"))).Require();

        }

    }

}