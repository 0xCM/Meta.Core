//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Reflection;
using System.IO;

public class ApplicationMessage : IApplicationMessage
{
    public static IApplicationMessage FromState(ApplicationMessageState state)
        => new ApplicationMessage(state);

    public static readonly IApplicationMessage Empty
        = new ApplicationMessage(ApplicationMessageState.Empty);

    public static implicit operator string(ApplicationMessage x)
        => x.Format(true);

    /// <summary>
    /// Formats the message for display
    /// </summary>
    /// <param name="message">The message to format</param>
    /// <param name="template">The template to apply</param>
    /// <param name="ts">Specifies whether timestamp should be prepended to message output</param>
    /// <param name="args">Valus used to populate template variables</param>
    /// <returns></returns>
    internal static string Format(IApplicationMessage message, string template, bool ts,  params object[] args)
    {        
        var argValues = from arg in args
                        from m in TypedMessageDataMember.Get(arg.GetType()).Values
                        let argName = m.Member.GetOptionalAttribute<DisplayNameAttribute>().MapValueOrDefault(a => a.DisplayName, m.Name)
                        select new
                        {
                            ArgName = argName,
                            ArgValue = m.GetValue(arg)?.ToString() ?? String.Empty
                        };
        var output = template;
        foreach (var argValue in argValues)
            output = output.Replace($"$({argValue.ArgName})", argValue.ArgValue)
                           .Replace($"@{argValue.ArgName}", argValue.ArgValue);
       
        return (ts ? message.Timestamp.ToString() : string.Empty) + " " + output;
    }

    internal static string Format(IApplicationMessage message, string prepend, string postpend, bool ts)
        => (!string.IsNullOrWhiteSpace(prepend) ? $"{prepend} {message.Format(false)}" : message.Format(ts))
         + (!string.IsNullOrWhiteSpace(postpend) ? $" {postpend}" : String.Empty);

    static string DeriveMessageType(string callerFile, string callerName)
        => $"/{Path.GetFileNameWithoutExtension(callerFile)}/{callerName}";

    public static Func<IApplicationMessage, string> DefaultFormatter(string template, bool ts, params object[] args)
        => message => Format(message, template, ts, args);

    public static IApplicationMessage Combine(IApplicationMessage m1, IApplicationMessage m2)
    {
        if (Object.ReferenceEquals(m1, m2))
            return m1;

        var level = (EventLevel)Math.Min((int)m1.EventLevel, (int)m2.EventLevel);
        var template = "FIX ME" + m1.MessageTemplate + "\r\n" + m2.MessageTemplate;
        var ts = m1.Timestamp >= m2.Timestamp ? m1.Timestamp : m2.Timestamp;
        var content = new
        {
            Part1 = m1.SemanticContent,
            Part2 = m2.SemanticContent
        };
        var state = new ApplicationMessageState(
            Template: template,
            Content: content,
            Timestamp: ts,
            CorrelationToken: m2.CT,
            Level: level,
            MessageType: m2.MessageType
            );

        return new ApplicationMessage(state);
    }

