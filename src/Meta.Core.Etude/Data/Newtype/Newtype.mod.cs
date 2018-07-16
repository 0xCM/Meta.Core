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

    public class Newtype : ClassModule<Newtype,INewtype>
    {
        public Newtype()
            : base(typeof(NewType<>))
        { }

        public static INewType<T> wrap<T>(T value)
            => new NewType<T>(value);

    }

    public interface INewtype : ITypeClass
    {

    }
       
    public interface INewType<T> : ITypeClass<T>
    {
        T unwrap();
    }





}