//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    /// <summary>
    /// Specializes t <see cref="IWorkAgentObserver{W}"/>interface for use with <see cref="WorkCommand{TSpec}"/> commands
    /// </summary>
    /// <typeparam name="TSpec">The encapsulated command specificaiton type</typeparam>
    public interface IWorkCommandAgentObserver<TSpec> : IWorkAgentObserver<WorkCommand<TSpec>>
            where TSpec : CommandSpec<TSpec>, new()
    {
    }

    /// <summary>
    /// Specializes t <see cref="IWorkAgentObserver{W}"/>interface for use with <see cref="WorkCommand{TSpec,TResult}"/> commands
    /// </summary>
    /// <typeparam name="TSpec">The encapsulated command specificaiton type</typeparam>
    /// <typeparam name="TResult">The comand result type</typeparam>
    public interface IWorkCommandAgentObserver<TSpec, TResult>
        : IWorkCommandAgentObserver<TSpec>, IWorkAgentObserver<WorkCommand<TSpec, TResult>, TResult>
                where TSpec : CommandSpec<TSpec, TResult>, new()
    { }
}