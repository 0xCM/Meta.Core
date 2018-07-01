//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using static metacore;

    /// <summary>
    /// Defines default <see cref="IValueResolver"/> implementation that
    /// predicates resolution on constructor-injection function
    /// </summary>
    public sealed class CanonicalValueResolver : IValueResolver
    {                 
        Func<string,object> Resolve { get; }

        public CanonicalValueResolver(Func<string,object> Resolve)
        {
            this.Resolve = Resolve;
        }

        public Option<V> TryResolveValue<V>(string ValueName)
        {
            var value = Resolve(ValueName);
            if (value is V)
                return (V)value;
            else
                return none<V>();               
        }

        public V ResolveValue<V>(ISymbolicElement element, Func<V> DefaultProvider = null)
        {
            switch(element)
            {
                case ISymbolicVariable v:
                    return ResolveValue(v.VariableName,DefaultProvider);
                case ISymbolicLiteral<V> l:
                    return l.Value;
                default:
                    return (DefaultProvider ?? (() => default(V)))();
            }
        }

        public V ResolveValue<V>(string ValueName, Func<V> DefaultProvider = null)
        {
            var value = Resolve(ValueName);
            if (value is V)
                return (V)value;
            else
                return (DefaultProvider ?? (() => default(V)))();
        }
    }
}

