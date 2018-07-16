//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    public readonly struct NewType<T> : INewType<T>, IEquatable<NewType<T>>
    {

        public static implicit operator T(NewType<T> x)
            => x.value;

        public static implicit operator NewType<T>(T value)
            => new NewType<T>(value);

        public static bool operator ==(NewType<T> x, NewType<T> y)
            => x.Equals(y);

        public static bool operator !=(NewType<T> x, NewType<T> y)
            => !(x.Equals(y));

        T value { get; }

        public NewType(T value)
            => this.value = value;

        public T unwrap()
            => value;

        public bool Equals(NewType<T> other)
            => object.Equals(this.value, other.value);

        public override bool Equals(object obj)
            => (obj is NewType<T> t) ? Equals(t) : false;

        public override int GetHashCode()
            => value.GetHashCode();

        public override string ToString()
            => value.ToString();
    }
}