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

    /// <summary>
    /// Defines signature for function that lifts a value into a 1-record
    /// </summary>
    /// <typeparam name="X1">The value type</typeparam>
    /// <param name="x1">The attribute value</param>
    /// <returns></returns>
    public delegate Record<X1> RecordFactory<X1>(X1 x1);


    /// <summary>
    /// Defines signature for function that derives a record attribute value from an input value and
    /// lifts the result into a 1-record
    /// </summary>
    /// <typeparam name="X">The data source type</typeparam>
    /// <typeparam name="X1">The attribute type</typeparam>
    /// <param name="source">The soure value</param>
    /// <returns></returns>
    public delegate Record<X1> RecordDerivation<X, X1>(X source);

    /// <summary>
    /// Defines a 1-attribute record
    /// </summary>
    /// <typeparam name="X1">The value data type</typeparam>
    public readonly struct Record<X1> : IRecordMeta<Record<X1>, RecordFactory<X1>>
    {
        /// <summary>
        /// The canonical empty record
        /// </summary>
        public static readonly Record<X1> Empty = default;

        /// <summary>
        /// Specifies the canonical value constructor
        /// </summary>
        public static readonly RecordFactory<X1> Factory
            = x => new Record<X1>(x);

        /// <summary>
        /// Lifts a tuple into a record
        /// </summary>
        /// <param name="x">The source tuple</param>
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
            => show(x1, "null");

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