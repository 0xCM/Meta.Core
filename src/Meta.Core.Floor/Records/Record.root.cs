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

    static class RecordEq
    {

        public static bool RecordEquals<R>(this R r1, R r2)
            where R : IRecord<R>, new()
            => r1.Equals(r2);

        public static bool RecordEquals<R>(this R r1, object r2)
            where R : IRecord<R>, new()
            => (r2 is R rr2) 
                ? RecordEquals(r1, rr2) : false;
    }

    public abstract class RecordRoot<R,F> : IRecord<R,F>
        where R : RecordRoot<R,F>, new()
        where F : Delegate
    {
        public static readonly R Empty = new R();

        public static bool operator ==(RecordRoot<R,F> x, RecordRoot<R,F> y)
            => x != null ? x.Equals(y) : false;

        public static bool operator !=(RecordRoot<R,F> x, RecordRoot<R,F> y)
            => not(x == y);

        protected RecordRoot(bool empty)
        {
            this.IsEmpty = empty;
        }

        public bool IsEmpty { get; }
            = true;

        public abstract Index<object> ItemArray { get; }

        public abstract Lst<ClrType> AttributeTypes { get; }

        public abstract F GetFactory();

        public virtual bool Equals(R other)
            => other is null ? false
                : ItemArray == other.ItemArray;

        public override bool Equals(object obj)
           => (obj is R row) ? Equals(row) : false;

        public override int GetHashCode()
            => ItemArray.GetHashCode();
    }
}