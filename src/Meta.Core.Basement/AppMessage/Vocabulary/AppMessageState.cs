//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics.Tracing;

/// <summary>
/// Encapsulates the state of an application message
/// </summary>
public sealed class AppMessgaeState
{

    public static readonly AppMessgaeState Empty = new AppMessgaeState(true);

    AppMessgaeState(bool Empty)
    {
        MessageTemplate = string.Empty;
        Content = new object();
        Level = EventLevel.Informational;
        MessageType = string.Empty;
        InvokerName = string.Empty;
        InvokerFile = string.Empty;
    }

    public AppMessgaeState()
        : this(true)
    {


    }

    public AppMessgaeState
        (
            string Template,
            object Content = null,
            CorrelationToken? CorrelationToken = null,
            DateTime? Timestamp = null,
            EventLevel? Level = null,
            string MessageType = null,
            string SourceComponent = null,
            string InvokerFile = null,
            string InvokerName = null,
            int? InvokerFileLine= null
        )
    {
        this.MessageId = Guid.NewGuid();
        this.MessageTemplate = Template;
        this.Content = Content ?? new object();
        this.CorrelationToken = CorrelationToken;
        this.SourceComponent = SourceComponent ?? string.Empty;
        this.Timestamp = Timestamp ?? DateTime.Now;
        this.Level = Level ?? EventLevel.Informational;
        this.MessageType = string.IsNullOrWhiteSpace(MessageType) 
            ? "Unclassified" : MessageType;
        this.InvokerFile = InvokerFile;
        this.InvokerName = InvokerName;
        this.InvokerFileLine = InvokerFileLine;
    }

    public Guid MessageId { get; }

    public string MessageTemplate { get;}

    public object Content { get; }

    public string SourceComponent { get; }

    public CorrelationToken? CorrelationToken { get; }

    public DateTime? Timestamp { get; }

    public EventLevel Level { get; }

    public string MessageType { get; }

    public string InvokerName { get; }

    public string InvokerFile { get; }

    public int? InvokerFileLine { get; }

    public bool IsEmpty
        => Object.ReferenceEquals(this, Empty);
}
