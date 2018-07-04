//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    
    public class vSystemMessage : vSystemElement, ISystemMessage
    {

        readonly ISystemMessage _message;

        public vSystemMessage(ISystemMessage message)
            : base(message.name, message.message_id >= 50000)
        {
            this._message = message;
        }

        int ISystemMessage.message_id
            => _message.message_id;

        short ISystemMessage.language_id
            => _message.language_id;

        byte? ISystemMessage.severity
            => _message.severity;

        bool ISystemMessage.is_event_logged
            => _message.is_event_logged;

        string ISystemMessage.text
            => _message.text;
    }


}