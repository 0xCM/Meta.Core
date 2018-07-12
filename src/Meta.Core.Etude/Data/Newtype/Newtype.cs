//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public class Newtype : ClassModule<Newtype,INewtype>
    {
        public Newtype()
            : base(typeof(Newtype<,>))
        { }
    }

    public interface INewtype : ITypeClass
    {

    }
       
    public interface INewtype<T,A> : INewtype, ITypeClass<T,A>
    {
        T wrap(A prototype);

        A unwrap(T newtype);
    }


    public readonly struct Newtype<T, A> : INewtype<T, A>
    {
        public Newtype(Func<A,T> wrapper, Func<T,A> unwrapper)
        {
            this.wrapper = wrapper;
            this.unwrapper = unwrapper;
        }

        Func<A,T> wrapper { get; }

        Func<T,A> unwrapper { get; }

        public A unwrap(T newtype)
            => unwrapper(newtype);

        public T wrap(A prototype)
            => wrapper(prototype);
    }

}