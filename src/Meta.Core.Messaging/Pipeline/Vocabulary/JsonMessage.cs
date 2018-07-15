//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Reflection;

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