//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;

using static minicore;

/// <summary>
/// Base class for components that depend on an execution context
/// </summary>
public abstract class ApplicationComponent : IApplicationComponent
{
    public const string DefaultImplementationName = "Default";

    /// <summary>
    /// The Broker to which the component will post notifications
    /// </summary>
    IMessageBroker Broker { get; }

    /// <summary>
    /// The context in which the component is executing
    /// </summary>
    protected IApplicationContext Context { get; }

    /// <summary>
    /// The context in which the component is executing
    /// </summary>
    protected IApplicationContext C { get; }

    IApplicationContext IApplicationComponent.Context
        => Context;

    /// <summary>
    /// Gets the notification verbosity desired by the component
    /// </summary>
    protected virtual EventLevel NotificationEventLevel
        => EventLevel.Verbose;

    bool Allow(IAppMessage message)
    {
        if (message == null)
        {
            Notify(AppMessage.Error("Notification message is null"));
            return false;
        }
        var incoming = cast<int>(message.EventLevel);
        var threshold = cast<int>(NotificationEventLevel);
        return incoming <= threshold;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationContext"/> type
    /// </summary>
    /// <param name="C"></param>
    protected ApplicationComponent(IApplicationContext C, IMessageBroker MessageBroker = null)
    {
        this.Context = C;
        this.C = C;
        this.Broker = new FilteredMessageBroker(() => MessageBroker ?? C.Service<IMessageBroker>(), Allow);
    }
  
    /// <summary>
    /// Posts a message to the message broker
    /// </summary>
    /// <param name="m">The notification instance</param>    
    protected void Notify(IAppMessage m)
        => Broker.Route(m);

    /// <summary>
    /// Posts a status message to the message broker
    /// </summary>
    /// <param name="StatusMessage"></param>
    protected void NotifyStatus(string StatusMessage)
        => Broker.Route(AppMessage.Inform(StatusMessage));

    /// <summary>
    /// Posts an error message to the message broker
    /// </summary>
    /// <param name="ErrorMessage"></param>
    protected void NotifyError(string ErrorMessage)
        => Broker.Route(AppMessage.Error(ErrorMessage));

    /// <summary>
    /// Posts an error message to the message broker
    /// </summary>
    /// <param name="e">The related exception</param>
    protected void NotifyError(Exception e)
        => Broker.Route(AppMessage.Error(e));

    protected T Setting<T>(string name) 
        => Context.ConfigurationProvider.GetSetting<T>(name);

    protected bool HasSetting(string name) 
        => Context.ConfigurationProvider.HasSetting(name);

    protected T Service<T>(string implementationName)
        => Context.Service<T>(implementationName);

    [DebuggerStepThrough]
    protected T Service<T>()
        => Context.Service<T>();

    /// <summary>
    /// Determines whether the identified service is available
    /// </summary>
    /// <typeparam name="T">The service contract type</typeparam>
    /// <param name="implementationName">The name of the implementation</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    protected bool IsServiceProvided<T>(string implementationName = DefaultImplementationName)
        => Context.IsServiceProvided<T>(implementationName);

    /// <summary>
    /// Retrieves the specified setting group
    /// </summary>
    /// <typeparam name="C">The setting group type</typeparam>
    /// <returns></returns>
    [DebuggerStepThrough]
    protected C Settings<C>() where C : ProvidedConfiguration<C>
        => ProvidedConfiguration<C>.FromProvider(Context.ConfigurationProvider);

    protected void Print<X>(X item)
        => C.NotifyStatus($"{item}");

    protected void Print<X>(Option<X> item)
        => item.OnSome(x => C.NotifyStatus($"{x}"))
               .OnNone(m => C.Notify(m));

    protected void PrintSequence<X>(IEnumerable<X> items)
        => iter(items, Print);

    protected void PrintSequence<X>(Option<IReadOnlyList<X>> items)
        => items.OnSome(_items => iter(_items, Print)).OnNone(Notify);

    protected void PrintSequence<X>(Option<ReadOnlyList<X>> items)
        => items.OnSome(_items => iter(_items, Print)).OnNone(Notify);

    protected X Inspect<X>(X item)
    {
        Print(item);
        return item;
    }

    protected Option<X> Inspect<X>(Option<X> item)
    {
        Print(item);
        return item;
    }

    protected IEnumerable<X> InspectSequence<X>(IEnumerable<X> items)
    {
        PrintSequence(items);
        return items;
    }

    protected Option<IReadOnlyList<X>> InspectSequence<X>(Option<IReadOnlyList<X>> items)
    {
        PrintSequence(items);
        return items;
    }

    protected Option<ReadOnlyList<X>> InspectSequence<X>(Option<ReadOnlyList<X>> items)
    {
        PrintSequence(items);
        return items;
    }

    protected void Process<P>(Option<P> result, Action<P> processor)        
    {            
        result.OnNone(Notify)
              .OnSome(records => processor(records));        
    }

    protected void ProcessValue<X>(X outcome, Action<X> receiver, Func<IAppMessage> onPreProcess = null)
    {
        if (onPreProcess != null)
            Notify(onPreProcess());

        if (outcome != null)
            receiver(outcome);
        else
            NotifyStatus($"Outcome of type {typeof(X)} had no value");
    }

    protected void Process<X>(Option<X> outcome, Action<X> receiver,
        Func<IAppMessage> onPreProcess = null)
    {
        if (onPreProcess != null)
            Notify(onPreProcess());

        outcome.OnNone(Notify).OnSome(receiver);
    }

    protected void Process<X>(Option<IReadOnlyList<X>> outcome, Action<IReadOnlyList<X>> receiver,
        Func<IAppMessage> onPreProcess = null)
    {
        if (onPreProcess != null)
            Notify(onPreProcess());

        outcome.OnNone(Notify).OnSome(receiver);
    }

    protected void ProcessItems<P>(IReadOnlyList<P> result, Action<P> receiver)
        => iter(result, receiver);

    protected void ProcessItems<P>(IEnumerable<P> result, Action<P> receiver)
        => iter(result, receiver);

    protected Option<T> Witness<T>(Option<T> input, Action<T> Success, Action<IAppMessage> Failure)
    {
        input.OnSome(Success).OnNone(Failure);
        return input;
    }

    //protected ICommandPatternLibrary CommandLibrary
    //    => C.CommandLibrary();

    protected IAppMessage PostMessage(IAppMessage message)
    {
        Notify(message);
        return message;
    }


    public IAssemblyDesignator DefiningAssembly
        => GetType().Assembly.Designator();


    public virtual string ComponentName
        => GetType().Name;

    public override string ToString()
        => ComponentName;
}