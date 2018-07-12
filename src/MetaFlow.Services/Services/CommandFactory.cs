//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    
    public abstract class CommandFactory<B,O,K> : NodeService<B,ICommandFactory>, ICommandFactory<O,K>
       where K : class, ISystemCommand, ISqlTableTypeProxy, new()
        where O : IWorkflowOptions
        where B : CommandFactory<B,O,K>
    {

       protected CommandFactory(INodeContext C)
            : base (C)
        { }

        public abstract IEnumerable<K> DefineCommands(O options);

        IEnumerable<K> ICommandFactory<K>.DefineCommands(IWorkflowOptions options)
            => DefineCommands((O)options);

        IEnumerable<ISystemCommand> ICommandFactory.DefineCommands(IWorkflowOptions options)
            => DefineCommands((O)options);
    }
}