//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using Meta.Core;

using static metacore;


/// <summary>
/// Resolves values using the runtime <see cref="Environment"/>
/// </summary>
public class EnvironmentVariableResolver  : IValueResolver
{
    public static readonly IValueResolver Default 
        = new EnvironmentVariableResolver();

    static object Resolve(string name)
    {
        var pv = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        if (isNotBlank(pv))
            return pv;

        var pu = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
        if (isNotBlank(pu))
            return pu;

        var pm = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
        if (isNotBlank(pm))
            return pm;

        return default(string);
    }

    IValueResolver Resolver = new CanonicalValueResolver(Resolve);

    public Option<V> TryResolveValue<V>(string ValueName)
        => Resolver.TryResolveValue<V>(ValueName);

    public V ResolveValue<V>(string ValueName)
        => Resolver.ResolveValue<V>(ValueName);

    public V ResolveValue<V>(ISymbolicElement element, Func<V> DefaultProvider)
    {
        switch (element)
        {
            case ISymbolicVariable v:
                return ResolveValue(v.VariableName, DefaultProvider);
            case ISymbolicLiteral<V> l:
                return l.Value;
            default:
                return (DefaultProvider ?? (() => default(V)))();
        }

    }
    public V ResolveValue<V>(string ValueName, Func<V> DefaultProvider)
        => Resolver.ResolveValue(ValueName, DefaultProvider);
}