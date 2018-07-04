//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;

    public static partial class SqlBrokerExtensions
    {
        static IEnumerable<TResult> _F<TResult>(ISqlTableFunctionHandle f, params object[] parameters)
            where TResult : class, ISqlTabularProxy, new()
        {
            var broker = (SqlProxyBroker)f.Broker;
            using (var command = broker.CreateFunctionCommand(f.ElementName.AsFunctionName(), null, parameters))
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var proxy = broker.ReadProxy<TResult>(reader.GetValueArray());
                        if (proxy)
                            yield return proxy.ValueOrDefault();
                        else
                            break;   
                    }
                }
            }
        }

        public static Func<IEnumerable<TResult>> F<TResult>(this ISqlTableFunctionHandle f)
            where TResult : class, ISqlTabularProxy, new() 
                => () =>
                    _F<TResult>(f);

        public static Func<P0, IEnumerable<TResult>> F<P0, TResult>(this SqlTableFunctionHandle f)
                where TResult : class, ISqlTabularProxy, new() 
                    => p0 
                        => _F<TResult>(f, p0);

        public static Func<P0, P1, IEnumerable<TResult>> F<P0, P1, TResult>(this ISqlTableFunctionHandle f)
            where TResult : class, ISqlTabularProxy, new() => (p0, p1) => _F<TResult>(f, p0, p1);

        public static IEnumerable<TResult> F<P0, P1, TResult>(this ISqlTableFunctionHandle f, P0 p0, P1 p1)
            where TResult : class, ISqlTabularProxy, new() => _F<TResult>(f, p0, p1);

        public static Func<P0, P1, P2, IEnumerable<TResult>> F<P0, P1, P2, TResult>(this ISqlTableFunctionHandle f)
            where TResult : class, ISqlTabularProxy, new() => (p0, p1, p2) => _F<TResult>(f, p0, p1, p2);
    }
}
