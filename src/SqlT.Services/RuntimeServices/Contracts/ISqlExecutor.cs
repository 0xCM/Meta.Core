//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;

    /// <summary>
    /// Defines contract for component that produces and subsequently executes SQL statements
    /// determined by SQL specifications
    /// </summary>
    public interface ISqlExecutor
    {
        /// <summary>
        /// Executes the provided action over the target
        /// </summary>
        /// <param name="cs">The connection string that identifies the target of the action</param>
        /// <param name="action">The action to execute</param>
        /// <param name="converter">The item array transformer to apply to the intermediate result to produce the output</param>
        /// <returns></returns>
        IEnumerable<TResult> Execute<TResult>(SqlConnectionString cs, ISqlAction action, Func<object[], TResult> converter);
        
        /// <summary>
        /// Executes the provided action over the target
        /// </summary>
        /// <param name="cs">The connection string that identifies the target of the action</param>
        /// <param name="action">The action to execute</param>
        /// <returns></returns>
        IEnumerable<C0> Execute<C0>(SqlConnectionString cs, ISqlAction action);

        /// <summary>
        /// Executes the provided action
        /// </summary>
        /// <param name="cs">The connection string that identifies the action target</param>
        /// <param name="action">The action to execute</param>
        /// <returns></returns>
        IEnumerable<Record<C0,C1>> Execute<C0,C1>(SqlConnectionString cs, ISqlAction action);

        /// <summary>
        /// Executes the provided action
        /// </summary>
        /// <param name="cs">The connection string that identifies the action target</param>
        /// <param name="action">The action to execute</param>
        /// <returns></returns>
        IEnumerable<Record<C0, C1, C2>> Execute<C0, C1, C2>(SqlConnectionString cs, ISqlAction action);

        /// <summary>
        /// Executes the provided action
        /// </summary>
        /// <param name="cs">The connection string that identifies the action target</param>
        /// <param name="action">The action to execute</param>
        /// <returns></returns>
        IEnumerable<Record<C0, C1, C2, C3>> Execute<C0, C1, C2, C3>(SqlConnectionString cs, ISqlAction action);

        /// <summary>
        /// Creates the element per the provided specification
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="spec"></param>
        void CreateElement(SqlConnectionString cs, ISqlElement spec);
    }
}
