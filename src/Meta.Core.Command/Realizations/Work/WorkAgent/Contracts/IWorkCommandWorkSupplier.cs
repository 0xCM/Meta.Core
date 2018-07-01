//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Specializes t <see cref="IWorkSupplier{W}"/>interface for use with <see cref="WorkCommand{TSpec}"/> commands
    /// </summary>
    /// <typeparam name="TSpec">The encapsulated command specificaiton type</typeparam>
    public interface IWorkCommandSupplier<TSpec> : IWorkSupplier<WorkCommand<TSpec>>
        where TSpec : CommandSpec<TSpec>, new()
    {
    }
}