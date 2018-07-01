//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

public static class AppMessageX
{
    public static bool IsBabble(this IApplicationMessage m)
        => m.EventLevel == EventLevel.Verbose;

    public static bool IsError(this IApplicationMessage m)
        => m.EventLevel == EventLevel.Error || m.EventLevel == EventLevel.Critical;

    public static bool IsWarning(this IApplicationMessage m)
        => m.EventLevel == EventLevel.Warning;

    /// <summary>
    /// Defines a <see cref="IApplicationMessage"/> based on an exception
    /// </summary>
    /// <param name="e">The exception</param>
    /// <returns></returns>
    public static IApplicationMessage DefineExceptionMessage(this Exception e)
    {
        if (e is TargetInvocationException)
            return ApplicationMessage.Error((e as TargetInvocationException).InnerException);
        else if (e.InnerException != null)
            return (ApplicationMessage.Error(e.InnerException));
        else
            return ApplicationMessage.Error(e);
    }

    /// <summary>
    /// Returns some(message) if the message is nonemty; otherwise none
    /// </summary>
    /// <param name="message">The message to adjudicate</param>
    /// <returns></returns>
    public static Option<IApplicationMessage> ToOption(this IApplicationMessage message)
        => message.IsEmpty ? Option.None<IApplicationMessage>() : Option.Some(message);


}
