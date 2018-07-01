//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Defines a directed dependency relationship
    /// </summary>
    public interface IDependency
    {
        /// <summary>
        /// The dependent
        /// </summary>
        object Client { get; }

        /// <summary>
        /// The dependency provider
        /// </summary>
        object Supplier { get; }

    }

    /// <summary>
    /// Defines a directed dependency relationship
    /// </summary>
    /// <typeparam name="C">The client type</typeparam>
    /// <typeparam name="S">The supplier type</typeparam>
    public interface IDependency<out C, out S> : IDependency
    {
        /// <summary>
        /// The dependent
        /// </summary>
        new C Client { get; }

        /// <summary>
        /// The dependency provider
        /// </summary>
        new S Supplier { get; }
    }

}