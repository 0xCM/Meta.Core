//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;

    using System.Threading.Tasks;

    using static metacore;

    /// <summary>
    /// Primary implementation of the <see cref="ISqlClientBroker"/> contract
    /// </summary>
    public class SqlClientBroker : ISqlClientBroker
    {      
        const int DefaultCommandTimeout = 60 * 30;

        static ConcurrentDictionary<SqlSequenceName, ISequenceGenerator> SequenceGenerators
            = new ConcurrentDictionary<SqlSequenceName, ISequenceGenerator>();

        static ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>> TypeCache
            = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>>();

        static readonly Type RTT = typeof(object).GetType();

        public SqlClientBroker(SqlConnectionString ConnectionString, SqlNotificationObserver observer)
        {
            this._ConnectionString = ConnectionString;
            this._Self = this;
            this.PrimaryObserver = m => Relay(m,observer);
            this.SecondaryObservers = new HashSet<Action<SqlNotification>>();
        }

        Action<SqlNotification> PrimaryObserver { get; }

        HashSet<Action<SqlNotification>> SecondaryObservers { get; }

        void Relay(SqlNotification n, SqlNotificationObserver observer)
        {
            observer?.Invoke(n);

            if(SecondaryObservers.Any())
                Task.Factory.StartNew(() 
                    => Try(() =>iter(SecondaryObservers, o => o(n))));            
        }

        public SqlConnectionString ConnectionString
            => _ConnectionString;

        string _ConnectionString { get; }

        ISqlClientBroker _Self { get; }

        protected Dictionary<Type, string> transportProjectorKeys { get; }
            = new Dictionary<Type, string>();

        protected Dictionary<string, Func<object, object>> _Converters { get; }
            = new Dictionary<string, Func<object, object>>();

        protected Dictionary<Type, Type> ToTransportTypeIndex { get; }
            = new Dictionary<Type, Type>();
        protected Dictionary<Type, Type> FromTransportTypeIndex { get; }
            = new Dictionary<Type, Type>();

        Option<SqlBrokerSession> CurrentSession;

        static string CreateConverterKey(SqlConversionDirection kind, Type srcType, Type dstType)
            => kind == SqlConversionDirection.ToTransport
            ? (dstType.Name + " <= " + srcType.Name)
            : (srcType.Name + " => " + dstType.Name);

        static string CreateConverterKey<TSrc, TDst>(SqlConversionDirection direction)
            => CreateConverterKey(direction, typeof(TSrc), typeof(TDst));

        protected static object[] ToTransportArray(IReadOnlyList<Func<object, object>> projectors, object[] itemArray)
        {
            for (int i = 0; i < itemArray.Length; i++)
            {
                if (itemArray[i] != null)
                    itemArray[i] = projectors[i](itemArray[i]);
            }
            return itemArray;
        }

        void ISqlClientBroker.RegisterConverter<TSrc, TDst>(SqlConversionDirection direction, Func<TSrc, TDst> f)
        {
            var key = CreateConverterKey<TSrc, TDst>(direction);
            _Converters.Add(key, src => f((TSrc)src));
            if (direction == SqlConversionDirection.ToTransport)
            {
                AssignTransportProjectorKey(typeof(TSrc), key);
                ToTransportTypeIndex[typeof(TSrc)] = typeof(TDst);
            }
            else if (direction == SqlConversionDirection.ToProxy)
                FromTransportTypeIndex[typeof(TSrc)] = typeof(TDst);
        }

        ISequenceGenerator<T> GetSequenceGenerator<T>(SqlSequenceName SequenceName)
            => (ISequenceGenerator<T>)SequenceGenerators.GetOrAdd(SequenceName,
                    name => SqlSequenceProvider.Get(ConnectionString, name).CreateCachingGenerator<T>());

        protected Func<object, object> GetConverter(string key)
            => _Converters[key];

        protected Func<object, object> GetConverter(SqlConversionDirection direction, Type srcType, Type dstType)
        {

            if (srcType == dstType)
                return x => x;
            else
            {
                var ulDstType = dstType.GetNonNullableType();
                var ulSrcType = srcType.GetNonNullableType();
                if (ulDstType == ulSrcType)
                    return x => x;

                var key = CreateConverterKey(direction, ulSrcType, ulDstType);                
                if (_Converters.TryGetValue(key, out Func<object, object> converter))
                    return converter;
                else
                    return x => Convert.ChangeType(x, dstType);
            }
        }

        protected Func<object, object> GetTransportProjector(Type t)
        {
            var nnType = t.GetNonNullableType();
            Func<object, object> projector = x => x;
            var key = String.Empty;
            if (transportProjectorKeys.TryGetValue(t.GetNonNullableType(), out key))
                projector = GetConverter(key);
            return projector;
        }
       
        protected SqlOutcome<object> SetPropertyValue(PropertyInfo property, object o, object srcValue)
        {
            if (srcValue != null)
            {
                var srcValueType = srcValue.GetType();
                if (srcValueType != typeof(DBNull))
                {
                    try
                    {
                        if (property.PropertyType == typeof(object))
                            property.SetValue(o, srcValue);
                        else if (srcValueType == RTT && property.PropertyType == typeof(Type))
                            property.SetValue(o, srcValue);
                        else if (srcValueType == typeof(string) && property.PropertyType == typeof(string))
                            property.SetValue(o, ((string)srcValue).Trim());
                        else if (srcValueType == property.PropertyType)
                            property.SetValue(o, srcValue);
                        else
                        {
                            var dstType = property.PropertyType;
                            var converter = GetConverter(SqlConversionDirection.ToProxy, srcValueType, property.PropertyType);
                            property.SetValue(o, converter(srcValue));
                        }

                    }
                    catch (Exception e)
                    {
                        return SqlOutcome.Failure<object>(e);
                    }
                }
            }
            return srcValue;
        }

        protected SqlOutcome<object> ConvertFromTransportValue(object srcValue, Type dstType)
        {
            if (srcValue == null)
                return new SqlOutcome<object>(true);

            var srcValueType = srcValue.GetType();
            if (srcValueType != typeof(DBNull))
            {
                try
                {
                    if (dstType == typeof(object))
                        return srcValue;
                    else if (srcValueType == RTT && dstType == typeof(Type))
                        return srcValue;
                    else if (srcValueType == typeof(string) && dstType == typeof(string))
                        return ((string)srcValue).Trim();
                    else if (srcValueType == dstType)
                        return srcValue;
                    else
                    {
                        var converter = GetConverter(SqlConversionDirection.ToProxy, srcValueType, dstType);
                        return converter(srcValue);
                    }
                }
                catch (Exception e)
                {
                    return SqlOutcome.Failure<object>(e);
                }
            }
            return srcValue;
        }

        protected IReadOnlyList<Func<object, object>> GetTransportProjectors(IReadOnlyList<Type> types)
            => types.Select(type => GetTransportProjector(type)).ToList();

        protected void AssignTransportProjectorKey(Type t, string s)
            => transportProjectorKeys.Add(t, s);

        protected object SqlConvert(SqlConversionDirection direction, Type dstType, object src)
        {
            switch (direction)
            {
                case SqlConversionDirection.ToProxy:
                    return
                         src?.GetType() == typeof(DBNull) ? null :
                        (src == null ? null : GetConverter(SqlConversionDirection.ToProxy, src.GetType(), dstType)(src));

                case SqlConversionDirection.ToTransport:
                    var dst = src == null 
                            ? (object)DBNull.Value 
                            : GetConverter(SqlConversionDirection.ToTransport, src.GetType(), dstType)(src);
                    return GetTransportProjector(dstType)(dst);
                default:
                    throw new NotSupportedException();
            }
        }

        protected TDst ScalarConverter<TDst>(object src)
            => (TDst)SqlConvert(SqlConversionDirection.ToProxy, typeof(TDst), src);

        protected object ScalarConverter(Type t , object src)
            => SqlConvert(SqlConversionDirection.ToProxy, t, src);

        SqlConnectionCommand CreateScalarScriptCommand(string sql, IEnumerable<(string,object)> arguments)
            => CreateCommand(sql, false).WithArguments(arguments);

        SqlConnection CreateObservedConnection(SqlNotificationObserver Observe)        
            => CurrentSession.Map(x => x.SessionConnection,
                                    () => {
                                        var c = new SqlConnection(_ConnectionString);
                                        Observe?.Relay(c);
                                        c.Open();
                                        return c;
                                    });
        
        protected SqlConnectionCommand CreateScriptCommand(SqlScript Script, SqlNotificationObserver Observer, int? timeout = null)
        {
            try
            {
                var connection = CreateObservedConnection(Observer);
                var command = new SqlCommand(Script, connection)
                {
                    CommandTimeout = timeout ?? DefaultCommandTimeout,
                    CommandType = CommandType.Text
                };
                return new SqlConnectionCommand(connection, command, CurrentSession.IsNone(), Observer);
            }
            catch (Exception e)
            {
                var message = $"Could not create command for connection '{_ConnectionString}': {e.Message}";
                throw new Exception(message, e);
            }
        }

        SqlConnection OpenSqlConnection(SqlNotificationObserver Observer = null)
        {
            var c = new SqlConnection(_ConnectionString);
            if (Observer != null)
                Observer.Relay(c);
            else
                PrimaryObserver?.Observe(c);
            c.Open();
            return c;
        }

        SqlCommand CreateSqlCommand(SqlConnection connection, string sql, bool sp)
            => new SqlCommand(sql, connection)
            {
                CommandTimeout = DefaultCommandTimeout,
                CommandType = sp ? CommandType.StoredProcedure : CommandType.Text
            };

        protected internal SqlConnectionCommand CreateCommand(string sql, bool sp = false)
        {
            try
            {
                var connection = CurrentSession.Map(x => x.SessionConnection, 
                        () => {
                            var c = new SqlConnection(_ConnectionString);
                            PrimaryObserver?.Observe(c);
                            c.Open();
                            return c;
                        });

                var command = CreateSqlCommand(connection, sql, sp);
                return new SqlConnectionCommand(connection, command, CurrentSession.IsNone(), PrimaryObserver);
            }
            catch(Exception e)
            {
                var message = $"Could not create command for connection '{_ConnectionString}': {e.Message}";
                throw new Exception(message, e);
            }
        }

        protected string FormatFunctionCall(SqlFunctionName function, IEnumerable<(string, object)> arguments)
        {
            var pNames = string.Join(",", arguments.Select(p => p.Item1));
            var fName = String.IsNullOrWhiteSpace(function.SchemaNamePart) ? function.UnqualifiedName : function.SchemaQualifiedName;
            var sql = $"{fName}({pNames})";
            return sql;
        }

        protected internal SqlConnectionCommand CreateProcedureCommand(SqlProcedureName procedure)
            => CreateCommand(procedure.FullName, true);

        SqlConnectionCommand CreateScalarCommand(SqlFunctionName function, IEnumerable<(string, object)> arguments)
            => CreateCommand($"select {FormatFunctionCall(function, arguments)}", false).WithArguments(arguments);


        protected internal SqlConnectionCommand CreateProcedureCommand(SqlProcedureName proc, IEnumerable<(string, object)> arguments)
            => CreateCommand(proc.FullName, true).WithArguments(arguments);

        Option<int> ISqlClientBroker.ExecuteProcedure(SqlProcedureName procedure, params (string, object)[] arguments)
            => Use(CreateProcedureCommand(procedure, arguments), cmd => cmd.ExecuteNonQuery());

        SqlDataFrame Select(SqlConnectionCommand command)
        {
            using (var reader = command.ExecuteReader())
                return new SqlDataFrame(reader.IdentifyColumns(), new List<object[]>(reader.ReadToEnd()));
        }

        Option<SqlDataFrame> ISqlClientBroker.Select(string sql)
            => Use(CreateCommand(sql), Select);

        protected static N GetObjectName<N>(N ObjectName, SqlDatabaseName db)
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

        IReadOnlyDictionary<string, PropertyInfo> DescribeProperties<T>()
            where T : new()
            => dict(from p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                    where p.GetSetMethod() != null
                    select (p.Name, p));
                    
        SqlOutcome<T> HydrateType<T>
        (
            IReadOnlyDictionary<string,PropertyInfo> props, 
            IReadOnlyList<SqlColumnIdentifier> columns, 
            object[] itemArray
        ) where T : new()
        {
            try
            {
                var record = new T();
                for (var i = 0; i < itemArray.Length; i++)
                {
                    var col = columns[i];
                    if(props.TryGetValue(columns[i].ColumnName, out PropertyInfo prop))
                    {
                        var value = itemArray[i];
                        var success = ConvertFromTransportValue(value, prop.PropertyType)
                            .OnSuccess(v => SetPropertyValue(prop, record, v).Require());
                        if (!success)
                            return success.Failure<T>();
                    }
                }
                return record;
            }
            catch (Exception e)
            {
                return new SqlOutcome<T>(e);
            }
        }

       Option<IReadOnlyList<T>> HydrateTypes<T>(SqlDataFrame frame)
            where T : new()
        {
            var records = new List<T>();
            var props = TypeCache.GetOrAdd(typeof(T), _ => DescribeProperties<T>());

            foreach (var itemArray in frame.Rows)
            {
                var outcome = HydrateType<T>(props, frame.Columns, itemArray).OnSuccess(record => records.Add(record));
                if (outcome.Failed)
                    return outcome.Failure<IReadOnlyList<T>>();                
            }
            return records;
        }

        Option<IReadOnlyList<T>> ISqlClientBroker.Select<T>(string sql)
            => from frame in SqlOutcome.Use(CreateCommand(sql), Select).ToOption()
               from records in HydrateTypes<T>(frame)
               select records;

        public Option<int> ExecuteNonQuery(SqlScript Script, SqlNotificationObserver Observer, int? Timeout = null)        
            => SqlOption.Use(Script, CreateScriptCommand(Script,Observer), command => command.ExecuteNonQuery());
        
        SqlOutcome<int> ISqlClientBroker.ExecuteNonQuery(string sql)
            => SqlOutcome.Use(sql, CreateCommand(sql), command => command.ExecuteNonQuery());

        public Task<Option<int>> ExecuteNonQueryAsync(string sql, SqlNotificationObserver Observer)        
            => task(() =>
            {
                try
                {
                    var connection = OpenSqlConnection(Observer);
                    using (var command = new SqlConnectionCommand(connection, CreateSqlCommand(connection, sql, false), true, Observer))
                        return command.ExecuteNonQuery();                 
                }
                catch (Exception e)
                {
                    return none<int>(e);
                }
            });
        

        public ScalarResult<T> ExecuteScalarScript<T>(string sql, params (string, object)[] arguments)
        {
            try
            {
                using (var command = CreateScalarScriptCommand(sql, arguments))
                    return command.GetScalar(o => ScalarConverter<T>(o));
            }
            catch(Exception e)
            {
                return new ScalarResult<T>(false, none<T>(e));
            }
        }



        SqlOutcome<object> ISqlClientBroker.ExecuteScalarScript(string sql)        
            => SqlOutcome.Use(sql, CreateScalarScriptCommand(sql, new (string, object)[] { }), cmd => cmd.ExecuteScalar());
        
        ScalarResult<object> ISqlClientBroker.ExecuteScalarFunction(SqlFunctionName function, params object[] arguments)
        {
            try
            {
                var _arguments = mapi(arguments, (i, o) => ($"@Arg{i}", o)).ToArray();
                using (var command = CreateScalarCommand(function, _arguments))
                    return command.GetScalar(x => x);
            }
            catch (Exception e)
            {
                return new ScalarResult<object>(false, none<object>(e));
            }

        }
        ScalarResult<T> ISqlClientBroker.ExecuteScalarFunction<T>(SqlFunctionName function, params (string,object)[] arguments)
        {
            try
            {               
                using (var command = CreateScalarCommand(function, arguments))
                    return command.GetScalar(o => ScalarConverter<T>(o));
            }
            catch (Exception e)
            {
                return new ScalarResult<T>(false, none<T>(e));
            }
        }

        ScalarResult<T> ISqlClientBroker.ExecuteScalarFunction<T>(SqlFunctionName function, params object[] arguments)
        {
            try
            {
                var _arguments = mapi(arguments, (i, o) => ($"@Arg{i}", o)).ToArray();
                using (var command = CreateScalarCommand(function, _arguments))
                    return command.GetScalar(o => ScalarConverter<T>(o));
            }
            catch(Exception e)
            {
                return new ScalarResult<T>(false, none<T>(e));
            }
        }

        SqlOutcome<ISqlBrokerSession> ISqlClientBroker.CreateSession() 
            => CurrentSession.IsSome() 
            ? SqlOutcome.Failure<ISqlBrokerSession>("Session already in progress") 
            : new SqlBrokerSession(this, _ => CurrentSession = null, PrimaryObserver);

        public SqlOutcome<T> NextSequenceValue<T>(SqlSequenceName sequence)
            => GetSequenceGenerator<T>(sequence).NextValue();

        public Option<IReadOnlyList<T>> NextSequenceValues<T>(SqlSequenceName sequence, int count)
            => some(GetSequenceGenerator<T>(sequence).NextRange(count).ToReadOnlyList());

        public void Observe(Action<SqlNotification> observer)
            => SecondaryObservers.Add(observer);
    }
}
