//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.IO;

using static metacore;

public sealed class CommandStatusMessage : IAppMessage
{
    public static readonly CommandStatusMessage Empty = new CommandStatusMessage();


    public static CommandStatusMessage CreateErrorStatus
        (
            ICommandSpec spec,
            long? subid,
            string template,
            object content,
            CorrelationToken? ct = null,
            [CallerMemberName] string messageType = null
        )
        => new CommandStatusMessage(spec, subid, EventLevel.Error, template, ct, messageType);


    CommandStatusMessage()
    {
            
    }

    internal CommandStatusMessage(ICommandSpec spec, long? subid, EventLevel level, string template, CorrelationToken? ct, string MessageType)
    {
        _SubmissionId = subid;
        _Content = spec;
        _CommandName = spec.CommandName;
        _CommandSpecName = spec.SpecName;
        _Antecedent = AppMessage.Empty;
        _EventLevel = level;
        _MessageType = MessageType;
        _Arguments = spec.Arguments;
        _MessageTemplate = template;
        _CorrelationToken = ct;
        _MessageId = Guid.NewGuid();
    }

    long? _SubmissionId { get; }

    object _Content { get; }

    string _MessageTemplate { get; }

    string _CommandName { get; }
        = "Unspecified";

    string _CommandSpecName { get; }
        = "Unspecified";

    string _MessageType { get; }
        = "Unknown";

    EventLevel _EventLevel { get; }
        = EventLevel.Informational;

    IAppMessage _Antecedent { get; }

    DateTime _Timestamp { get; }
        = now();

    CommandArguments _Arguments { get; }
        = new CommandArguments();

    CorrelationToken? _CorrelationToken { get; }

    Guid _MessageId { get; }

    string _SourceComponent { get; }
        = string.Empty;

    public Guid MessageId
        => _MessageId;


    public IAppMessage Antecedent 
        => _Antecedent;

    public IReadOnlyList<CommandArgument> CommandArguments
        => _Arguments.ToList();

    public long? SubmissionId 
        => _SubmissionId;

    public string CommandName 
        => _CommandName;

    public string CommandSpecName
        => _CommandSpecName;

    public EventLevel EventLevel
        => _EventLevel;

    public bool IsEmpty
        => Object.ReferenceEquals(this, Empty);

    public string MessageCategory
        => "/Status/CommandStatus";

    public string MessageType
        => _CommandName;

    public string MessageTemplate
        => _MessageTemplate;

    public string MessageTypePath
        => Path.Combine(MessageCategory, MessageType);

    public DateTime Timestamp
        => _Timestamp;

    public object SemanticContent
        => _Content;

    public string SourceComponent
        => _SourceComponent;

    public string Format(bool ts)
        => AppMessage.DefaultFormatter(_MessageTemplate, ts, _Content)(this);

    public string Format(string prepend, string postpend, bool ts)
        => (isNotBlank(prepend) ? $"{prepend} {Format(false)}" : Format(ts))
         + (isNotBlank(postpend) ? $" {postpend}" : String.Empty);

    public CorrelationToken? CT
        => _CorrelationToken;

    public IEnumerable<IAppMessage> InnerMessages
        => stream<IAppMessage>();
}