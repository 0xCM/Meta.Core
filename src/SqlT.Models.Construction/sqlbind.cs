//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

using Meta.Core;
using SqlT.Models;
using SqlT.Core;
using SqlT.Types;

public static class sqlbind
{
    public static SqlMessageFormatBinding<P> bindFormat<P>(string template, params Expression<Func<P, object>>[] Selectors)
        where P : class, ISqlProxy, new()
        => SqlProxyTypeBinding.BindFormat<P>(TypedMessageFormat.Define(template, Selectors));

    public static SqlEnumBinding<T, E> bindEnum<T, E>()
        where T : class, ISqlTabularProxy, new()
            => SqlProxyTypeBinding.BindEnum<T, E>();
 }