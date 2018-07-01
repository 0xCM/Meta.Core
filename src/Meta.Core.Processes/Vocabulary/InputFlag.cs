//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{


    public sealed class InputFlag
    {
        public InputFlag(string flag_identifier, string flag_marker = "/")
        {
            this.flag_identifier = flag_identifier;
            this.flag_marker = flag_marker;
        }

        /// <summary>
        /// Uniquely identifies the flag (which may have synonyms)
        /// </summary>
        public string flag_identifier { get; set; }

        /// <summary>
        /// Expression which signals that a switch begins immediately thereafter
        /// </summary>
        public string flag_marker { get; set; }

        public override string ToString()
            => $"{flag_marker}{flag_identifier}";
    }


}