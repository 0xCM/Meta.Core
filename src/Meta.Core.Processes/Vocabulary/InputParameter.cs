//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{


    public class InputParameter
    {
        public static readonly InputParameter empty
            = new InputParameter(string.Empty,
                    parameter_marker: string.Empty,
                    argument_marker: string.Empty,
                    argument_qualifier: string.Empty,
                    named: false,
                    position: null
                );

        public static InputParameter at_position(string identifier, int position)
            => new InputParameter(identifier).at_position(position);


        public InputParameter(string identifier)
        {
            this.identifier = identifier;
            this.parameter_marker = string.Empty;
            this.argument_marker = string.Empty;
            this.argument_qualifier = string.Empty;
            this.named = named;
            this.position = position;
        }

        public InputParameter(string identifier, 
            string parameter_marker = "/", 
            string argument_marker = ":", 
            string argument_qualifier = "\"",
            bool named = true,
            int? position = null
            )
        {
            this.identifier = identifier;
            this.parameter_marker = parameter_marker;
            this.argument_marker = argument_marker;
            this.argument_qualifier = argument_qualifier;
            this.named = named;
            this.position = position;
        }

        /// <summary>
        /// Uniquely identifies the parameter (which may have synonyms)
        /// </summary>
        public string identifier { get; set; }


        /// <summary>
        /// Expression which signals that a parameter begins immediately thereafter
        /// </summary>
        public string parameter_marker { get; set; }

        /// <summary>
        /// Expression that terminates parameter designation and immediatly precedes
        /// argument specification
        /// </summary>
        public string argument_marker { get; set; }

        /// <summary>
        /// Expression that bounds argument value content when needed
        /// </summary>
        public string argument_qualifier { get; set; }

        public bool named { get; set; }

        public int? position { get; set; }


        public InputParameter at_position(int position)
            => new InputParameter(identifier,
                    parameter_marker: parameter_marker,
                    argument_marker: argument_marker,
                    argument_qualifier: argument_qualifier,
                    named: named,
                    position: position
                );




        public override string ToString()
            => $"{parameter_marker}{identifier}{argument_marker}{argument_qualifier}arg_value{argument_qualifier}";
    }

    public class InputParameters : PromptSyntaxList<InputParameters, PromptInputSyntax>
    {
        public InputParameters()
            : base(" ")
        { }
    }

}