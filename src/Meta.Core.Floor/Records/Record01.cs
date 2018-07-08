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

    public delegate Record<X1> RecordFactory<X1>(X1 x1);
    
    /// <summary>
    /// Defines a 1-attribute record
    /// </summary>
    /// <typeparam name="X1">The column data type</typeparam>
    public readonly struct Record<X1> : IRecordMeta<Record<X1>, RecordFactory<X1>>
    {
        /// <summary>
        /// The canonical empty record
        /// </summary>
        public static readonly Record<X1> Empty = default;

        /// <summary>
        /// Constructs record values when invoked
        /// </summary>
        public static readonly RecordFactory<X1> Factory
            = x => new Record<X1>(x);

        public static implicit operator Record<X1>(X1 x)
            => new Record<X1>(x);

        public Record(X1 x1)
        {
            this.IsNonEmpty = true;
            this.x1 = x1;
        }

        bool IsNonEmpty { get; }

        /// <summary>
        /// Specifies whether the record is the empty record
        /// </summary>
        public bool IsEmpty
            => !IsNonEmpty;

        /// <summary>
        /// The value of the first attribute
        /// </summary>
        public X1 x1 { get; }

        public Index<object> ItemArray
            => index<object>(x1);

        public RecordFactory<X1> GetFactory()
            => Factory;

        /// <summary>
        /// Gets the canonical empty record of like kind
        /// </summary>
        /// <returns></returns>
        public Record<X1> GetEmpty()
            => Empty;

        public override string ToString()
            => toString(x1, "null");

        public Lst<ClrType> AttributeTypes
            => list(type<X1>());

        public bool Equals(Record<X1> other)
             => operators.eq(x1, other.x1);

        public override bool Equals(object obj)
           => this.RecordEquals(obj);

        public override int GetHashCode()
            => x1?.GetHashCode() ?? 0;


    }
}