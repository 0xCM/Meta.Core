//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Collections.Generic;

    using Meta.Core.Messaging;


    public sealed class ProcessCommandAdapter : ProcessCommand<ProcessCommandAdapter>
    {

        readonly IProcessCommand adapted_command;

        public ProcessCommandAdapter()
        {
            
        }

        public ProcessCommandAdapter(IProcessCommand adapted_command)
            : base(adapted_command)
        {
            this.adapted_command = adapted_command;
        }

        public override IProcessResponseMessge Ok(Type response_type, ProcessMessage content)
            => adapted_command.Ok(response_type, content);

        public override IProcessResponseMessge Error(Type response_type, ProcessMessage content)
            => adapted_command.Error(response_type, content);


    }


}