//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    using static metacore;

    public static class SqlOption
    {
        public static IApplicationMessage ToAppMessage(this SqlException e, SqlScript Sql)
            => error($"SQL error {e.Number} occurred. {e.Message} Script: {Sql}");

        public static Option<P> ToOption<P>(this SqlOutcome<P> x)
        => x ? some(x.Payload)
             : none<P>(ApplicationMessage.Error(x.Messages.Render()));

        public static Option<TDst> ToOption<TDst>(this ISqlOutcome x)
            => x.Succeeded
            ? some((TDst)x.Payload, ApplicationMessage.Inform(x.Message))
            : none<TDst>(ApplicationMessage.Error(x.Message));

        public static Option<TDst> ToOption<TDst>(this ISqlOutcome x, Func<TDst, IApplicationMessage> onSuccess)
            => x.Succeeded
            ? some((TDst)x.Payload, onSuccess((TDst)x.Payload))
            : none<TDst>(ApplicationMessage.Error(x.Message));


        public static Option<P> ToOption<P>(this SqlOutcome<P> x, Func<P, IApplicationMessage> onSuccess)
            => x ? some(x.Payload, onSuccess(x.Payload))
                 : none<P>(ApplicationMessage.Error(x.Messages.Render()));


        public static Option<TResult> Use<T, TResult>(SqlScript sql, T resource, Func<T, TResult> use) where T : IDisposable
        {
            try
            {
                using (resource)
                    return use(resource);
            }
            catch (SqlException e)
            {

                return none<TResult>(e.ToAppMessage(sql));
            }
            catch (Exception e)
            {
                return new SqlOutcome<TResult>(e, sql);
            }
        }

    }


}