    public static IApplicationMessage<C> Babble<C>(string template, C content,  
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Verbose,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage<C> Babble<C>(CorrelationToken CT, string template, C content, 
            [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
                => new ApplicationMessage<C>(new ApplicationMessageState
                    (
                        CorrelationToken: CT,
                        Level: EventLevel.Verbose,
                        Template: template,
                        Content: content,
                        MessageType: DeriveMessageType(callerFile, callerName),
                        SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                    ));

    public static IApplicationMessage<C> BabbleFrom<C>(string template, C content, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Verbose,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source
                ));

    public static IApplicationMessage<C> BabbleFrom<C>(CorrelationToken CT, string template, C content, 
        string source, [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Verbose,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source
                ));


    public static IApplicationMessage Babble(string text,  
        [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null,
        [CallerLineNumber] int? callerLineNumber = null
        )
        => new ApplicationMessage(new ApplicationMessageState
            (
                Level: EventLevel.Verbose,
                Template: text,
                MessageType: DeriveMessageType(callerFile, callerName),
                SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
            ));

    public static IApplicationMessage Babble(CorrelationToken CT, string text, [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null, [CallerLineNumber] int? callerLineNumber = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Verbose,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage Inform(CorrelationToken ct, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null,
        [CallerLineNumber] int? callerLineNumber = null
        )
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Informational,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName(),
                    CorrelationToken: ct
                ));

    public static IApplicationMessage BabbleFrom(string text, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Verbose,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source
                ));

    public static IApplicationMessage<C> Inform<C>(string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Informational,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage<C> Inform<C>(CorrelationToken CT, string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Informational,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage<C> InformFrom<C>(string template, C content, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Informational,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source
                ));

    public static IApplicationMessage Inform(string text, [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
            (
                Level: EventLevel.Informational,
                Template: text,
                MessageType: DeriveMessageType(callerFile, callerName),
                SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
            ));

    public static IApplicationMessage InformFrom(string text, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
        => new ApplicationMessage(new ApplicationMessageState
            (
                Level: EventLevel.Informational,
                Template: text,
                MessageType: DeriveMessageType(callerFile, callerName),
                SourceComponent: source 
            ));

    public static IApplicationMessage Warn(string message, [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Warning,
                    Template: message,
                    Content: new object { },
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage Warn(CorrelationToken CT, string message, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Warning,
                    Template: message,
                    Content: new object { },
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage WarnFrom(string message, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Warning,
                    Template: message,
                    Content: new object { },
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source
                ));


    public static IApplicationMessage<C> Warn<C>(string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Warning,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage<C> Warn<C>(CorrelationToken CT, string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Warning,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage<C> WarnFrom<C>(string template, C content, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Warning,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source

                ));

    public static IApplicationMessage<C> Error<C>(string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage<C> Error<C>(CorrelationToken CT, string template, C content, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Error,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage<C> ErrorFrom<C>(string template, C content, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage<C>(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: template,
                    Content: content,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source

                ));

    public static IApplicationMessage Error(string text, [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage Error(CorrelationToken CT, string text, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Error,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()

                ));

    public static IApplicationMessage ErrorFrom(string text, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: text,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source

                ));

    public static IApplicationMessage Error(Exception e, [CallerFilePath] string callerFile = null, 
        [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: e.ToString(),
                    Content: e,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage Error(CorrelationToken CT, Exception e, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    CorrelationToken: CT,
                    Level: EventLevel.Error,
                    Template: e.ToString(),
                    Content: e,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: Assembly.GetEntryAssembly().GetSimpleName()
                ));

    public static IApplicationMessage ErrorFrom(Exception e, string source, 
        [CallerFilePath] string callerFile = null, [CallerMemberName] string callerName = null)
            => new ApplicationMessage(new ApplicationMessageState
                (
                    Level: EventLevel.Error,
                    Template: e.ToString(),
                    Content: e,
                    MessageType: DeriveMessageType(callerFile, callerName),
                    SourceComponent: source 
                ));

    ApplicationMessageState state { get; }

    internal ApplicationMessage(ApplicationMessageState state)
        => this.state = state;

    ApplicationMessage()
        => this.state = new ApplicationMessageState(string.Empty);

    public Guid MessageId
        => state.MessageId;

    public string MessageCategory
        => "/Status";

    public string MessageType
        => state.MessageType;

    public string MessageTypePath
        => $"{MessageCategory}/{MessageType}";

    public EventLevel EventLevel
        => state.Level;

    public string SourceComponent
        => state.SourceComponent;

    public DateTime Timestamp
        => state.Timestamp ?? DateTime.MinValue;

    public string Format(bool ts)
        => IsEmpty ? String.Empty : Format(this, state.MessageTemplate, ts, state.Content);

    public string Format(string prepend, string postpend, bool ts)
        => Format(this, prepend, postpend, ts);

    public CorrelationToken? CT
        => state.CorrelationToken;

    public bool IsEmpty
        => state.IsEmpty;

    object IApplicationMessage.SemanticContent
        => state.Content;

    public string MessageTemplate
        => state.MessageTemplate;

    public ApplicationMessageState State
        => state;

    public override string ToString()
        => Format(true);

}

public class ApplicationMessage<C> : ApplicationMessage, IApplicationMessage<C>
{
    internal ApplicationMessage(ApplicationMessageState state)
        : base(state)
    { }

    C IApplicationMessage<C>.SemanticContent
        => (C)(this as IApplicationMessage).SemanticContent;
}

