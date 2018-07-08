//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public static class FlowTypes
    {
        /// <summary>
        /// Contract for function that provides a source of values that will be funneled into a sink
        /// via a transforming adapter
        /// </summary>
        /// <typeparam name="T">The source item type</typeparam>
        /// <returns></returns>
        public delegate Seq<T> Source<T>();

        /// <summary>
        /// Untyped contract for function that provides a source of values that will be funneled into a sink
        /// via a transforming adapter
        /// </summary>
        /// <returns></returns>
        public delegate Seq<object> Source();

        /// <summary>
        /// Contract for function that accepts incoming values and pushes them to the target. 
        /// </summary>
        /// <typeparam name="T">The type of element accepted by the sink</typeparam>
        /// <param name="items">The incoming items</param>
        /// <returns></returns>
        /// <remarks>
        /// The intent here, similar to the related contracts, is to decouple caller and callee
        /// </remarks>
        public delegate Option<int> Target<T>(Seq<T> items);

        /// <summary>
        /// Untyped contract for function that accepts incoming values and pushes them to the target. 
        /// </summary>
        /// <param name="items">The incoming items</param>
        /// <returns></returns>
        /// <remarks>
        /// The intent here, similar to the related contracts, is to decouple caller and callee
        /// </remarks>
        public delegate Option<int> Target(Seq<object> items);

        /// <summary>
        /// Contract for a function that is interposed between the source and the sink to
        /// adapt the representation of the source item to target item
        /// </summary>
        /// <typeparam name="TSrc">The type of the source item</typeparam>
        /// <typeparam name="TDst">The type of the target item</typeparam>
        /// <param name="src">The source elements to which the transformation will applied</param>
        /// <returns></returns>
        public delegate Seq<TDst> Projector<TSrc, TDst>(Seq<TSrc> src);

        /// <summary>
        /// Contract for a function that is interposed between a source and sink of the same type
        /// </summary>
        /// <typeparam name="T">The type of the source and sink items</typeparam>
        /// <param name="src">The source elements to which the transformation will applied</param>
        /// <returns></returns>
        public delegate Seq<T> Projector<T>(Seq<T> src);

        /// <summary>
        /// Contract for a function that is interposed between the source and the sink to
        /// adapt the representation of the source item to target item
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public delegate Seq<object> Projector(Seq<object> src);

    }
}
