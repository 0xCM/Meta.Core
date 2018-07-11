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
    /// Defines signature for function that lifts a 3-tuple into a 3-record
    /// </summary>
    /// <typeparam name="X1">The data type of the first attribute</typeparam>
    /// <typeparam name="X2">The data type of the second attribute</typeparam>
    /// <typeparam name="X3">The data type of the third attribute</typeparam>
    /// <param name="x">The source tuple</param>
    public delegate Record<X1, X2, X3> RecordFactory<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x);

    /// <summary>
    /// Defines signature for function that derives a 3-record from an input value
    /// </summary>
    /// <typeparam name="X1">The data type of the first attribute</typeparam>
    /// <typeparam name="X2">The data type of the second attribute</typeparam>
    /// <typeparam name="X3">The data type of the third attribute</typeparam>
    /// <param name="x">The source value</param>
    /// <returns></returns>
    public delegate Record<X1, X2, X3> RecordDerivation<X, X1, X2, X3>(X x);

    /// <summary>
    /// Realizes a 3-column row
    /// </summary>
    /// <typeparam name="X1">The data type of the first column</typeparam>
    /// <typeparam name="X2">The data type of the second column</typeparam>
    /// <typeparam name="X3">The data type of the third column</typeparam>
    public readonly struct Record<X1, X2, X3> : IRecordMeta<Record<X1, X2, X3>, RecordFactory<X1, X2, X3>>
    {
        /// <summary>
        /// The canonical empty record
        /// </summary>
        public static readonly Record<X1, X2, X3> Empty = default;

        /// <summary>
        /// Specifies the canonical value constructor
        /// </summary>
        public static readonly RecordFactory<X1, X2, X3> Factory
            = x => new Record<X1, X2, X3>(x.x1, x.x2, x.x3);

        /// <summary>
        /// Lifts a tuple into a record
        /// </summary>
        /// <param name="x">The source tuple</param>
        public static implicit operator Record<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x)
            => new Record<X1, X2, X3>(x);

        /// <summary>
        /// Drops a record onto a tuple
        /// </summary>
        /// <param name="record">The source record</param>
        public static implicit operator (X1 x1, X2 x2, X3 x3) (Record<X1, X2, X3> record)
            => record.AsTuple();


        public Record((X1 x1, X2 x2, X3 x3) x, DataFrameSchema? Schema = null)
        {
            this.IsNonEmpty = true;
            this.x1 = x.x1;
            this.x2 = x.x2;
            this.x3 = x.x3;
        }

        public Record(X1 x1, X2 x2, X3 x3, DataFrameSchema? Schema = null)
        {
            this.IsNonEmpty = true;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }


        bool IsNonEmpty { get; }

        /// <summary>
        /// Specifies whether the record is the empty record
        /// </summary>
        public bool IsEmpty
            => !IsNonEmpty;

        /// <summary>
        /// The value of the first cell in the row
        /// </summary>
        public X1 x1 { get; }

        /// <summary>
        /// The value of the second cell in the row
        /// </summary>
        public X2 x2 { get; }

        /// <summary>
        /// The value of the third cell in the row
        /// </summary>
        public X3 x3 { get; }

        /// <summary>
        /// Gets the factory instance that can construct other records of like kind
        /// </summary>
        /// <returns></returns>
        public RecordFactory<X1, X2, X3> GetFactory()
            => Factory;

        /// <summary>
        /// Gets the canonical empty record of like kind
        /// </summary>
        /// <returns></returns>
        public Record<X1, X2, X3> GetEmpty()
           => Empty;

        /// <summary>
        /// Presents the encapsulated data as an object index
        /// </summary>
        public Index<object> ItemArray
            => index<object>(x1, x2, x3);

        /// <summary>
        /// Presents the encapsulated data as a tuple
        /// </summary>
        /// <returns></returns>
        public (X1 x1, X2 x2, X3 x3) AsTuple()
            => (x1, x2, x3);

        public bool Equals(Record<X1, X2, X3> other)
          => operators.eq(x1, other.x1)
          && operators.eq(x2, other.x2)
          && operators.eq(x3, other.x3);

        public override int GetHashCode()
            => HashCode.Calc(x1, x2, x3);

        public override string ToString()
            => AsTuple().Format();

        public override bool Equals(object obj)
            => this.RecordEquals(obj);

        public Lst<ClrType> AttributeTypes
            => types<X1, X2, X3>();
    }
}