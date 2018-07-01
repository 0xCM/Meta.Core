//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System.Collections.Generic;


    public interface IWorkSupplier
    {
        string PartitionName { get; }
        IEnumerable<IPartitionedWork> Next(int MaxCount);
    }

    public interface IWorkSupplier<out W> : IWorkSupplier where W : IPartitionedWork
    {

        new IEnumerable<W> Next(int MaxCount);
    }
}