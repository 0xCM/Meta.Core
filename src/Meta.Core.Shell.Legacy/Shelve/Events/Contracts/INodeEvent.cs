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

    public interface INodeEvent : ICorrelated
    {
        /// <summary>
        /// The orginating node
        /// </summary>
        N SourceNode { get; }

        /// <summary>
        /// The name of the event
        /// </summary>
        string EventType { get; }
        
        /// <summary>
        /// Event-specific data
        /// </summary>
        object Body { get; }

        /// <summary>
        /// The time at which the event occurred
        /// </summary>
        DateTime EventTS { get; }
       
        /// <summary>
        /// Indicates whether the event indicates an error
        /// </summary>
        bool ErrorCondition { get; }

    }

    public interface INodeEvent<E> : INodeEvent
    {
        new E Body { get; }

    }


}