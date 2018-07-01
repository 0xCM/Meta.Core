//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{

    /// <summary>
    /// Partitions prompt messsages into equivalence classes
    /// </summary>
    public enum ProcessMessageType
    {
        /// <summary>
        /// No category has ben assigned
        /// </summary>
        None,

        /// <summary>
        /// The message defines a commmand
        /// </summary>
        Command,

        /// <summary>
        /// The message is accumulated from a sequence of packets received
        /// from the standard output stream
        /// </summary>
        Ok,

        /// <summary>
        /// The message is accumulated from a sequence of packets received
        /// from the error output stream
        /// </summary>
        Error,

        SystemError_
    }



}