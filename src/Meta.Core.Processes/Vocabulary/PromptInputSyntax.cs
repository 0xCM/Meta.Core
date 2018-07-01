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

    public sealed class PromptInputSyntax
    {

        public static readonly PromptInputSyntax empty = new PromptInputSyntax();

        public static PromptInputSyntax define(string prototype, string command_name)
            => new PromptInputSyntax(prototype, command_name);

        public PromptInputSyntax(string prototype, string command_name,
            IEnumerable<InputFlag> flags,
            IEnumerable<InputParameter> parameters
            )
        {
            this.prototype = prototype;
            this.parameters = parameters.ToArray();
            this.flags = flags.ToArray();
            this.command_name = command_name;
            this.argument_separator = " ";
        }
        public PromptInputSyntax(string prototype, string command_name)
            : this(prototype, command_name, 
                  new InputFlag[] { }, 
                  new InputParameter[] { }
                  )
        {

        }


        public PromptInputSyntax()
            : this(string.Empty, string.Empty)
        {
            
        }


        public string prototype { get; set; }

        public InputParameter[] parameters { get; set; }

        public InputFlag[] flags { get; set; }

        public string command_name { get; set; }

        public string argument_separator { get; set; }

        public PromptInputSyntax with_flags(params InputFlag[] flags)
            => new PromptInputSyntax (prototype, command_name, flags, parameters);


        public PromptInputSyntax with_flags(char marker, params string[] flags)
            => new PromptInputSyntax(prototype, command_name,
                flags.Select(f => new InputFlag(f, marker.ToString())),
                parameters);

        public PromptInputSyntax with_flags(params string[] flags)
            => new PromptInputSyntax(prototype, command_name, 
                flags.Select(f => new InputFlag(f)), 
                parameters);

        public PromptInputSyntax with_parameters(params InputParameter[] parameters)
            => new PromptInputSyntax(prototype, command_name, flags, parameters);


        static IEnumerable<InputParameter> position_parameters(string[] identifiers)
        {
            int start = 0;
            foreach (var identifier in identifiers)
                yield return InputParameter.at_position(identifier, start++);
        }

        public PromptInputSyntax with_positional_parameters(params string[] parameters)                               
            => new PromptInputSyntax(prototype, 
                command_name, 
                flags, 
                position_parameters(parameters)
                );

        

        public override string ToString()
            => $"{command_name} {parameters}";

    }

}
