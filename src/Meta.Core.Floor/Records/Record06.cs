// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public delegate Record<X1, X2, X3, X4, X5, X6> RecordFactory<X1, X2, X3, X4, X5, X6>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x);

    /// <summary>
    /// Defines a 6-attribute record
    /// </summary>
    /// <typeparam name="X1">The data type of the first attribute</typeparam>
    /// <typeparam name="X2">The data type of the second attribute</typeparam>
    /// <typeparam name="X3">The data type of the third attribute</typeparam>
    /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
    /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
    /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
    public readonly struct Record<X1, X2, X3, X4, X5, X6> : IRecordMeta<Record<X1, X2, X3, X4, X5, X6>, RecordFactory<X1, X2, X3, X4, X5, X6>>
    {
        /// <summary>
        /// The canonical empty record
        /// </summary>
        public static readonly Record<X1, X2, X3, X4, X5, X6> Empty = default;

        /// <summary>
        /// Constructs record values when invoked
        /// </summary>
        public static readonly RecordFactory<X1, X2, X3, X4, X5, X6> Factory
            = x => new Record<X1, X2, X3, X4, X5, X6>(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);

        /// <summary>
        /// Converts a tuple into a row
        /// </summary>
        /// <param name="x">The source tuple</param>
        public static implicit operator Record<X1, X2, X3, X4, X5, X6>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
            => new Record<X1, X2, X3, X4, X5, X6>(x);

        /// <summary>
        /// Converts the row into a tuple
        /// </summary>
        /// <param name="row">The source row</param>
        public static implicit operator (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) (Record<X1, X2, X3, X4, X5, X6> row)
             => row.AsTuple();


        /// <summary>
        /// Initialies the record with a tuple
        /// </summary>
        /// <param name="x">The tuple value</param>
        public Record((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
        {
            this.IsNonEmpty = true;
            this.x1 = x.x1;
            this.x2 = x.x2;
            this.x3 = x.x3;
            this.x4 = x.x4;
            this.x5 = x.x5;
            this.x6 = x.x6;
        }

        /// <summary>
        /// Initializes the record with an explicit list of values
        /// </summary>
        /// <param name="x1">The first value</param>
        /// <param name="x2">The second value</param>
        /// <param name="x3">The third value</param>
        /// <param name="x4">The fourth value</param>
        /// <param name="x5">The fifth value</param>
        /// <param name="x6">The sixth value</param>
        public Record(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
        {
            this.IsNonEmpty = true;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
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
        /// The value of the fourth cell in the row
        /// </summary>
        public X4 x4 { get; }

        /// <summary>
        /// The value of the fifth cell in the row
        /// </summary>
        public X5 x5 { get; }

        /// <summary>
        /// The value of the sixth cell in the row
        /// </summary>
        public X6 x6 { get; }

        /// <summary>
        /// Presents the encapsulated data as an object index
        /// </summary>
        public Index<object> ItemArray
            => index<object>(x1, x2, x3, x4, x5, x6);

        /// <summary>
        /// Presents the encapsulated data as a tuple
        /// </summary>
        /// <returns></returns>
        public (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) AsTuple()
            => (x1, x2, x3, x4, x5, x6);

        /// <summary>
        /// Gets the factory instance that can construct other records of like kind
        /// </summary>
        /// <returns></returns>
        public RecordFactory<X1, X2, X3, X4, X5, X6> GetFactory()
           => Factory;

        /// <summary>
        /// Gets the canonical empty record of like kind
        /// </summary>
        /// <returns></returns>
        public Record<X1, X2, X3, X4, X5, X6> GetEmpty()
          => Empty;

        public Lst<ClrType> AttributeTypes
            => types<X1, X2, X3, X4, X5, X6>();

        public bool Equals(Record<X1, X2, X3, X4, X5, X6> other)
            => operators.eq(x1, other.x1)
            && operators.eq(x2, other.x2)
            && operators.eq(x3, other.x3)
            && operators.eq(x4, other.x4)
            && operators.eq(x5, other.x5)
            && operators.eq(x6, other.x6);

        public override int GetHashCode()
            => HashCode.Calc(x1, x2, x3, x4, x5, x6);

        public override bool Equals(object obj)
           => this.RecordEquals(obj);

        public override string ToString()
            => AsTuple().Format();
    }
}