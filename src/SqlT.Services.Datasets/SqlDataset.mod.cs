//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using static metacore;

    public  class SqlDataset 
    {
        /// <summary>
        /// Constructs a <see cref="SqlDataset{T}"/> from a sequence
        /// </summary>
        /// <typeparam name="T">The proxy type</typeparam>
        /// <param name="source">The proxy stream to reify</param>
        /// <param name="designator">Datset identifier</param>
        /// <returns></returns>
        public static SqlDataset<T> make<T>(Seq<T> source, SqlDatasetDesignator designator = null)
            where T : class, ISqlTabularProxy, new()
                => new SqlDataset<T>(source,
                    designator ?? new SqlDatasetDesignator(new SqlContentType(typeof(T).Name)));

        /// <summary>
        /// Constructs a <see cref="SqlDataset{T}"/> from a stream
        /// </summary>
        /// <typeparam name="T">The proxy type</typeparam>
        /// <param name="source">The proxy stream to reify</param>
        /// <param name="designator">Datset identifier</param>
        /// <returns></returns>
        public static SqlDataset<T> make<T>(IEnumerable<T> source, SqlDatasetDesignator designator = null)
            where T : class, ISqlTabularProxy, new()
                => make(seq(source), designator);
    }


}