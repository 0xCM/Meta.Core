//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.IO;

public abstract class ApplicationNotification : IApplicationMessage
{

    readonly Guid _MessageId;

    public ApplicationNotification()
    {
        this.Timestamp = DateTime.Now;
        this.EventLevel = EventLevel.Informational;
        this._MessageId = Guid.NewGuid();
        this.SourceComponent = Assembly.GetCallingAssembly().GetName().Name;
    }

    public ApplicationNotification(string messageDetail)
        : this()
    {
        this.MessageDetail = messageDetail;
    }


    public string MessageCategory
        => "/Notification";

    public string MessageTypePath
        => Path.Combine(MessageCategory, MessageType);

    /// <summary>
    /// Specifies the time at which the event to which the notification refers occurred
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Specifies the token with which the notification should be correlated
    /// </summary>
    public virtual CorrelationToken? CT { get; set; }

    /// <summary>
    /// Specifies the identifier of the thread from which the notification was raised
    /// </summary>
    public int ThreadId { get; set; }

    /// <summary>
    /// The severity/trace level of the notification
    /// </summary>
    public virtual EventLevel EventLevel { get; set; }


    public string MessageType
        => GetType().Name;

    /// <summary>
    /// Identifies the component that originated the message
    /// </summary>
    public string SourceComponent { get; set; }


    /// <summary>
    /// Specifies detailed, user-friendly and notification-specific information describing what happened
    /// </summary>
    public virtual string MessageDetail { get; set; }

    private string GetMessageDetail()
    {
        var messageDetail = MessageDetail;
        if (String.IsNullOrWhiteSpace(messageDetail))
        {
            var attrib = GetType().GetCustomAttribute<ApplicationMessageAttribute>();
            messageDetail = attrib != null ? attrib.DisplayName : String.Empty;
        }
        if (String.IsNullOrWhiteSpace(messageDetail))
        {
            messageDetail = $"The {GetType().Name} notification provides no detailed message nor display name";
        }
        return messageDetail;
    }

    /// <summary>
    /// Renders the notification for display
    /// </summary>
    public virtual string DisplayMessage
        => Format(true);


    public string Format(bool ts)
        => (ts ? Timestamp.ToString() + " " : String.Empty) + GetMessageDetail();


    string IApplicationMessage.Format(string prepend, string postpend, bool ts)
        => !(string.IsNullOrWhiteSpace(prepend)) ? $"{prepend} {Format(false)}" : Format(ts)
         + (!(string.IsNullOrWhiteSpace(postpend)) ? $" {postpend}" : String.Empty);

    Guid IApplicationMessage.MessageId
        => _MessageId;


    bool IApplicationMessage.IsEmpty
        => false;

    object IApplicationMessage.SemanticContent
        => new object();

    public string MessageTemplate
        => String.Empty;

    public override string ToString()
        => DisplayMessage;


}
