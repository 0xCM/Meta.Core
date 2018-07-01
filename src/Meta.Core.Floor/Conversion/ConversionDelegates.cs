//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// A strongly-typed projector that is independnt of ambient state
    /// </summary>
    /// <typeparam name="TSrc">The source type</typeparam>
    /// <typeparam name="TDst">The target type</typeparam>
    /// <param name="src">The source value</param>
    /// <returns></returns>
    public delegate TDst Converter<in TSrc, out TDst>(TSrc src);

    /// <summary>
    /// a strongly-typed projector applied in the context of ambient state
    /// </summary>
    /// <typeparam name="TSrc">The source type</typeparam>
    /// <typeparam name="TDst">The target type</typeparam>
    /// <param name="src">The source value</param>
    /// <returns></returns>
    public delegate TDst ContextualConverter<in TSrc, out TDst>(IApplicationContext context, TSrc src);

    /// <summary>
    /// a covariantly-typed projector that is independent of ambient state
    /// </summary>
    /// <typeparam name="TDst">The target type</typeparam>
    /// <param name="src">The source value</param>
    /// <returns></returns>
    public delegate TDst Converter<out TDst>(object src);

    /// <summary>
    /// a covariantly-typed projector applied in the context of ambient state
    /// </summary>
    /// <typeparam name="TDst">The target type</typeparam>
    /// <param name="src">The source value</param>
    /// <returns></returns>
    public delegate TDst ContextualConverter<out TDst>(IApplicationContext context, object src);

    /// <summary>
    /// A weakly-typed projector that is independent of ambient state
    /// </summary>
    /// <param name="src">The source value</param>
    /// <returns></returns>
    public delegate object Converter(object src);

    /// <summary>
    /// A weakly-typed projector applied in the context of ambient state
    /// </summary>
    /// <param name="context">The ambient state</param>
    /// <param name="src">The source value to be transformed</param>
    /// <returns></returns>
    public delegate object ContextualConverter(IApplicationContext context, object src);
}