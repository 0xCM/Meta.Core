//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{

    public interface IWorkflowArgument
    {
        string Name { get; }
        object Value { get; }
    }

    public interface IWorkflowArgument<out V> : IWorkflowArgument
    {
        new V Value { get; }
    }


}