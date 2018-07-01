//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    
    using static metacore;

    public interface ICommandShell 
    {
        string Name { get; }

        string InstanceId { get; }

        IProcessResponseMessge Execute(IProcessCommand command);

        R Process<C, R>(C command)
            where C : IProcessCommand
            where R : IProcessResponseMessge;
    }
}