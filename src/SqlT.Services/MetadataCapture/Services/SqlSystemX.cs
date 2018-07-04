//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;

    using static metacore;

    public static class SqlSystemX
    {

        public static Option<T> WrapInSession<T>(this ISqlProxyBroker broker, Func<T> f)
        {
            try
            {
                var session = broker.CreateSession();
                if (session)
                {
                    using (var s = session.Payload)
                    {
                        var result = f();
                        s.CompleteSession();
                        return result;
                    }
                }
                else
                    return SqlOutcome.Failure<T>(session.Messages);
            }
            catch (Exception e)
            {

                return none<T>(e);

            }
        }

        public static IDependencyResolver NativeViewResolver(this IApplicationContext C)
            => C.Service<IDependencyResolver>(nameof(NativeViewResolver));

        public static ISystemViewProvider SystemViewProvider(this SqlConnectionString connector)
            => SqlSystemViews.Create(new SystemViewsSettings(connector));

        public static IReadOnlyList<V> GetSchemaObjects<V>(this ISystemViewProvider svp, string SchemaName)
            where V : vObject => svp.GetVirtualView<V>().Where(x => x.SchemaName == SchemaName).ToList();

        public static IReadOnlyList<V> GetSchemaTypes<V>(this ISystemViewProvider svp, string SchemaName)
            where V : vType => svp.GetVirtualView<V>().Where(x => x.SchemaName == SchemaName).ToList();
    }
}