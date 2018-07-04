//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;

    using SqlT.Core;
    using SqlT.Models;

    using sxc = SqlT.Syntax.contracts;

    public interface ISqlWorkflowRoutineStep : ISqlWorkflowStep
    {
        sxc.ISqlObjectName Name { get; }

        Type RoutineProxyType { get; }

        Option<Type> ResultProxyType { get; }


    }


}