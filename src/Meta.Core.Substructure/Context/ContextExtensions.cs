//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Meta.Core;
using System.Runtime.CompilerServices;

using N = SystemNode;

public static class ContextExtensions
{
    public static INodeContext NodeContext(this IApplicationContext C, N Host)
        => global::NodeContext.Get(C, Host);

    public static ILinkedContext LinkedContext(this IApplicationContext C, Link<N, N> Link)
        => new LinkedContext(C, Link);

    public static ILinkedContext LinkedContext(this IApplicationContext C, Link<N> Link)
        => new LinkedContext(C, Link);

    public static ILinkedContext LinkedContext(this IApplicationContext C, N Node)
        => new LinkedContext(C, Node.LinkToSelf());

    public static ILinkedContext LinkedContext(this IApplicationContext C, N Source, N Target)
        => new LinkedContext(C, Source.LinkTo(Target));

    public static ILinkedContext LinkedContext(this IApplicationContext C, NodeLink Link)
        => new LinkedContext(C, Link);

    public static ILinkedContext Context(this NodeLink Link, IApplicationContext C)
        => new global::LinkedContext(C, Link);

    public static ILinkedContext Context(this Link<N> Link, IApplicationContext C)
        => new global::LinkedContext(C, Link);

    /// <summary>
    /// Raises a message on a context
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <param name="message">The message to raise</param>
    /// <returns></returns>
    public static IAppMessage Notify(this IApplicationContext C, IAppMessage message)
    {
        C.PostMessage(message);
        return message;
    }

    /// <summary>
    /// Posts an informational or verbose message with no semantic content
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <param name="text">The text of the notification</param>
    /// <param name="callerFile"></param>
    /// <param name="callerName"></param>
    /// <returns></returns>
    public static IAppMessage NotifyStatus(this IApplicationContext C, string text,
            bool babble = false,
            [CallerMemberName] string callerFile = null,
            [CallerMemberName] string callerName = null)
        => C.Notify(babble ? AppMessage.Babble(text, callerFile, callerName)
                            : AppMessage.Inform(text, callerFile, callerName)
            );

    /// <summary>
    /// Posts a notification without semantic content for an exception that was trapped
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <param name="e">The exception that was raised</param>
    /// <param name="callerFile"></param>
    /// <param name="callerName"></param>
    /// <returns></returns>
    public static IAppMessage NotifyError(this IApplicationContext C, Exception e,
            [CallerMemberName] string callerFile = null,
            [CallerMemberName] string callerName = null)
        => C.Notify(AppMessage.Error(e, callerFile, callerName));

    /// <summary>
    /// Posts an error notification without semantic content 
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <param name="text">The notification text</param>
    /// <param name="callerFile"></param>
    /// <param name="callerName"></param>
    /// <returns></returns>
    public static IAppMessage NotifyError(this IApplicationContext C, string text,
            [CallerMemberName] string callerFile = null,
            [CallerMemberName] string callerName = null)
        => C.Notify(AppMessage.Error(text, callerFile, callerName));

    /// <summary>
    /// Raises a notification for each message in a sequence
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <param name="messages"></param>
    /// <returns></returns>
    public static ReadOnlyList<IAppMessage> Notify(this IApplicationContext C,
        IEnumerable<IAppMessage> messages)
            => messages.Select(message => C.Notify(message)).ToReadOnlyList();

    public static bool _Evaluate(this IApplicationContext C, IOption option)
    {
        if (option.IsNone)
        {
            if (option.Message.IsEmpty)
                C.NotifyError("Explanatory text does not exist");
            else
                C.Notify(option.Message);
        }
        else
        {
            if (!option.Message.IsEmpty)
                C.Notify(option.Message);
        }
        return option.IsSome;
    }

}

