//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;


    public struct MessagePacket<K> : IMessagePacket<K>
    {
        public MessagePacket(Guid CorrelationToken, K Payload, string Label = null)
        {
            this.CorrelationToken = CorrelationToken;
            this.Payload = Payload;
            this.Label = Label ?? string.Empty;
        }

        public Guid CorrelationToken { get; }

        public K Payload { get; }

        public string Label { get; }

        object IMessagePacket.Payload
            => Payload;

        public override string ToString()
            => Payload?.ToString() ?? string.Empty;
    }

    public struct MessagePacket : IMessagePacket<string>
    {
        public MessagePacket(Guid CorrelationToken, string Payload, string Label = null)
        {
            this.CorrelationToken = CorrelationToken;
            this.Payload = Payload ?? string.Empty;
            this.Label = Label ?? string.Empty;
        }

        public Guid CorrelationToken { get; }

        public string Payload { get; }

        public string Label { get; }

        object IMessagePacket.Payload
            => Payload;

        public override string ToString()
            => Payload.ToString();

    }

}