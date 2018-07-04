//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SqlT.Core;
    using Meta.Core;

    /// <summary>
    /// Contract for function that provides a source of values that will be funneled into a sink
    /// via a transforming adapter
    /// </summary>
    /// <typeparam name="T">The source item type</typeparam>
    /// <returns></returns>
    public delegate IEnumerable<T> SqlDataSource<out T>()
        where T : ISqlTabularProxy, new();

    /// <summary>
    /// Untyped contract for function that provides a source of values that will be funneled into a sink
    /// via a transforming adapter
    /// </summary>
    /// <returns></returns>
    public delegate IEnumerable<ISqlTabularProxy> SqlDataSource();


    /// <summary>
    /// Contract for function that accepts incoming values and pushes them to the target. 
    /// </summary>
    /// <typeparam name="T">The type of element accepted by the sink</typeparam>
    /// <param name="items">The incoming items</param>
    /// <returns></returns>
    /// <remarks>
    /// The intent here, similar to the related contracts, is to decouple caller and callee
    /// </remarks>
    public delegate Option<int> SqlDataSink<in T>(IEnumerable<T> items)
        where T : ISqlTabularProxy, new();

    /// <summary>
    /// Untyped contract for function that accepts incoming values and pushes them to the target. 
    /// </summary>
    /// <param name="items">The incoming items</param>
    /// <returns></returns>
    /// <remarks>
    /// The intent here, similar to the related contracts, is to decouple caller and callee
    /// </remarks>
    public delegate Option<int> SqlDataSink(IEnumerable<ISqlTabularProxy> items);

    /// <summary>
    /// Maps every element in domain to exactly one element in the codomain
    /// </summary>
    /// <typeparam name="TSrc">The source element type</typeparam>
    /// <typeparam name="TDst">The target element type</typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public delegate TDst SqlInjector<in TSrc, out TDst>(TSrc src)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new();

    /// <summary>
    /// An injection that operates on and yields sequences instead of single elements
    /// </summary>
    /// <typeparam name="TSrc">The source element type</typeparam>
    /// <typeparam name="TDst">The target element type</typeparam>
    /// <param name="src"></param>
    /// <returns></returns>
    public delegate IEnumerable<TDst> SqlSequenceInjector<in TSrc, out TDst>(IEnumerable<TSrc> src)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new();

    /// <summary>
    /// Contract for a function that is interposed between a source and sink of the same type
    /// </summary>
    /// <typeparam name="T">The type of the source and sink items</typeparam>
    /// <param name="src">The source elements to which the transformation will applied</param>
    /// <returns></returns>
    public delegate IEnumerable<T> SqlSequenceTransformer<T>(IEnumerable<T> src)
        where T : ISqlTabularProxy, new();

    /// <summary>
    /// Contract for a function that is interposed between the source and the sink to
    /// adapt the representation of the source item to target item
    /// </summary>
    /// <typeparam name="TSrc">The type of the source item</typeparam>
    /// <typeparam name="TDst">The type of the target item</typeparam>
    /// <param name="src">The source elements to which the transformation will applied</param>
    /// <returns></returns>
    public delegate IEnumerable<TDst> SqlSequenceTransformer<in TSrc, out TDst>(IEnumerable<TSrc> src)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new();

    /// <summary>
    /// Contract for a function that is interposed between the source and the sink to
    /// adapt the representation of the source item to target item
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public delegate IEnumerable<ISqlTabularProxy> SqlSequenceTransformer(IEnumerable<ISqlTabularProxy> src);

    /// <summary>
    /// Contract for operational workflow
    /// </summary>
    /// <typeparam name="TSrc">The type of the source item</typeparam>
    /// <typeparam name="TDst">The type of the target item</typeparam>
    /// <returns></returns>
    public delegate Task<Option<FlowSummary>> SqlWorkflowTask<TSrc, TDst>(ISqlWorkflowTransformation<TSrc, TDst> wf)
        where TSrc : ISqlTabularProxy, new()
        where TDst : ISqlTabularProxy, new();

    /// <summary>
    /// Contract for function that is called prior to workflow commencement to execute any prerequisite steps
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    public delegate Option<int> SqlWorkflowInitializer(FlowSettings settings);

    /// <summary>
    /// Contract for function that finds a key-identified value in some source
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    /// <param name="key">The key value</param>
    /// <returns></returns>
    public delegate Option<TValue> SqlLookup<in TKey, TValue>(TKey key);
    
}
