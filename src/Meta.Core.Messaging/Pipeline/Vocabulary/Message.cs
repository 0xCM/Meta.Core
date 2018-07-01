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

    public abstract class Message<M,C> : IEquatable<M>, IMessage<C>
        where M : Message<M,C>, new()
    {

        public static bool operator == (Message<M,C> x, Message<M, C> y)
            => (x ?? Empty(typeof(M).Name)).Equals(y ?? Empty(typeof(M).Name));

        public static bool operator != (Message<M, C> x, Message<M, C> y)
            => !(x == y);

      
        public static M Empty(string type)
            => new M().Retype(type);        

        M Retype(string type)
        {
            Type = type;
            return (M)this;
        }

        protected Message(string type, C Content, Guid? MessageId = null)
        {
            this.Type = type;
            this.Body = Content;
            this.MessageId = MessageId ?? Guid.NewGuid();
        }

        protected Message(C Content)
            : this(typeof(M).Name, Content)
        {
                                   
        }

        public string Type { get; private set; }

        public Guid MessageId { get; private set; }

        public C Body { get; private set; }
       
        object IMessage.Body
            => Body;


        string IMessagePacket<string>.Payload
            => RenderContent(Body);
            

        Guid IMessagePacket.CorrelationToken
            => MessageId;

        object IMessagePacket.Payload
            => RenderContent(Body);

        string IMessagePacket.Label
            => Type;

        public override string ToString()
            => RenderContent(Body);

        public override int GetHashCode()
            => ToCanonicalForm().GetHashCode();

        public override bool Equals(object other)
            => Equals(other as M);

        protected virtual string RenderContent(C content)
            => (content as object)?.ToString() ?? string.Empty;
        
        protected virtual C ParseContent(string content)
        {
            var parser = typeof(M).GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
            if (parser != null)
                return (C)parser.Invoke(null, new object[] { content });

            return default(C);
        }



        public MessageInfo MessageInfo
            => new MessageInfo(MessageId, Type, RenderContent(Body));

        protected virtual M CreateMessage(C content)
            => (M)Activator.CreateInstance(typeof(M), Type, content);

        const string eol = "\r\n";
        const string tab = "\t";
        const string eoltab = eol + tab;
        const string sep = ",";
        const string space = " ";
        const string sepspace = sep + space;
        const string none = "";
        const string open = "{";
        const string close = "}";

        static string format(Guid g)
            => g.ToString("N");

        static string indent(int level = 1)
            => string.Join("", Enumerable.Range(1, level).Select(_ => tab));

        static string line(string text)
            => text + eol;

        static string assign(string name, string value, bool separate = true)
            => indent() + line($"{name} = {value}" + (separate ? sep : none));

        static string block(string marker)
            => line(marker);

        public virtual string ToCanonicalForm()
            => line("message")
               + block(open)
                   + assign("type", Type)
                   + assign("id", format(MessageId))
                   + assign("content", RenderContent(Body), false)
               + block(close);

        public M FromCanonicalForm(string message)
            => CreateMessage(ParseContent(message));

        public bool Equals(M other)
            => ToCanonicalForm().Equals(
                other?.ToCanonicalForm() ?? string.Empty
                );

    }

    public sealed class Message<C> : Message<Message<C>, C>
    {

        public Message(string type, C Content)
            : base(type, Content)
        {

        }


        public Message(string type)
            : this(type, default(C))
        {

        }
        public Message()
            : this("anonymous")
        {

        }


    }


    public sealed class Message : Message<Message,string>
    {
        public Message()
            : base(string.Empty)
        {

        }

        public Message(string Type, string Content)
            : base(Type, Content)
        { }

        protected override string ParseContent(string Content)
            => Content ?? string.Empty;

        protected override Message CreateMessage(string Content)
            => new Message(Type, Content);
    }
}
