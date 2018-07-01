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

    public abstract class ClassInstance<B, C, X> : ITypeclass
        where B : ClassInstance<B, C, X>, new()
        where C : ITypeclass
        where X : ITypeclass<C>
    {

        public static readonly B Value
            = new B();

        private protected static ClassInstanceIndex<C> Index { get; }
            = new ClassInstanceIndex<C>();

        public virtual Option<X> Find()
            => Index.Lookup<X>();

    }

    public abstract class ClassInstance<B, C> : ITypeclass
        where B : ClassInstance<B, C>, new()
        where C : ITypeclass        
    {

        public static readonly B Value
            = new B();

        private protected static HashSet<C> Index { get; }
            = new HashSet<C>();


        protected static C Register(C instance)            
        {
            Index.Add(instance);
            return instance;
        }

    }
    

}