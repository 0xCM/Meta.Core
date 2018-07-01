//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Defines contract for component that leverages an arbitrary number of
    /// conversion functions to effect a transformation from a source value to 
    /// a target value
    /// </summary>
    public interface IConversionSuite
    {
        /// <summary>
        /// Determines whether a conversion from a source type to a target type exists
        /// </summary>
        /// <param name="srcType">The source type</param>
        /// <param name="dstType">The target type</param>
        /// <returns></returns>
        bool CanConvert(Type srcType, Type dstType);

        /// <summary>
        /// Determines whether a conversion a source type to a target type exists
        /// </summary>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <returns></returns>
        bool CanConvert<TSrc, TDst>();

        /// <summary>
        /// Determines whether conversion from a source value to a target type is possible
        /// </summary>
        /// <param name="srcValue">The source value</param>
        /// <param name="dstType">The target type</param>
        /// <returns></returns>
        bool CanConvert(object srcValue, Type dstType);

        /// <summary>
        /// Determines whether conversion from a source value to a target type is possible
        /// </summary>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="srcValue">The input value</param>
        /// <returns></returns>
        bool CanConvert<TDst>(object srcValue);

        /// <summary>
        /// Attemps to convert the source value to the target type. Returns the
        /// converted value if successful, oterwise None
        /// </summary>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="srcValue">The source value</param>
        /// <returns></returns>
        Option<TDst> TryConvert<TDst>(object srcValue);

        /// <summary>
        /// Converts a heterogenous array of item values
        /// </summary>
        /// <param name="dstTypes">The target item types</param>
        /// <param name="srcValues">The source item values</param>
        /// <returns></returns>
        object[] ConvertItems(Type[] dstTypes, object[] srcValues);

        /// <summary>
        /// Converts a heterogenous sequence of item values
        /// </summary>
        /// <param name="items">A sequence of (TargetType,ItemValue) tuples</param>
        /// <returns></returns>
        Seq<object> ConvertItems(Seq<(Type dstType, object srcValue)> items);

        TDst Convert<TDst>(object srcValue, Func<object, TDst> fallback = null);

        object Convert(Type dstType, object srcValue, Func<object, object> fallback = null);

        TDst Convert<TDst>(IApplicationContext context, object srcValue);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDst"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Seq<TDst> ConvertStream<TDst>(IEnumerable items);

        object Convert(IApplicationContext context, Type dstType, object srcValue);

        TDst Convert<TDst>(PropertyBag src)
            where TDst : new();

    }
}