//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using SqlT.Core;
    using SqlT.Models;
    using Meta.Core.Workflow;


    public interface ISqlDataFlowArgs : ISqlArguments
    {
        int? BatchSize { get; }        
    }

    public interface ISqlDataFlowArgs<T> : ISqlDataFlowArgs
        where T: ISqlDataFlowArgs
    {


    }
}