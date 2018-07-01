//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using Meta.Core.Messaging;
    using System.Collections.Generic;

    using Meta.Core.Shell;
  
    public interface IProcessCommand : IMessage<ProcessMessage>
    {
        /// <summary>
        /// The name of the command, unique within whatever interpretive space it is ensconced
        /// </summary>
        string CommandName { get; }

        /// <summary>
        /// The broker that submitted the command
        /// </summary>
        IProcess SubmittingProcess { get; }

        IProcessResponseMessge Ok(Type ResponseType, ProcessMessage Content);


        r Ok<r>(ProcessMessage Content)
            where r : IProcessResponseMessge;

        IProcessResponseMessge Error(Type ResponseType, ProcessMessage Content);


        r Error<r>(ProcessMessage content)
            where r : IProcessResponseMessge;
    }

 
}