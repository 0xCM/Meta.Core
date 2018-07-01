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

    /// <summary>
    /// Defines contract for named/symbolic value resolvers
    /// </summary>
    public interface IValueResolver
    {
        Option<V> TryResolveValue<V>(string ValueName);

        V ResolveValue<V>(ISymbolicElement element, Func<V> DefaultProvider = null);
       
        V ResolveValue<V>(string ValueName, Func<V> DefaultProvider = null);
    }





}

