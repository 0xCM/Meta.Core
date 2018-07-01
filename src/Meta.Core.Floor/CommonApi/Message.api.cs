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
    public static IApplicationMessage combine(IApplicationMessage m1, IApplicationMessage m2)
        => ApplicationMessage.Combine(m1, m2);

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
    public static IApplicationMessage babble(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Babble(text, callerFile, callerName);

    /// <summary>
    /// Defines a verbose correlated message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage babble(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Babble(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a verbose message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage babble<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Babble(template, content, callerFile, callerName);

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
    public static IApplicationMessage babble<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Babble(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a status message
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage inform(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Inform(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated status message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage inform(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Inform(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a status message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage inform<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Inform(template, content, callerFile, callerName);

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
    public static IApplicationMessage inform<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Inform(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a warning
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage warn(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Warn(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated warning
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage warn(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Warn(text, callerFile, callerName);

    /// <summary>
    /// Defines a warning message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage warn<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Warn(template, content, callerFile, callerName);

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
    public static IApplicationMessage warn<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Warn(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines an error message
    /// </summary>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage error(string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(text, callerFile, callerName);

    /// <summary>
    /// Defines a correlated error message
    /// </summary>
    /// <param name="CT">The correlation value</param>
    /// <param name="text">The message text</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage error(CorrelationToken CT, string text,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(CT, text, callerFile, callerName);

    /// <summary>
    /// Defines a error message with typed content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    /// <param name="template">A content-bound template string</param>
    /// <param name="content">The typed content</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage error<C>(string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(template, content, callerFile, callerName);

    /// <summary>
    /// Defines an error message based on an exception
    /// </summary>
    /// <param name="e">The exeption upon which the message will be based</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage error(Exception e,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(e, callerFile, callerName);

    /// <summary>
    /// Defines a correlated error message based on an exception
    /// </summary>
    /// <param name="e">The exeption upon which the message will be based</param>
    /// <param name="callerFile">The file from which the call was made</param>
    /// <param name="callerName">The name of the invoking member</param>
    /// <returns></returns>
    public static IApplicationMessage error(CorrelationToken CT, Exception e,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(CT, e, callerFile, callerName);

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
    public static IApplicationMessage error<C>(CorrelationToken CT, string template, C content,
        [CallerFilePath] string callerFile = null,
        [CallerMemberName] string callerName = null)
            => ApplicationMessage.Error(CT, template, content, callerFile, callerName);

    /// <summary>
    /// Defines a typed message format
    /// </summary>
    /// <typeparam name="M">The type of the message with which the format string wil be associated</typeparam>
    /// <param name="template"></param>
    /// <param name="Selectors"></param>
    /// <returns></returns>
    public static TypedMessageFormat defineFormat<M>(string template, params Expression<Func<M, object>>[] Selectors)
            => TypedMessageFormat.Define(template, Selectors);


}
