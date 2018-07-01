//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    public sealed class MessageInfo
    {

        public MessageInfo()
        {

        }

        public MessageInfo(Guid MessageId, string MessageType, string MessageBody)
        {
            this.MessageId = MessageId;
            this.MessageType = MessageType;
            this.MessageBody = MessageBody;
        }

        public string MessageType { get; set; }

        public Guid MessageId { get; set; }

        public string MessageBody { get; set; }

        public override string ToString()
            => $"{MessageType} : {MessageBody}";


    }



}