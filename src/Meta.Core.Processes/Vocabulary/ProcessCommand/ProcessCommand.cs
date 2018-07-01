//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Linq;

    using Meta.Core.Messaging;
    using static metacore;
    
    using M = ProcessMessage;

    public abstract class ProcessCommand 
    {
        
        protected ProcessCommand(M content)
        {
            this.content = content;
        }
        /// <summary>
        /// The broker that submitted the command
        /// </summary>
        public IProcess SubmittingProcess { get; internal set; }


        public M content { get; protected set; }

        public CommandArguments args
            => array(
                    from attribution in GetType().GetPropertyAttributions<InputArgAttribute>()
                    let prop = attribution.Key
                    let attrib = attribution.Value
                    let identifier = attrib.identifier ?? prop.Name
                    let propVal = prop.GetValue(this)
                    orderby attrib.position
                    select new CommandArgument(identifier, propVal)
                      );


        public virtual string Format()
            => ToString();
    }

    public abstract class ProcessCommand<C> : ProcessCommand , IProcessCommand
        where C : ProcessCommand<C>, new()
    {
        public static implicit operator ProcessCommandAdapter(ProcessCommand<C> command)
           => new ProcessCommandAdapter(command);

        public static C Init(IProcess submitter, params string[] args)
        {
            var command = new C();
            command.content = new M(command.CommandName, string.Join(" ", args), ProcessMessageType.Command);
            command.SubmittingProcess = submitter;
            return command;
        }

        public string CommandName { get; }


        object IMessage.Body
            => content;

        Guid IMessage.MessageId
            => content.MessageId;

        public M Body
            => content;


        static M empty_command_content { get; } 
            = new M(typeof(C).Name, string.Empty, ProcessMessageType.Command);

        public string Type
            => Body.Type;

        string IMessagePacket<string>.Payload
            => content.ToString();

        Guid IMessagePacket.CorrelationToken
            => content.MessageId;

        object IMessagePacket.Payload
            => content.ToString();

        string IMessagePacket.Label
            => content.Type;

        protected ProcessCommand(M content = null)
            : base(content ?? empty_command_content)
        {
            this.CommandName = typeof(C).Name;
            this.SubmittingProcess = VapidProcess.TheOne;

        }

        protected ProcessCommand(string name, M content = null)
            : this(content)
        {
            this.CommandName = name;
            
        }


        protected ProcessCommand(IMessage content)
            : this(content as M)
        {
            
        }


        public override string ToString()
            => content.ToString();


        public abstract IProcessResponseMessge Ok(Type response_type, M content);

        public abstract IProcessResponseMessge Error(Type response_type, M content);       

        r IProcessCommand.Ok<r>(M content)
            => (r)Ok(typeof(r), content);

        r IProcessCommand.Error<r>(M content)
            => (r)Error(typeof(r), content);

        string IMessage.ToCanonicalForm()
            => content.ToCanonicalForm();

        
    }


    public abstract class ProcessCommand<c, r> : ProcessCommand<c>
        where c : ProcessCommand<c, r>, new()
        where r : IProcessResponseMessge

    {

        protected static PromptInputSyntax DefineSyntax()
        {
            var prototype = typeof(c).GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
            var name = typeof(c).Name;
            return PromptInputSyntax.define(prototype, name);
        }

        public static implicit operator ProcessCommandAdapter(ProcessCommand<c, r> command)
           => new ProcessCommandAdapter(command);

        protected ProcessCommand()
        {

        }

        
        protected ProcessCommand(M content)
            : base(content)
        {

        }

        protected ProcessCommand(string name, M content)
            : base(name, content)
        {

        }


        public override IProcessResponseMessge Ok(Type response_type, M content)
            => ok(content);

        public override IProcessResponseMessge Error(Type response_type, M content)
            => error(content);


        public abstract r ok(M content);

        public abstract r error(M content);

        

    }



}