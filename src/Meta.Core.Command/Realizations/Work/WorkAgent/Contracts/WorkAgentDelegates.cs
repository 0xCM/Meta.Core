//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;



    public delegate void WorkGroupSubmitted(string name);
    public delegate void WorkGroupCompleted(string name);

    public delegate void WorkSubmitted(IPartitionedWork work);
    public delegate void WorkDispatched(IPartitionedWork work);
    public delegate void WorkCompleted(IPartitionedWork work);

    public delegate void WorkSubmitted<in W>(W work);
    public delegate void WorkDispatched<in W>(W work);
    public delegate void WorkCompleted<in W>(W work);
    public delegate void WorkCompleted<in W, in R>(W item, R result);
}