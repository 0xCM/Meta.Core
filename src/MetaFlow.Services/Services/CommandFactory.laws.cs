//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using SqlT.Core;
    using MetaFlow.WF;
    
    public interface ICommandFactory 
    {
        IEnumerable<ISystemCommand> DefineCommands(IWorkflowOptions options);
    }

    public interface ICommandFactory<out K> : ICommandFactory
        where K : class, ISystemCommand, new()
    {
        new IEnumerable<K> DefineCommands(IWorkflowOptions options);
    }

    public interface ICommandFactory<in O, out K> : ICommandFactory<K>
        where K : class, ISystemCommand, new()
        where O : IWorkflowOptions
    {
        IEnumerable<K> DefineCommands(O options);
    }

}