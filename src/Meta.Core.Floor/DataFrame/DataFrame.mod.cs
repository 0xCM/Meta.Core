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
    public class DataFrame : TypeModule<DataFrame>
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
                   let schema = DataFrameSchema.FromColumnTypes(coltypes)
                   let frameType = frameTypeDef.MakeGenericType(coltypes.AsArray())
                   let frame = Activator.CreateInstance(frameType) as IDataFrameRoot
                   select frame.Construct(data, schema);

        /// <summary>
        /// Constructs a 1-column data frame from a sequence of rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="DataRows">The source rows</param>
        /// <returns></returns>
        public static DataFrame<X1> make<X1>(Seq<Record<X1>> rows, DataFrameSchema? schema = null)
            => new DataFrame<X1>(rows, schema);

        /// <summary>
        /// Constructs a 2-column data frame from a sequence of rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="DataRows">The source rows</param>
        /// <returns></returns>
        public static DataFrame<X1, X2> make<X1, X2>(Seq<Record<X1, X2>> rows,
            DataFrameSchema? schema = null)
                => new DataFrame<X1, X2>(rows, schema);

        /// <summary>
        /// Constructs a 3-column data frame from a sequence of rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="DataRows">The source rows</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3> make<X1, X2, X3>(Seq<Record<X1, X2, X3>> rows,
            DataFrameSchema? schema = null)
                => new DataFrame<X1, X2, X3>(rows, schema);

        /// <summary>
        /// Constructs a 4-column data frame from a stream of 4-attribute records
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="DataRows">The source rows</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4> make<X1, X2, X3, X4>(Seq<Record<X1, X2, X3, X4>> DataRows,
            DataFrameSchema? Schema = null)
                => new DataFrame<X1, X2, X3, X4>(DataRows, Schema);

        /// <summary>
        /// Constructs a 5-column data frame from a sequence of rows
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <param name="Schema">The associated schema</param>
        /// <param name="DataRows">The source rows</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5> make<X1, X2, X3, X4, X5>(
            Seq<Record<X1, X2, X3, X4, X5>> DataRows, DataFrameSchema? Schema = null)
                    => new DataFrame<X1, X2, X3, X4, X5>(DataRows, Schema);

        /// <summary>
        /// Constructs a data frame from a stream of six-attribute records
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <param name="schema">The associated schema</param>
        /// <param name="rows">The data stream</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6> make<X1, X2, X3, X4, X5, X6>(Seq<Record<X1, X2, X3, X4, X5, X6>> rows,
                DataFrameSchema? schema = null)
                    => new DataFrame<X1, X2, X3, X4, X5, X6>(rows, schema);
        /// <summary>
        /// Constructs a data frame from a stream of 7-attribute records
        /// </summary>
        /// <typeparam name="X1">The data type of the first column</typeparam>
        /// <typeparam name="X2">The data type of the second column</typeparam>
        /// <typeparam name="X3">The data type of the third column</typeparam>
        /// <typeparam name="X4">The data type of the fourth column</typeparam>
        /// <typeparam name="X5">The data type of the fifth column</typeparam>
        /// <typeparam name="X6">The data type of the sixth column</typeparam>
        /// <typeparam name="X7">The data type of the sixth column</typeparam>
        /// <param name="schema">The associated schema</param>
        /// <param name="rows">The data stream</param>
        /// <returns></returns>
        public static DataFrame<X1, X2, X3, X4, X5, X6, X7> make<X1, X2, X3, X4, X5, X6, X7>(Seq<Record<X1, X2, X3, X4, X5, X6,X7>> rows,
                DataFrameSchema? schema = null)
                    => new DataFrame<X1, X2, X3, X4, X5, X6, X7>(rows, schema);

    }
}