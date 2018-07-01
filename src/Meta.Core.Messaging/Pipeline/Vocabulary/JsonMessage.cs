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




    public sealed class JsonMessage<C> : Message<JsonMessage<C>, C>
       where C : new()
    {

        public static JsonMessage<C> FromInfo(MessageInfo info)
            => new JsonMessage<C>(info.MessageBody, info.MessageId);

        public JsonMessage()
            : base(new C())
        {

        }

        public JsonMessage(C Body, Guid? MessageId = null)
            : base(typeof(C).Name, Body, MessageId)
        {

        }

        public JsonMessage(string Body, Guid? MessageId = null)
           : base(typeof(C).Name, JsonServices.ToObject<C>(Body), MessageId)
        {

        }

        protected override string RenderContent(C content)
            => JsonServices.ToJson(content);

        protected override C ParseContent(string content)
            => JsonServices.ToObject<C>(content);
    }




}