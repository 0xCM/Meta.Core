//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    /// <summary>
    /// Defines minimal set of required operations the provide 
    /// the shell adaptation facility
    /// </summary>
    public interface IShellAdapter
    {
        /// <summary>
        /// Specifies the action that, when invoked, sends a message to the adapted shell process
        /// </summary>
        Action<string> DataSender { get; }

        /// <summary>
        /// Specifies the action that will receive data messages from the adapted shell process
        /// </summary>
        Action<string> DataReceiver { get; }

        /// <summary>
        /// Specifies the action that will receive error messages from the adapted shell process
        /// </summary>
        Action<string> ErrorReceiver { get; }

    }


}