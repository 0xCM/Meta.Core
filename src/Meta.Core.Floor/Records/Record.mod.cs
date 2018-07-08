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
    /// Represents a row of data in a <see cref="IDataFrame"/>
    /// </summary>
    public class Record : TypeModule<Record> 
    {
        static Option<Type> RowTypeDef(int order)
            => order is 0 ? typeof(Record<>)
            : order is 1 ? typeof(Record<,>)
            : order is 2 ? typeof(Record<,,>)
            : order is 3 ? typeof(Record<,,,>)
            : order is 4 ? typeof(Record<,,,,>)
            : order is 5 ? typeof(Record<,,,,,>)
            : none<Type>();

        

        public static Record<X1> make<X1>(X1 x1)
            => new Record<X1>(x1);

        public static Record<X1, X2> make<X1, X2>(X1 x1, X2 x2)
            => new Record<X1, X2>(x1, x2);

        /// <summary>
        /// Constructs a 2-attribute record from a 2-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <param name="x">The source tuple</param>
        /// <param name="schema">The associated schema, if any</param>
        /// <returns></returns>
        public static Record<X1, X2> make<X1, X2>((X1 x1, X2 x2) x)
                => new Record<X1, X2>(x);

        /// <summary>
        /// Constructs a 3-attribute record from an explicit list of values
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <typeparam name="X3">The type of the third attribute</typeparam>
        /// <param name="x1">The value in cell 01</param>
        /// <param name="x2">The value in cell 02</param>
        /// <param name="x3">The value in cell 03</param>
        /// <param name="Schema">The associated schema, if any</param>
        /// <returns></returns>
        public static Record<X1, X2, X3> make<X1, X2, X3>(X1 x1, X2 x2, X3 x3)
                => new Record<X1, X2, X3>(x1, x2, x3);

        /// <summary>
        /// Constructs a 3-attribute row from a 3-tuple
        /// </summary>
        /// <typeparam name="X1">The type of the first attribute</typeparam>
        /// <typeparam name="X2">The type of the second attribute</typeparam>
        /// <typeparam name="X3">The type of the third attribute</typeparam>
        /// <param name="Schema">The associated schema, if any</param>
        /// <param name="x">The source tuple</param>
        /// <returns></returns>
        public static Record<X1, X2, X3> make<X1, X2, X3>((X1 x1, X2 x2, X3 x3) x)
                => new Record<X1, X2, X3>(x);

        /// <summary>
        /// Constructs a 4-attribute record from an explicit list of values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <param name="schema">The associated schema, if any</param>
        /// <param name="x1">The value in cell 01</param>
        /// <param name="x2">The value in cell 02</param>
        /// <param name="x3">The value in cell 03</param>
        /// <param name="x4">The value in cell 04</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> make<X1, X2, X3, X4>(X1 x1, X2 x2, X3 x3, X4 x4)
                => new Record<X1, X2, X3, X4>(x1, x2, x3, x4);

        /// <summary>
        /// Constructs a 4-attribute record from a 4-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <param name="schema">The associated schema, if any</param>
        /// <param name="x">The tuple value</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> make<X1, X2, X3, X4>((X1 x1, X2 x2, X3 x3, X4 x4) x)
                => new Record<X1, X2, X3, X4>(x.x1, x.x2, x.x3, x.x4);

        /// <summary>
        /// Constructs a 5-attribute record
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="x1">The value in cell 01</param>
        /// <param name="x2">The value in cell 02</param>
        /// <param name="x3">The value in cell 03</param>
        /// <param name="x4">The value in cell 04</param>
        /// <param name="x5">The value in cell 05</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>(X1 x1, X2 x2, X3 x3, X4 x4, X5 x5)
                => new Record<X1, X2, X3, X4, X5>(x1, x2, x3, x4, x5);

        /// <summary>
        /// Constructs a 5-attribute row from a 5-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="x">The tuple value</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5) x)
                => new Record<X1, X2, X3, X4, X5>(x.x1, x.x2, x.x3, x.x4, x.x5);

        /// <summary>
        /// Constructs a six-attribute row from a 6-tuple
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <param name="schema">The associated schema</param>
        /// <param name="x1">The value in cell 01</param>
        /// <param name="x2">The value in cell 02</param>
        /// <param name="x3">The value in cell 03</param>
        /// <param name="x4">The value in cell 04</param>
        /// <param name="x5">The value in cell 05</param>
        /// <param name="x6">The value in cell 06</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>
            ((X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6) x)
                    => new Record<X1, X2, X3, X4, X5, X6>(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);

        /// <summary>
        /// Constructs a six-attribute record from list of values
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <param name="schema">The associated schema</param>
        /// <param name="x1">The value in cell 01</param>
        /// <param name="x2">The value in cell 02</param>
        /// <param name="x3">The value in cell 03</param>
        /// <param name="x4">The value in cell 04</param>
        /// <param name="x5">The value in cell 05</param>
        /// <param name="x6">The value in cell 06</param>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>
            (X1 x1, X2 x2, X3 x3, X4 x4, X5 x5, X6 x6)
                    => new Record<X1, X2, X3, X4, X5, X6>(x1, x2, x3, x4, x5, x6);

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <returns></returns>
        public static Record<X1> zero<X1>()
            => Record<X1>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <returns></returns>
        public static Record<X1, X2> zero<X1, X2>()
            => Record<X1, X2>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3> zero<X1, X2, X3>()
             => Record<X1, X2, X3>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> zero<X1, X2, X3, X4>()
             => Record<X1, X2, X3, X4>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> zero<X1, X2, X3, X4, X5>()
            => Record<X1, X2, X3, X4, X5>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identied record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first attribute</typeparam>
        /// <typeparam name="X2">The data type of the second attribute</typeparam>
        /// <typeparam name="X3">The data type of the third attribute</typeparam>
        /// <typeparam name="X4">The data type of the fourth attribute</typeparam>
        /// <typeparam name="X5">The data type of the fifth attribute</typeparam>
        /// <typeparam name="X6">The data type of the sixth attribute</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> zero<X1, X2, X3, X4, X5, X6>()
            => Record<X1, X2, X3, X4, X5, X6>.Empty;
    }
}