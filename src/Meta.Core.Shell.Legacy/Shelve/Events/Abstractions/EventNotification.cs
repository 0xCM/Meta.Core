//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using N = SystemNodeIdentifier;

    using static metacore;

    public abstract class EventNotification<E> : IEventNotification<E>
        where E : INodeEvent<E>
    {


        protected EventNotification(E Event, N Target)
        {
            this.Event = Event;
            this.Content = Event.Body;
            this.Target = Target;
        }

        /// <summary>
        /// The reason for the notification
        /// </summary>
        public INodeEvent Event { get; }

        /// <summary>
        /// The event content
        /// </summary>
        public E Content { get; }
            
        /// <summary>
        /// The emitting node
        /// </summary>
        public N Source
            => Event.SourceNode;

        /// <summary>
        /// The receiving node
        /// </summary>
        public N Target { get; }

        public CorrelationToken? CT
            => Event.CT;

        object INodeMessage.Content
            => Content;

        public override string ToString()
            => Event.ToString();
    }    

}