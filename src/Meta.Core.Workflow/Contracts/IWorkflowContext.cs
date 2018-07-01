//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    using System;
    using System.Collections.Generic;

    public interface IWorkflowContext : INodeContext
    {

    }

    public interface IWorkflowContext<out R> : IWorkflowContext
    {

    }

    public interface IWorkflowContext<in X, out R> : INodeContext
    {
        
    }
}