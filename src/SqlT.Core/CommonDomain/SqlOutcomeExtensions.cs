//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;

    using static metacore;

    public static class SqlOutcome
    {
        public static string Render(this IEnumerable<SqlMessage> messages)
        {
            var sb = new StringBuilder();
            foreach (var message in messages)
                sb.AppendLine(message);
            return sb.ToString();
        }

        public static IApplicationMessage ToApplicationMessage(this SqlMessage message)
            => message.IsErrorMessage
            ? ApplicationMessage.Error(message.MessageText)
            : ApplicationMessage.Inform(message.MessageText);

        public static IApplicationMessage ToApplicationMessage(this SqlNotification message)
            => inform(message.Detail);

        public static IEnumerable<SqlError> ErrorList(this SqlException e)
            => from SqlError error in e.Errors select error;

        public static IEnumerable<SqlMessage> ErrorMessages(this SqlException e)
            => from error in e.ErrorList()
               select new SqlErrorMessage(error);


        public static SqlOutcome<P> Success<P>(P payload)
            => new SqlOutcome<P>(payload);

        public static SqlOutcome<P> Success<P>(P Payload, params SqlMessage[] Messages)
            => new SqlOutcome<P>(Payload, Messages);

        public static SqlOutcome<P> Success<P>(P Payload, IEnumerable<SqlMessage> Messages)
            => new SqlOutcome<P>(Payload, Messages.ToArray());

        public static SqlOutcome<P> Failure<P>(Exception e)
            => new SqlOutcome<P>(e);

        public static SqlOutcome<P> Failure<P>(SqlException e)
            => new SqlOutcome<P>(e);

        public static SqlOutcome<P> Failure<P>(IApplicationMessage message)
            => new SqlOutcome<P>(message);

        public static SqlOutcome<P> Failure<P>(IEnumerable<SqlMessage> Messages)
            => new SqlOutcome<P>(Messages.ToArray());

        public static SqlOutcome<P> Failure<P>(params SqlMessage[] Messages)
            => new SqlOutcome<P>(Messages);

        public static SqlOutcome<P> Failure<P>(string message)
            => new SqlOutcome<P>(new SqlMessage(message));

        public static SqlOutcome<P> Bind<X, P>(this SqlOutcome<X> x, Func<X, SqlOutcome<P>> f)
            => x.Succeeded ? f(x.Payload) : Failure<P>(x.Messages.ToArray());

        public static SqlOutcome<P> Select<X, P>(this SqlOutcome<X> x, Func<X, P> selector)
        {
            if (x.Succeeded)
                return selector(x.Payload);
            else
                return Failure<P>(x.Messages.ToArray());
        }

        public static SqlOutcome<P> SelectMany<X, Y, P>(this SqlOutcome<X> x, Func<X, SqlOutcome<Y>> select, Func<X, Y, P> project)
        {
            if (x)
            {
                var y = select(x.Payload);
                var z = y.Bind(yVal => Success(project(x.Payload, yVal), y.Messages));
                return z;
            }
            else
            {
                return Failure<P>(x.Messages);
            }
        }

        public static SqlOutcome<TResult> Use<T, TResult>(string sql, T resource, Func<T, TResult> use) where T : IDisposable
        {
            try
            {
                using (resource)
                    return use(resource);
            }
            catch (SqlException e)
            {
                return new SqlOutcome<TResult>(e, sql);
            }
            catch (Exception e)
            {
                return new SqlOutcome<TResult>(e, sql);
            }
        }


        public static SqlOutcome<T> Try<T>(Func<T> f)
        {
            try
            {
                return f();
            }
            catch (Exception e)
            {
                return SqlOutcome.Failure<T>(e);
            }
        }
    }
}
