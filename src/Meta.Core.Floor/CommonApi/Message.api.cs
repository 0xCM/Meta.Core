//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

using Meta.Core;

public static partial class metacore
{

    /// <summary>
    /// Combines two messages to create a new message
    /// </summary>
    /// <param name="m1">The first message</param>
    /// <param name="m2">The second message</param>
    /// <returns></returns>
    public static IAppMessage combine(IAppMessage m1, IAppMessage m2)
        => AppMessage.Combine(m1, m2);

    /// <summary>
    /// Formats a typed message using type-specific formatting, if available; otherwise, renders the message via ToString()
    /// </summary>
    /// <typeparam name="M">The type of the message to format</typeparam>
    /// <param name="message">The message to format</param>
    /// <returns></returns>
    public static string render<M>(M message)
        => TypedMessageFormat.Render(message);

    /// <summary>
    /// Defines a verbose message
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage babble(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Babble(text, callerFile, callerName);

    /// <summary>
    /// Defines a verbose correlated message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage babble(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Babble(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a verbose message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage babble<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Babble(template, content, callerFile, callerName);

    /// <summary>
    /// Defines a verbose correlated message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="CT">The correlation value</param>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage babble<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Babble(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a status message
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage inform(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Inform(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated status message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage inform(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Inform(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a status message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage inform<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Inform(template, content, callerFile, callerName);

    /// <summary>
    /// Defines a correlated status message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="CT">The correlation value</param>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage inform<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Inform(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a warning
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage warn(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Warn(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated warning
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage warn(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Warn(text, callerFile, callerName);

    /// <summary>
    /// Defines a warning message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage warn<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Warn(template, content, callerFile, callerName);

    /// <summary>
    /// Defines a correlated warning with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="CT">The correlation value</param>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage warn<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Warn(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines an error message
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated error message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a error message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(template, content, callerFile, callerName);

    /// <summary>
    /// Defines an error message based on an exception
    /// </summary>
    /// <param name="e">The exeption upon which the message will be based</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error(Exception e,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(e, callerFile, callerName);

    /// <summary>
    /// Defines a correlated error message based on an exception
    /// </summary>
    /// <param name="e">The exeption upon which the message will be based</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error(CorrelationToken CT, Exception e,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(CT, e, callerFile, callerName);

    /// <summary>
    /// Defines a correlated error message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="CT">The correlation value</param>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IAppMessage error<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => AppMessage.Error(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a typed message format
    /// </summary>
    /// <typeparam name="M">The type of the message with which the format string wil be associated</typeparam>
    /// <param name="template"></param>
    /// <param name="Selectors"></param>
    /// <returns></returns>
    public static TypedMessageFormat defineFormat<M>(string template, params Expression<Func<M, object>>[] Selectors)
            => TypedMessageFormat.Define(template, Selectors);

    /// <summary>
    /// Emits the value to the console
    /// </summary>
    /// <typeparam name="T">The type of value to print</typeparam>
    /// <param name="value">The value to print</param>
    public static void print<T>(T value)
        => SystemConsole.Get().Write(inform(show(value)));

  
}
