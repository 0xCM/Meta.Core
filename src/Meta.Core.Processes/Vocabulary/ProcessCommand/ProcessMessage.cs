//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Collections.Generic;

    using Messaging;

    /// <summary>
    /// Defines a message that can be sent/received via the command line
    /// </summary>
    public sealed class ProcessMessage : Message<ProcessMessage, string>
    {

        public static ProcessMessage ErrorResponse(string type, string text)
            => Parse(type, text, ProcessMessageType.Error);

        public static ProcessMessage SystemError(Exception e)
            => Parse("syserror", e.ToString());

        public static ProcessMessage SuccessResponse(string type, string text)
            => Parse(type, text, ProcessMessageType.Ok);

        public static ProcessMessage CommandSubmission(string type, string text = null)
            => Parse(type, text ?? string.Empty, ProcessMessageType.Command);


        static ProcessMessage Parse(string type, string text, ProcessMessageType? classifier = null)
            => new ProcessMessage(type, text?.Trim() ?? string.Empty, classifier);

        public ProcessMessage()
            : this("anonymous", string.Empty)
        { }

        public ProcessMessage(string type, string content, ProcessMessageType? classifier = null)
            : base(type, content)
        {
            this.Classifier = classifier ?? ProcessMessageType.None;
        }

        public ProcessMessageType Classifier { get; }



    }

}