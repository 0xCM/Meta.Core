﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    public interface IWorkflowExecutor
    {
        string Label { get; }
    }

    public interface IWorkflowExecutor<W> : IWorkflowExecutor
    {


    }


}
