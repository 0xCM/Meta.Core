//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics.Tracing;


public static class AppMessageX
{
    public static bool IsBabble(this IAppMessage m)
        => m.EventLevel == EventLevel.Verbose;

    public static bool IsError(this IAppMessage m)
        => m.EventLevel == EventLevel.Error || m.EventLevel == EventLevel.Critical;

    public static bool IsWarning(this IAppMessage m)
        => m.EventLevel == EventLevel.Warning;

    /// <summary>
    /// Defines a <see cref="IAppMessage"/> based on an exception
    /// </summary>
    /// <param name="e">The exception</param>
    /// <returns></returns>
    public static IAppMessage DefineExceptionMessage(this Exception e)
    {
        if (e is TargetInvocationException)
            return AppMessage.Error((e as TargetInvocationException).InnerException);
        else if (e.InnerException != null)
            return (AppMessage.Error(e.InnerException));
        else
            return AppMessage.Error(e);
    }

    /// <summary>
    /// Returns some(message) if the message is nonemty; otherwise none
    /// </summary>
    /// <param name="message">The message to adjudicate</param>
    /// <returns></returns>
    public static Option<IAppMessage> ToOption(this IAppMessage message)
        => message == null ? Option.None<IAppMessage>() 
          : message.IsEmpty ? Option.None<IAppMessage>() 
          : Option.Some(message);


}
