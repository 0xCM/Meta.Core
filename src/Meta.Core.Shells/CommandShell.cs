//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CommandShell : ICommandShell
    {
        static int count = 0;
        static readonly IDictionary<string, CommandShell> Shells
            = new Dictionary<string, CommandShell>();

        static string identifiy(string prompt_name)
        {
            count++;
            if (string.IsNullOrEmpty(prompt_name))
                return count.ToString();
            else return prompt_name;

        }

        protected CommandShell(string Name, string id = null)
        {
            this.Name = Name;
            this.InstanceId = identifiy(id);
            this.Commands = new List<ProcessCommandAdapter>();
            this.Responses = new List<ProcessCommandResponseAdapter>();
        }

        IList<ProcessCommandAdapter> Commands { get; }

        IList<ProcessCommandResponseAdapter> Responses { get; }

        protected string Name { get; }

        protected string InstanceId { get; }

        string ICommandShell.Name
            => Name;

        string ICommandShell.InstanceId
            => InstanceId;

        protected abstract ProcessMessage Interpret(IProcessCommand command);

        protected IProcessResponseMessge Execute(IProcessCommand command)
        {
            var adapter = new ProcessCommandAdapter(command);
            Commands.Add(adapter);
            var content = Interpret(command);
            var response = command.Ok(command.GetType(), content);
            Responses.Add(new ProcessCommandResponseAdapter(adapter, response));
            return response;
        }

        public R Execute<C, R>(C command)
            where C : IProcessCommand
            where R : IProcessResponseMessge
        {
            try
            {

                return (R)Execute(command);
            }
            catch (Exception)
            {
                throw;    
            }
        }

        R ICommandShell.Process<C, R>(C command)
            => Execute<C, R>(command);

        IProcessResponseMessge ICommandShell.Execute(IProcessCommand command)
            => Execute(command);
    }

    public abstract class CommandShell<S> : CommandShell
        where S : CommandShell<S>
    {
        protected CommandShell(string id = null)
            : base(typeof(S).Name, id)
        {

        }
    }
}