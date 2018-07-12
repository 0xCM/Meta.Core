//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Diagnostics.Tracing;

public interface IAppMessage : ICorrelated
{
    /// <summary>
    /// Identifies the message instance
    /// </summary>
    Guid MessageId { get; }

    /// <summary>
    /// Parameterized text that is populated with message-specific values
    /// </summary>
    string MessageTemplate { get; }
    
    /// <summary>
    /// The name of the category to which the message belongs
    /// </summary>
    string MessageCategory { get; }

    /// <summary>
    /// Classifies the message with respect to the category
    /// </summary>
    string MessageType { get; }

    /// <summary>
    /// Identifies the component that originated the message
    /// </summary>
    string SourceComponent { get; }

    /// <summary>
    /// Moniker that designates both category and type
    /// </summary>
    /// <remarks>
    /// For example:
    /// /MessageCategory-A/Subcategory-A/MessageType-B
    /// /MessageCategory-A/MessageType-A/MessageType-A-Subtype-A
    /// /Messagecategory-A/MessageType-B
    /// </remarks>
    string MessageTypePath { get; }


    EventLevel EventLevel { get; }

    /// <summary>
    /// The time at which the message was issued
    /// </summary>
    DateTime Timestamp { get; }
    
    /// <summary>
    /// Specifies whether the message has content
    /// </summary>
    bool IsEmpty { get; }

    object SemanticContent { get; }

    /// <summary>
    /// Formats the message by applying the parameter values to the template specified for the message
    /// </summary>
    /// <param name="ts">Whether to prepend the message timestamp to the formatted output</param>
    /// <returns></returns>
    string Format(bool ts = false);

    string Format(string prepend, string postpend = null, bool ts = true);

}

public interface IAppMessage<C> : IAppMessage
{
    new C SemanticContent { get; }
}

public delegate string AppMessageFormatter(IAppMessage Message);
public delegate void AppMessageObserver(IAppMessage Message);
public delegate void MessageObserver(IAppMessage Message);
public delegate IAppMessage MessageInspector(IAppMessage Message);
public delegate IAppMessage MessageTransformer(IAppMessage Message);


