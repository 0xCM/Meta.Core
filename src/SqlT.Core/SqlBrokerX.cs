//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Meta.Core;

    using static metacore;
    using static SqlStatusMessages;

    using sxc = SqlT.Syntax.contracts;

    public static class SqlBrokerX
    {
        /// <summary>
        /// Gets the broker factory defined by the assembly
        /// </summary>
        /// <param name="a">The broker factory assembly</param>
        /// <returns></returns>
        public static ISqlProxyBrokerFactory ProxyBrokerFactory(this Assembly a)
            => SqlProxyBroker.GetBrokerFactory(a).Require();

        /// <summary>
        /// Client broker factory method
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public static ISqlClientOptionBroker SqlClientBroker(this SqlConnectionString connector, SqlNotificationObserver observer = null)
        {
            var broker = new SqlClientBroker(connector, observer) as ISqlClientBroker;
            broker.RegisterConverter<DateTime, Date>(SqlConversionDirection.ToProxy,
                src => new Date(src.Year, src.Month, src.Day));

            broker.RegisterConverter<Date, DateTime>(SqlConversionDirection.ToTransport,
                src => src.ToDateTimeAtMidnight());

            broker.RegisterConverter<byte[], SqlRowVersion>(SqlConversionDirection.ToProxy,
                src => (SqlRowVersion)src);

            broker.RegisterConverter<SqlRowVersion, byte[]>(SqlConversionDirection.ToTransport,
                src => src);

            broker.RegisterConverter<TimeSpan, TimeOfDay>
                (SqlConversionDirection.ToProxy,
                    src => new TimeOfDay(src.Hours, src.Minutes, src.Seconds, src.Milliseconds));

            broker.RegisterConverter<TimeOfDay, TimeSpan>
                (SqlConversionDirection.ToTransport,
                    src => new TimeSpan(src.Hour, src.Minute, src.Second, src.Millisecond));
            return new SqlClientOptionBroker(broker);
        }

        public static ISqlClientOptionBroker SqlClientBroker(this ISqlContext C, SqlNotificationObserver observer = null)
            => C.SqlConnector.SqlClientBroker(observer);

        /// <summary>
        /// Creates a broker via the assembly-provided factory
        /// </summary>
        /// <param name="a">An assembling defining a broker factory</param>
        /// <param name="connector">The connection string</param>
        /// <returns></returns>
        public static ISqlProxyBroker ProxyBroker(this Assembly a, SqlConnectionString connector)
                => SqlProxyBroker.CreateBroker(a, connector).Require();

        /// <summary>
        /// Obtains a table handle from the broker
        /// </summary>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <returns></returns>
        public static SqlTableHandle<T> Table<T>(this ISqlProxyBroker Broker)
            where T : class, ISqlTableProxy, new()
            => new SqlTableHandle<T>(Broker);

        /// <summary>
        /// Obtains a view handle from the broker
        /// </summary>
        /// <param name="Broker">The broker that provides access to the handle</param>
        /// <returns></returns>
        public static SqlViewHandle<V> View<V>(this ISqlProxyBroker Broker)
            where V : class, ISqlViewProxy, new()
            => new SqlViewHandle<V>(Broker);

        
        /// <summary>
        /// Describes the column identified by the selector
        /// </summary>
        /// <typeparam name="T">The defining tabular</typeparam>
        /// <typeparam name="C">The column runtime data type</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="selector">The selection expression</param>
        /// <returns></returns>                    
        public static SqlColumnProxyInfo ColumnDescription<T, C>(this ISqlProxyBroker broker, Expression<Func<T, C>> selector)
                where T : class, ISqlTabularProxy, new()
        {
            var tabular = broker.Metadata.Tabular<T>();
            var member = selector.GetMember();
            var column = tabular.FindColumnByRuntimeName(member.Name);
            return column;
        }

        /// <summary>
        /// Gets the name of the database to which the broker is connected
        /// </summary>
        /// <param name="broker">The broker</param>
        /// <returns></returns>
        public static SqlDatabaseName DatabaseName(this ISqlProxyBroker broker)
            => new SqlDatabaseName(broker.ConnectionString.ServerName,
                broker.ConnectionString.DatabaseName);

        public static N ScopeNameToDatabase<N>(this N ObjectName, SqlDatabaseName db)
            where N : SqlObjectName<N>, new()
        {
            if (db == null)
                return ObjectName;

            if (db.IsServerQualified)
            {
                if (!ObjectName.IsServerQualified())
                    return ObjectName.OnDatabase(db);
                else
                    return ObjectName;
            }
            else
            {
                if (!ObjectName.IsDatabaseQualified())
                    return ObjectName.OnDatabase(db);
                else
                    return ObjectName;
            }
        }

        /// <summary>
        /// Creates a 3-part object name
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static sxc.ISqlObjectName GetDbScopedName(this SqlProxyKind kind, sxc.ISqlObjectName name, SqlDatabaseName db)
        {
            switch (kind)
            {
                case SqlProxyKind.Table:
                    return (new SqlTableName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.View:
                    return (new SqlViewName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.TableType:
                    return (new SqlTypeName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.TableFuntion:
                case SqlProxyKind.ScalarFunction:
                    return (new SqlFunctionName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.Procedure:
                    return (new SqlProcedureName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.PrimaryKey:
                    return (new SqlPrimaryKeyName(name)).ScopeNameToDatabase(db);
                case SqlProxyKind.Sequence:
                    return (new SqlSequenceName(name)).ScopeNameToDatabase(db);
                default:
                    throw new NotSupportedException();
            }
        }

        public static sxc.ISqlObjectName QualifiedName<T>(this ISqlProxyBroker broker)
            where T : class, ISqlTabularProxy, new()
        {
            var tabular = broker.Metadata.Tabular<T>();
            return GetDbScopedName(tabular.ProxyKind, tabular.ObjectName, broker.DatabaseName());
        }

        public static Option<int> Save<T>(this ISqlProxyBroker broker, IReadOnlyList<T> data)
           where T : ISqlTabularProxy
               => broker.BulkCopy<T>(data, BatchSize: data.Count, exclusions: rolist<SqlColumnName>());

        public static Option<int> Call<P>(this ISqlProxyBroker Broker, AppMessageObserver Observer)
            where P : class, ISqlProcedureProxy, new()
        {
            try
            {
                var procName = PXM.ProcedureName<P>().OnDatabase(Broker.DatabaseName());
                Observer(Executing(procName));
                var result = Broker.Exec(new P());
                return result.OnNone(m => Observer(m))
                       .OnSome(useless => Observer(Executed(procName)));
            }
            catch(Exception e)
            {
                return none<int>(e);
            }
        }

        public static Option<int> Call<P>(this ISqlProxyBroker Broker, P proc, AppMessageObserver Observer)
            where P : class, ISqlProcedureProxy, new()
        {
            try
            {
                var procName = PXM.ProcedureName<P>().OnDatabase(Broker.DatabaseName());               
                Observer(Executing(procName));
                var result = Broker.Call(proc).ToOption();
                return result.OnNone(m => Observer(m))
                       .OnSome(useless => Observer(Executed(procName)));
            }
            catch(Exception e)
            {
                return none<int>(e);
            }
       }

        /// <summary>
        /// Executes a function within th context of a broker session
        /// </summary>
        /// <typeparam name="T">The function return type</typeparam>
        /// <param name="broker">The facilitating broker</param>
        /// <param name="f">The function to execute</param>
        /// <returns></returns>
        public static Option<T> SessionExec<T>(this ISqlProxyBroker broker, Func<T> f)
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

    }
}
