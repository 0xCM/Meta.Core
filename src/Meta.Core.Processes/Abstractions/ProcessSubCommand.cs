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

    public abstract class ProcessSubCommand<s, c> : ProcessCommand<s>, IProcessSubCommand
        where s : ProcessSubCommand<s, c>, new()
        where c : ProcessCommand<s>, new()
    {
        protected ProcessSubCommand()
        {

        }

        protected ProcessSubCommand(c controller, ProcessMessage content)
            : base(content)
        {
            this.controller = controller;
        }

        protected ProcessSubCommand(string name, c controller, ProcessMessage content)
            : base(name, content)
        {

            this.controller = controller;
        }

        protected c controller { get; }

        IProcessCommand IProcessSubCommand.controller
            => controller;
    }



    public abstract class ProcessSubCommand<s, c, r> : ProcessCommand<s, r>, IProcessSubCommand
        where s : ProcessSubCommand<s, c, r>, new()
        where c : IProcessCommand
        where r : IProcessResponseMessge
    {

        public static implicit operator ProcessCommandAdapter(ProcessSubCommand<s, c, r> command)
           => new ProcessCommandAdapter(command);

        public static implicit operator ProcessSubcommand(ProcessSubCommand<s, c, r> command)
           => new ProcessSubcommand(command);

        protected ProcessSubCommand()
        {

        }



        protected ProcessSubCommand(c controller, ProcessMessage content)
            : base(content)
        { }

        protected ProcessSubCommand(string name, c controller, ProcessMessage content)
            : base(name, content)
        { }

        protected c controller { get; }

        IProcessCommand IProcessSubCommand.controller
            => controller;
    }

    public sealed class ProcessSubcommand : ProcessCommand<ProcessSubcommand>
    {

        readonly IProcessCommand adapted_command;

        public ProcessSubcommand()
        {
            adapted_command = new ProcessCommandAdapter(this);
        }

        public ProcessSubcommand(IProcessCommand adapted_command)
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