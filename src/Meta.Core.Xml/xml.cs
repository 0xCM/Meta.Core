//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;


using static metacore;

public static class xmlfunc
{
    public static string tag<T>(object content,int indent = 0)
        => concat(tabs(indent),  $"<{typeof(T).Name}>{content}</{typeof(T).Name}>");

    public static string attrib(string name, object value)
        => spaced(name, enquote(toString(value)));

    public static string attrib((string name, object value) x)
        => attrib(x.name, x.value);

    public static string attribs(params (string name, object value)[] attribs)
        => spaced(map(attribs, attrib));

    public static string attribs<T>(params (string name, object value)[] attribs)
        => $"<{typeof(T).Name} {xmlfunc.attribs(attribs)}/>";

    public static string tag(string tagName, object content, int indent, params (string name, object value)[] attribs)
        => concat(tabs(indent), $"<{tagName}{xmlfunc.attribs(attribs)}>{content}</{tagName}>");

    public static string tag(string tagName, object content, params (string name, object value)[] attribs)
        => $"<{tagName}{xmlfunc.attribs(attribs)}>{content}</{tagName}>";

    public static string tagOpen(string name, string attribs = null)
        => isBlank(attribs) ? $"<{name}>" :  $"<{name} {attribs}>";

    public static string tagClose(string name)
        => $"</{name}>";

    public static string block(params object[] content)
        => string.Join(eol(), content);
}