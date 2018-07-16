//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace ᐸTargetNamespaceᐳ
{
    using System;
    using System.Linq;

    using Meta.Core;

    public readonly struct ᐸDerivedTypeNameᐳ : INewType<ᐸDerivedTypeNameᐳ>, IEquatable<ᐸDerivedTypeNameᐳ>
    {
        public static implicit operator ᐸWrappedTypeNameᐳ(ᐸDerivedTypeNameᐳ x)
            => x.value;

        public static implicit operator ᐸDerivedTypeNameᐳ(ᐸWrappedTypeNameᐳ value)
            => new NewType<T>(value);

        public static bool operator ==(ᐸDerivedTypeNameᐳ x, ᐸDerivedTypeNameᐳ y)
            => x.Equals(y);

        public static bool operator !=(ᐸDerivedTypeNameᐳ x, ᐸDerivedTypeNameᐳ y)
            => !(x.Equals(y));

        ᐸWrappedTypeNameᐳ value { get; }

        public ᐸDerivedTypeNameᐳ(T value)
            => this.value = value;

        public ᐸWrappedTypeNameᐳ unwrap()
            => value;

        public bool Equals(ᐸDerivedTypeNameᐳ other)
            => object.Equals(this.value, other.value);

        public override bool Equals(object obj)
            => (obj is ᐸDerivedTypeNameᐳ t) ? Equals(t) : false;

        public override int GetHashCode()
            => value.GetHashCode();

        public override string ToString()
            => value.ToString();
    }
}