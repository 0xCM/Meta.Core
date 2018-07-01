//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;

    /// <summary>
    /// Value emitted upon receipt of a message
    /// </summary>
    public struct MessageReceiptToken
    {
        public static readonly MessageReceiptToken Empty = new MessageReceiptToken(Guid.Empty, false, string.Empty);

        public MessageReceiptToken(Guid MessageId, bool Accepted, string Content)
        {
            this.MessageId = MessageId;
            this.Accepted = Accepted;
            this.Content = Content ?? string.Empty;
        }

        /// <summary>
        /// The id of the received message
        /// </summary>
        public Guid MessageId { get; }

        /// <summary>
        /// Whether the recipient accepted/rejected the message
        /// </summary>
        public bool Accepted { get; }

        /// <summary>
        /// The token content
        /// </summary>
        public string Content { get; }

        public override string ToString()
            => Content ?? string.Empty;
    }


}