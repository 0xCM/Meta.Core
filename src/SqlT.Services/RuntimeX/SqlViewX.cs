//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Data;
    
    using SqlT.Core;

    public static partial class SqlBrokerExtensions
    {
        /// <summary>
        /// Selects a distinct column from a view
        /// </summary>
        /// <typeparam name="V">The view proxy type</typeparam>
        /// <typeparam name="T0">The type of value being selected</typeparam>
        /// <param name="h">The handle being extended</param>
        /// <param name="ex0">The selection expression</param>
        /// <returns></returns>
        public static IEnumerable<T0> Distinct<V, T0>(this SqlViewHandle<V> h,
            Expression<Func<V, T0>> ex0)
            where V : class, ISqlViewProxy, new()
                => h.Broker.SelectColumn<T0>($"select distinct {col(ex0)} from {h}");

        /// <summary>
        /// Selects a distinct column of 2-tuples
        /// </summary>
        /// <typeparam name="C0">The type of the first column</typeparam>
        /// <typeparam name="C1">Tye type of the second column</typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="h"></param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<C0, C1>> Distinct<V, C0, C1>(this SqlViewHandle<V> h,
            Expression<Func<V, C0>> ex0,
            Expression<Func<V, C1>> ex1)
                where V : class, ISqlViewProxy, new()
                =>  h.Broker.SelectColumns<C0, C1>($"select distinct {col(ex0)}, {col(ex1)} from {h}");

        /// <summary>
        /// Selects duplicate records from a view with respect to a specified column
        /// </summary>
        /// <typeparam name="V">The view type</typeparam>
        /// <typeparam name="C">The column type</typeparam>
        /// <param name="h">Identifies the view</param>
        /// <param name="ex0">The column selector</param>
        /// <returns></returns>
        public static IEnumerable<DataFrameRow<C, int>> SelectDuplicates<V, C>(this SqlViewHandle<V> h,
            Expression<Func<V, C>> ex0)
                where V : class, ISqlViewProxy, new()
                    => h.Broker.SelectColumns<C, int>(
                            $"select {col(ex0)}, count(*) as RecordCount from {h} group by {col(ex0)} having count(*) > 1");

        public static IEnumerable<DataFrameRow<C0, C1, int>> SelectDuplicates<V, C0, C1>(this SqlViewHandle<V> h,
            Expression<Func<V, C0>> ex0,
            Expression<Func<V, C1>> ex1)
                where V : class, ISqlViewProxy, new()
                    => h.Broker.SelectColumns<C0, C1, int>(
                        $"select {col(ex0)}, {col(ex1)}, count(*) as RecordCount from {h} group by {col(ex0)}, {col(ex1)} having count(*) > 1");

        public static IEnumerable<DataFrameRow<C0, C1, C2, int>> SelectDuplicates<V, C0, C1, C2>(this SqlViewHandle<V> h,
            Expression<Func<V, C0>> ex0,
            Expression<Func<V, C1>> ex1,
            Expression<Func<V, C2>> ex2)
                where V : class, ISqlViewProxy, new() 
                    => h.Broker.SelectColumns<C0, C1, C2, int>(
                        $"select {col(ex0)}, {col(ex1)}, {col(ex2)} count(*) as RecordCount from {h} group by {col(ex0)}, {col(ex1)}, {col(ex2)} having count(*) > 1");        
    }
}
