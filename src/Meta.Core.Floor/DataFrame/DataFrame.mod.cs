//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static metacore;

    /// <summary>
    /// Base type for specialized generic <see cref="IDataFrame"/> realizations
    /// </summary>
    public class DataFrame 
    {

        static Option<Type> FrameTypeDef(int order)
            => order is 0 ? typeof(DataFrame<>)
            : order is 1 ? typeof(DataFrame<,>)
            : order is 2 ? typeof(DataFrame<,,>)
            : order is 3 ? typeof(DataFrame<,,,>)
            : order is 4 ? typeof(DataFrame<,,,,>)
            : order is 5 ? typeof(DataFrame<,,,,,>)
            : none<Type>();

        /// <summary>
        /// Constructs a weakly-typed frame, if possible
        /// </summary>
        /// <param name="coltypes">The frame column types</param>
        /// <param name="data">Conforming item arrays</param>
        /// <returns></returns>
        public static Option<IDataFrame> make(Lst<Type> coltypes, Lst<object[]> data)
                => from order in some(coltypes.Count - 1)
                   from frameTypeDef in FrameTypeDef(order)
                   let frameType = frameTypeDef.MakeGenericType(coltypes.AsArray())
                   let frame = Activator.CreateInstance(frameType) as IDataFrameRoot
                   select frame.Construct(data);

        /// <summary>
        /// Constructs a 1-column data frame from a container of 1-rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1> make<X1>(IContainer<Record<X1>> records)
            => new DataFrame<X1>(records);

        /// <summary>
        /// Constructs a 2-column data frame from a 2-record container
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2> make<X1, X2>(IContainer<Record<X1, X2>> records)
                => new DataFrame<X1, X2>(records);

        /// <summary>
        /// Constructs a 3-column data frame from a 3-record container
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3> make<X1, X2, X3>(IContainer<Record<X1, X2, X3>> records)
                => new DataFrame<X1, X2, X3>(records);

        /// <summary>
        /// Constructs a 4-column data frame from a 4-record container
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4> make<X1, X2, X3, X4>(IContainer<Record<X1, X2, X3, X4>> records)        
                => new DataFrame<X1, X2, X3, X4>(records);

        /// <summary>
        /// Constructs a 5-column data frame from a sequence of rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>(IContainer<Record<X1, X2, X3, X4, X5>> records)
                => new DataFrame<X1, X2, X3, X4, X5>(records);

        /// <summary>
        /// Constructs a 6-column data frame from a six-record container
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>(IContainer<Record<X1, X2, X3, X4, X5, X6>> records)
                    => new DataFrame<X1, X2, X3, X4, X5, X6>(records);
        /// <summary>
        /// Constructs a 7-column data frame from a 7-record container
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <typeparam name="X7">The data type of the sixth column</typeparam>
        /// <param name="records">The source source data</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6, X7> make<X1, X2, X3, X4, X5, X6, X7>(IContainer<Record<X1, X2, X3, X4, X5, X6,X7>> records)
                    => new DataFrame<X1, X2, X3, X4, X5, X6, X7>(records);

    }
}