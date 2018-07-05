//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using System.Collections.Concurrent;

    using Meta.Core;

    using static metacore;
    using static SqlStatusMessages;

    using sxc = SqlT.Syntax.contracts;
    using SqlClientParameter = System.Data.SqlClient.SqlParameter;

    public partial class SqlProxyBroker : SqlClientBroker, ISqlProxyBroker
    {

        public SqlProxyBroker(ISqlProxyMetadataIndex Metadata, SqlConnectionString cs, SqlNotificationObserver Observer = null)
            : base(cs, Observer)
        {
            this.Metadata = Metadata;
            this.Self = this;
            this.Observer = Observer ?? (message => Console.Write(message));
        }

        ISqlProxyMetadataIndex Metadata { get; }

        ISqlProxyBroker Self { get; }

        SqlNotificationObserver Observer { get; }

        SqlProcedureName ProcName<P>()
                => Metadata.Describe<SqlProcedureProxyInfo>(typeof(P)).ObjectName;

        SqlProcedureName ProcName(Type ProcType)
                => PXM.Procedure(ProcType).ObjectName;

        static ConcurrentDictionary<Assembly, SqlOutcome<ISqlProxyBrokerFactory>> BrokerFactories
            = new ConcurrentDictionary<Assembly, SqlOutcome<ISqlProxyBrokerFactory>>();

        static SqlOutcome<ISqlProxyBrokerFactory> CreateBrokerFactory(Assembly Host)
            => GetFactoryType(Host).Evaluate(
                    factoryType => (ISqlProxyBrokerFactory)Activator.CreateInstance(factoryType));

        public static SqlOutcome<ISqlProxyBrokerFactory> GetBrokerFactory(Assembly Host)
            => BrokerFactories.GetOrAdd(Host, h => CreateBrokerFactory(h));

        public static Option<ISqlProxyBrokerFactory<A>> AssemblyBrokerFactory<A>()
            where A : class, ISqlProxyAssembly, new()
            => from f in BrokerFactories.GetOrAdd(typeof(A).Assembly, h => CreateBrokerFactory(h))
               let af = (ISqlProxyBrokerFactory<A>)f
               select af;
              
        public static SqlOutcome<ISqlProxyBrokerFactory> GetBrokerFactory(Type ProxyRepresentative)
                => GetBrokerFactory(ProxyRepresentative.Assembly);

        public static SqlOutcome<ISqlProxyBrokerFactory> GetBrokerFactory<T>()
            where T : ISqlProxy
                => GetBrokerFactory(typeof(T));

        public static SqlOutcome<ISqlProxyBroker> CreateBroker(Assembly Host, SqlConnectionString cs)
            => GetBrokerFactory(Host).Evaluate(f => f.CreateBroker(cs));

        public static SqlOutcome<ISqlProxyBroker> CreateBroker<T>(SqlConnectionString cs)
            where T : ISqlProxy
                => GetBrokerFactory<T>().Evaluate(f => f.CreateBroker(cs));

        static SqlOutcome<Type> GetFactoryType(Assembly host)
        {
            var factoryTypes = host.GetTypes().Where(x => Attribute.IsDefined(x, typeof(SqlProxyBrokerFactoryAttribute)));
            var factoryCount = factoryTypes.Count();
            if (factoryCount != 1)
            {
                var message = factoryCount == 0
                            ? NoBrokerFactoriesExist(host)
                            : TooManyBrokerFactories(host);
                return SqlOutcome.Failure<Type>(new SqlMessage(message));
            }
            return factoryTypes.Single();
        }

        internal ISqlProxyMetadataIndex MetadataIndex 
            => Metadata;

        IReadOnlyList<Func<object, object>> GetTransportProjectors(SqlTabularProxyInfo tabular, IReadOnlyList<int> skips = null)
        {
            var types = MutableList.Create<Type>();
            foreach (var c in tabular.Columns)
            {
                if (skips != null)
                {
                    if (!skips.Contains(c.Position))
                        types.Add(c.RuntimeType);                        
                }
                else
                    types.Add(c.RuntimeType);
            }
            return base.GetTransportProjectors(types);
        }
       
        Option<bool> HydrateProxy(ISqlTabularProxy proxy, IReadOnlyList<SqlColumnProxyInfo> columns,  object[] src)
        {
            var count = columns.Count;
            for (int i = 0; i < count; i++)
            {
                var property = (PropertyInfo)columns[i].ClrElement;
                var result = SetPropertyValue(property, proxy, src[i]);
                if (result.Failed)
                {
                    var description
                        = error($"Error occurred when attempting to assign the value {src[i]} to the property {property.Name} on a {proxy.GetType()} proxy: { result.Messages.Render()}");
                    return none<bool>(description);
                }
            }
            return true;
        }

        Option<C> ReadProxyColumn<T,C>(SqlDataReader reader, SqlColumnProxyInfo column)
        {
            var srcValue = reader.GetValueArray()[0];
            var property = (PropertyInfo)column.ClrElement;
            var dstValue = ConvertFromTransportValue(srcValue, property.PropertyType);
            if (dstValue.Succeeded)
            {
                var value = dstValue.Payload;
                if (value != null && value.GetType() != typeof(DBNull))
                    return (C)dstValue.Payload;
                else
                    return default(C);
            }                
            else
                return none<C>(dstValue.Message.ToApplicationMessage());
        }

        public Option<T> ReadProxy<T>(SqlDataReader reader, Type proxyType)
        {
            var proxy = (ISqlTabularProxy)Activator.CreateInstance(proxyType);
            var columns = Metadata.DescribeColumns(proxyType);
            var src = reader.GetValueArray();
            return HydrateProxy(proxy, columns, src).Map(x => (T)proxy);
        }

        public Option<T> ReadProxy<T>(object[] src) where T : class, ISqlTabularProxy, new()
        {
            var proxy = new T();
            var columns = Metadata.Columns<T>();
            return HydrateProxy(proxy, columns, src).Map(x => proxy);
        }
        
        DataTable DefineTransportTable(SqlTabularProxyInfo info, IReadOnlySet<string> exclusions)
        {
            var table = new DataTable(info.FullName);
            foreach (var column in info.Columns)
            {
                if (exclusions.Contains(column.ColumnName))
                    continue;

                var proxyDataType = column.RuntimeType.GetUnderlyingType();
                var transDataType
                    = ToTransportTypeIndex.ContainsKey(proxyDataType)
                    ? ToTransportTypeIndex[proxyDataType]
                    : proxyDataType;
                table.Columns.Add(new DataColumn(column.ColumnName, transDataType));
            }
            return table;
        }

        SqlClientParameter CreateClientParameter(SqlParameterProxyInfo info, object runtimeValue)
        {
            if (runtimeValue == null)
                return new SqlClientParameter(info.ParameterName, DBNull.Value);

            if (info.IsStructured)
            {
                var runtimeType = runtimeValue.GetType();
                var recordType = runtimeType.IsArray ? runtimeType.GetElementType() : runtimeType.GetGenericArguments()[0];
                var recordInfo = Metadata.Describe<SqlTableTypeProxyInfo>(recordType);
                var dataTable = DefineTransportTable(recordInfo, roset<string>());
                var projectors = GetTransportProjectors(recordInfo);
                foreach (ISqlTableTypeProxy recordProxy in (runtimeValue as IEnumerable))
                {
                    if (isNull(recordProxy))
                        throw new ArgumentException(NullTableTypeProxy(info.ParameterName).Format(false));
                    var transportArray = ToTransportArray(projectors, recordProxy.GetItemArray());
                    dataTable.LoadDataRow(transportArray, true);
                }

                return new SqlClientParameter()
                {
                    ParameterName = info.ParameterName,
                    Value = dataTable,
                    SqlDbType = SqlDbType.Structured,
                    TypeName = recordInfo.FullName
                };
            }
            else
            {
                var transportValue = SqlConvert(SqlConversionDirection.ToTransport, info.RuntimeType, runtimeValue);
                return new SqlClientParameter(info.ParameterName, transportValue);
            }
        }

        IEnumerable<SqlClientParameter> CreateClientParameters<R>(SqlRoutineProxyInfo info, R routine)
            where R : ISqlObjectProxy
        {
            var arguments = routine.GetItemArray();
            var parameters = info.Parameters;
            for (int i = 0; i < parameters.Count; i++)
                yield return CreateClientParameter(parameters[i], arguments[i]);
        }

        sxc.ISqlObjectName QualifiedName(Type ProxyType)
        {
            var server = ConnectionString.ServerName;
            if (server.IsLocalHost)
                server = Environment.MachineName;
                
            var db = new SqlDatabaseName(server, ConnectionString.DatabaseName);
            var obj = PXM.Tabular(ProxyType).ObjectName;
            return new SqlObjectName(server, ConnectionString.DatabaseName, obj.SchemaNamePart, obj.UnqualifiedName);
        }

        sxc.ISqlObjectName QualifiedName<T>()
            where T : class, ISqlTabularProxy, new()
            => QualifiedName(typeof(T));

        sxc.ISqlObjectName ScopeNameToDatabase(Type ProxyType, SqlDatabaseName DbName)
        {
            var description = Metadata.Describe<SqlObjectProxyInfo>(ProxyType);
            return description.ProxyKind.GetDbScopedName(description.ObjectName,
                ifNull(DbName, () => new SqlDatabaseName(ConnectionString.DatabaseName)));
        }

        static string Format(IEnumerable<SqlColumnName> columns)
            => string.Join(",", columns.Select(c => $"[{c.UnquotedLocalName}]"));

        sxc.ISqlObjectName ScopeNameToDatabase<T>(SqlDatabaseName DbName)
            where T : class, ISqlTabularProxy, new()
            => ScopeNameToDatabase(typeof(T), DbName);

        string BuildSelect(Type ProxyType)
                => concat("select ", 
                    Format(PXM.ColumnNames(ProxyType)), 
                    " from ", QualifiedName(ProxyType).Format(true));

        string BuildSelect(Type ProxyType, SqlDatabaseName DbName)
                => concat("select ",
                    Format(PXM.ColumnNames(ProxyType)),
                    " from ", ScopeNameToDatabase(ProxyType, DbName).Format(true));

        string BuildSelect(Type ProxyType, ISqlFilter Filter)
            => concat(BuildSelect(ProxyType), " where ", Filter.FormatSyntax());

        string BuildSelect<T>(ISqlFilter<T> Filter)
            where T : class, ISqlTabularProxy, new()
            => BuildSelect(typeof(T), Filter);

        string BuildSelect<T>(IEnumerable<SqlColumnName> columns)
            where T : class, ISqlTabularProxy, new()
                => concat("select ", 
                    Format(columns), 
                    " from ", QualifiedName<T>().Format(true));

        string BuildSelect<T>(IEnumerable<SqlColumnName> columns, SqlDatabaseName DbName)
            where T : class, ISqlTabularProxy, new()
                => concat("select ",
                    Format(columns),
                    " from ", ScopeNameToDatabase<T>(DbName).Format(true));

        string BuildSelect<T>(SqlDatabaseName DbName)
            where T : class, ISqlTabularProxy, new()
                => BuildSelect<T>(PXM.ColumnNames<T>(),DbName);

        string BuildSelect<T>()
            where T : class, ISqlTabularProxy, new()
                => BuildSelect<T>(PXM.ColumnNames<T>());

        internal SqlConnectionCommand CreateFunctionCommand(SqlFunctionProxyInfo description, SqlDatabaseName db, params object[] arguments)
        {
            var parameters = description.Parameters;
            var functionName = GetObjectName(description.ObjectName, db);
            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));
            var sql = $"select * from {functionName}({parameterNames})";
            var command = CreateCommand(sql);
            for (int i = 0; i < parameters.Count; i++)
                command.Parameters.Add(CreateClientParameter(parameters[i], arguments[i]));
            return command;
        }

        public SqlConnectionCommand CreateFunctionCommand(SqlFunctionName FunctionName, SqlDatabaseName db, params object[] arguments)
        {
            var description = Metadata.Describe<SqlTableFunctionProxyInfo>(new SqlObjectName(FunctionName)).Single();
            return CreateFunctionCommand(description, db, arguments);
        }

        SqlConnectionCommand FunctionCommand<F>(F func, SqlDatabaseName db = null) 
            where F : ISqlObjectProxy
        {
            var description = Metadata.Describe<SqlTableFunctionProxyInfo>(func.GetType());
            var parameters = description.Parameters;
            var functionName = GetObjectName(description.ObjectName, db);
            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));
            var sql = $"select * from {functionName}({parameterNames})";
            var command = CreateCommand(sql);
            command.Parameters.AddRange(CreateClientParameters(description, func).ToArray());
            return command;
        }

        Option<SqlConnectionCommand> ProcedureCommand<P>(P proc, SqlDatabaseName db)
            where P : ISqlProcedureProxy
                => CreateCommand(proc, db);

        IEnumerable<T> Stream<T>(string sql) 
            where T : class, ISqlTabularProxy, new()
        {
            using (var command = CreateCommand(sql))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        var values = reader.GetValueArray();
                        var proxy = ReadProxy<T>(values);
                        if (proxy.IsNone())                        
                            throw new Exception(proxy.Message.Format(false));
                        
                        yield return proxy.ValueOrDefault();
                    }
        }

        public IEnumerable<T> Stream<T>() 
            where T : class, ISqlTabularProxy, new()
                => Stream<T>(BuildSelect<T>());

        IEnumerable<TResult> Stream<F, TResult>(F func, SqlDatabaseName db) 
            where F : ISqlObjectProxy where TResult: class, ISqlTabularProxy, new()
        {
            using (var command = FunctionCommand(func, db))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        var values = reader.GetValueArray();
                        var proxy = ReadProxy<TResult>(values);
                        if (proxy.IsNone())
                        {
                            throw new Exception(proxy.Message.Format(false));
                        }
                        yield return proxy.ValueOrDefault();
                    }
        }

        IEnumerable<TResult> ISqlProxyBroker.Stream<TResult>(ISqlFilter<TResult> Filter)
            => Stream<TResult>(typeof(TResult), BuildSelect(Filter));

        IEnumerable<TResult> Stream<TResult>(Type proxyType, string sql)
        {
            using (var command = CreateCommand(sql))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while(reader.Read())
                    {
                        var proxy = ReadProxy<TResult>(reader, proxyType);
                        if (proxy.IsNone())
                        {
                            throw new Exception(proxy.Message.Format(false));
                        }
                        yield return proxy.ValueOrDefault();
                    }
        }

        IEnumerable<TResult> ISqlProxyBroker.Stream<F, TResult>(F func, SqlDatabaseName db)
            => Stream<F, TResult>(func, db);

        IEnumerable<TResult> ISqlProxyBroker.Stream<TResult>(string sql)
            => Self.Stream<TResult>(sql);

        SqlOutcome<int> ISqlProxyBroker.Stream<TResult>(string sql, Action<TResult> receiver)
            => SqlOutcome.Try(() =>
            {

                var i = 0;
                foreach (var item in Self.Stream<TResult>(sql))
                {
                    receiver(item);
                    i++;
                }
                return i;
            });

        SqlOutcome<int> ISqlProxyBroker.Stream<F, TResult>(F func, Action<TResult> receiver)
            => SqlOutcome.Try(() =>
            {
                var i = 0;
                foreach (var item in Self.Stream<F, TResult>(func))
                {
                    receiver(item);
                    i++;
                }
                return i;
            });

        public IEnumerable<C> StreamColumn<T, C>(string sql, Expression<Func<T, C>> c)
            where T : class, ISqlTabularProxy, new()
        {
            var tabular = Self.Metadata.Tabular<T>();
            var column = Self.Metadata.Column<T>(c.GetMember().Name);
            using (var command = CreateCommand(sql))
            using (var reader = command.ExecuteReader())
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        var proxy = ReadProxyColumn<T, C>(reader, column);
                        if (proxy.IsNone())
                        {
                            throw new Exception(proxy.Message.Format(false));
                        }
                        yield return proxy.ValueOrDefault();
                    }
        }

        Option<IReadOnlyList<C>> ISqlProxyBroker.GetColumn<T, C>(string sql, Expression <Func<T, C>> c)
            => StreamColumn(sql, c).ToList();

        Option<IReadOnlyList<TResult>> ISqlProxyBroker.Get<F, TResult>(SqlTableFunctionProxy<F, TResult> func, SqlDatabaseName db)
            => Try(() => Stream<SqlTableFunctionProxy<F, TResult>, TResult>(func, db).ToReadOnlyList() as IReadOnlyList<TResult>);

        Option<IReadOnlyList<TResult>> ISqlProxyBroker.Select<F, TResult>(SqlTableFunctionProxy<F, TResult> func)
            => Try(() => Stream<SqlTableFunctionProxy<F, TResult>, TResult>(func, null).ToReadOnlyList() as IReadOnlyList<TResult>);

        SqlOutcome<IReadOnlyList<T>> ISqlProxyBroker.Get<T>(string sql)
            => Stream<T>(ifBlank(sql, BuildSelect<T>())).ToList();

        SqlOutcome<IReadOnlyList<T>> ISqlProxyBroker.Get<T>(Type proxyType, SqlDatabaseName db)
            => Stream<T>(proxyType, BuildSelect(proxyType,db)).ToList();

        Option<IReadOnlyList<T>> ISqlProxyBroker.Get<T>(SqlDatabaseName db)
            => Stream<T>(BuildSelect<T>(db)).ToList();

        SqlOutcome<IReadOnlyList<TResult>> ISqlProxyBroker.Get<P, TResult>(SqlProcedureProxy<P, TResult> proc, SqlDatabaseName db)
        {
            var records = MutableList.Create<TResult>();
            try
            {
                var _command = ProcedureCommand(proc, db);
                if (!_command)
                    return SqlOutcome.Failure<IReadOnlyList<TResult>>(_command.Message);

                using (var command = _command.Require())
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                var proxy = ReadProxy<TResult>(reader.GetValueArray());
                                if (proxy.IsNone())
                                    throw new Exception($"Execution of the procedure proxy {proc} failed: {proxy.Message.Format(false)}");
                                records.Add(proxy.ValueOrDefault());
                            }
                    }
                }
            }
            catch (Exception e)
            {                
                return SqlOutcome.Failure<IReadOnlyList<TResult>>(e);
            }
            return SqlOutcome.Success(records.ToReadOnlyList() as IReadOnlyList<TResult>);
        }

        SqlOutcome<int> ISqlProxyBroker.Call<P>(SqlProcedureProxy<P> proc, SqlDatabaseName db)
        {
            try
            {
                var _command = ProcedureCommand(proc, db);
                if (!_command)
                    return SqlOutcome.Failure<int>(_command.Message);

                using (var cmd = _command.Require())
                    return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return SqlOutcome<int>.Fail(error($"Call to {ProcName<P>()} failed: {e}"));
            }
        }

        SqlOutcome<int> ISqlProxyBroker.Call<P>(P proc, SqlDatabaseName db)
        {
            try
            {
                var _command = ProcedureCommand(proc, db);
                if (!_command)
                    return SqlOutcome.Failure<int>(_command.Message);

                using (var cmd = _command.Require())
                    return cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return SqlOutcome<int>.Fail(error($"Call to {ProcName<P>()} failed: {e}"));
            }
        }

        static object locker = new object();

        Option<int> ISqlProxyBroker.Call<P>(P proc, bool @lock)
        {
            try
            {
                var description = Metadata.Describe<SqlProcedureProxyInfo>(proc.GetType());
                var procName = description.ObjectName;
                lock (locker)
                {
                    using(var command = CreateProcedureCommand(procName))
                    {
                        command.Parameters.AddRange(CreateClientParameters(description, proc).ToArray());
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return none<int>(error($"Call to {ProcName<P>()} failed: {e}"));
            }
        }

        IReadOnlyList<TDst> ReadProxies<TDst>(DataTable src)
            where TDst : class, ISqlTabularProxy, new()
        {
            var description = Metadata.Describe<TDst, SqlTabularProxyInfo>();
            var proxies = MutableList.Create<TDst>();
            var itemArrays = src.Rows.Cast<DataRow>().Select(x => x.ItemArray).ToList();
            foreach (var itemArray in itemArrays)
            {
                var dst = new TDst();
                var result = 
                    HydrateProxy(dst, description.Columns, itemArray).OnSome(_ => proxies.Add(dst));
                if (result.IsNone())
                    throw new Exception(result.Message.Format(false));
            }
            return proxies;
        }

        static object[] PruneArray(object[] src, IReadOnlyList<int> exclusions)
        {
            var dst = new object[src.Length - exclusions.Count];
            var j = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (!exclusions.Contains(i))
                    dst[j++] = src[i];
            }
            return dst;
        }

        DataTable FillDataTable(Type proxyType, IEnumerable<object[]> itemArrays, params string[] exclusions)
        {
            var info = Metadata.Describe<SqlTabularProxyInfo>(proxyType);
            var exclusionSet = new HashSet<string>(exclusions);
            var table = DefineTransportTable(info, exclusionSet.ToReadOnlySet());
            var skipPositions = info.Columns.Where(c => exclusionSet.Contains(c.ColumnName)).Select(x => x.Position).ToList();
            var projectors = GetTransportProjectors(info, skipPositions);

            foreach (var itemArray in itemArrays)
            {
                var pruned = PruneArray(itemArray, skipPositions);
                var array = ToTransportArray(projectors, pruned);
                table.LoadDataRow(array, true);
            }

            return table;
        }

        object[] ToPrunedTransportArray(object[] items, IReadOnlyList<Func<object,object>> projectors, IReadOnlyList<int> skip)
            => ToTransportArray(projectors, PruneArray(items, skip));

        CommonDataReader CreateDataReader(Type proxyType, IEnumerable<ISqlTabularProxy> src, IReadOnlyList<string> exclusions)
        {
            var tabular = Metadata.Tabular(proxyType);
            var skip = MutableList.Create<int>();
            var columns = MutableList.Create<SqlColumnIdentifier>();
            foreach (var col in tabular.Columns)
            {
                if (exclusions.Contains(col.ColumnName.UnqualifiedName))
                    skip.Add(col.Position);
                else
                    columns.Add(new SqlColumnIdentifier(col.ColumnName, col.Position - skip.Count));
            }

            var projectors = GetTransportProjectors(tabular, skip);
            return new CommonDataReader(src.Select(item => ToPrunedTransportArray(item.GetItemArray(), projectors, skip)), columns);
        }

        SqlCopyOptions EffectiveOptions(SqlCopyOptions options)
            => options ?? SqlCopyOptions.Create(ConnectionString);

        int BulkCopy(SqlBulkCopy bcp, Type proxyType, IEnumerable<object[]> itemArrays, SqlCopyOptions options, Action<int> observer)
        {
            options = options ?? SqlCopyOptions.Create(ConnectionString);
            var table = FillDataTable(proxyType, itemArrays, options.ExcludedColumns.ToArray());
            options.TargetTableName.OnNone(() => bcp.DestinationTableName = SqlObjectName.Parse(table.TableName));
           
            foreach (DataColumn col in table.Columns)
                bcp.ColumnMappings.Add(col.ColumnName, col.ColumnName);

            bcp.WriteToServer(table);
            return table.Rows.Count;
        }

        int BulkCopy(SqlBulkCopy bcp, Type proxyType, IEnumerable<ISqlTabularProxy> items, SqlCopyOptions options, Action<int> observer)
            => BulkCopy(bcp, proxyType, items.Select(x => x.GetItemArray()), EffectiveOptions(options), observer);

        Option<int> ISqlProxyBroker.BulkCopy(Type proxyType, IEnumerable<ISqlTabularProxy> items, SqlCopyOptions options, Action<int> observer)
            => Use(SqlCopier.CreateSqlCopier(EffectiveOptions(options), observer), 
                    bcp => BulkCopy(bcp, proxyType, items, EffectiveOptions(options), observer));

        Option<int> ISqlProxyBroker.BulkCopy(Type proxyType, IEnumerable<object[]> itemArrays, SqlCopyOptions options, Action<int> observer)
            => Use(SqlCopier.CreateSqlCopier(EffectiveOptions(options), observer), 
                    bcp => BulkCopy(bcp, proxyType, itemArrays, EffectiveOptions(options), observer));

        Option<int> ISqlProxyBroker.BulkCopy<T>(IEnumerable<T> items, SqlCopyOptions options, Action<int> observer)
            => Use(SqlCopier.CreateSqlCopier(EffectiveOptions(options), observer), 
                    bcp => BulkCopy(bcp, typeof(T), items, EffectiveOptions(options), observer));

        Option<int> ISqlProxyBroker.Save<T>(IEnumerable<T> src, SqlSaveOptions options, Action<long> observer)
        {
            var flags = SqlBulkCopyOptions.KeepNulls;
            flags |= SqlBulkCopyOptions.TableLock;
            flags |= SqlBulkCopyOptions.UseInternalTransaction;
            var batchSize = options?.BatchSize ?? 5000;
            var timeout = options?.Timeout ?? 60;
            var proxyType = typeof(T);

            void OnRowsCopied(object sender, SqlRowsCopiedEventArgs e)
                => observer(e.RowsCopied);

            using (var reader = CreateDataReader(proxyType, src, new string[] { }))
            using (var bcp = new SqlBulkCopy(ConnectionString, flags))
            {
                foreach (var col in reader.Columns)
                    bcp.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                if(observer != null)
                {
                    bcp.NotifyAfter = batchSize;
                    bcp.SqlRowsCopied += OnRowsCopied;
                }
                bcp.BatchSize = batchSize;
                bcp.BulkCopyTimeout = timeout;
                bcp.DestinationTableName = Metadata.Tabular(proxyType).FullName;
                bcp.WriteToServer(reader);
                return bcp.RowsCopied();
            }
        }

        object bulkLocker = new object();

        public Option<int> BulkCopy(Type proxyType, IEnumerable<ISqlTabularProxy> src, int BatchSize, IReadOnlyList<string> exclusions, 
            int? Timeout = null, bool? LockTable = null, bool? Transactional = null)
        {
            var lockTable = LockTable ?? true;
            var transactional = Transactional ?? true;
            var flags = SqlBulkCopyOptions.KeepNulls;
            if (lockTable)
                flags |= SqlBulkCopyOptions.TableLock;
            if (transactional)
                flags |= SqlBulkCopyOptions.UseInternalTransaction;

                using (var reader = CreateDataReader(proxyType, src, exclusions ?? new string[] { }))
                using (var bcp = new SqlBulkCopy(ConnectionString, flags))
                {
                    foreach (var col in reader.Columns)
                        bcp.ColumnMappings.Add(col.ColumnName, col.ColumnName);

                    bcp.BatchSize = BatchSize;
                    bcp.BulkCopyTimeout = Timeout ?? 60;
                    bcp.DestinationTableName = Metadata.Tabular(proxyType).FullName;
                    bcp.WriteToServer(reader);
                    return bcp.RowsCopied();
                }
        }

        Option<int> ISqlProxyBroker.Save<T>(IReadOnlyList<T> items)
            => BulkCopy(typeof(T),
                items,
                items.Count,
                new string[] { }
                );

        public Option<int> BulkCopy<T>(IEnumerable<T> src, int BatchSize, IReadOnlyList<SqlColumnName> exclusions,
            int? Timeout = null, bool? LockTable = null, bool? Transactional = null) 
                where T : ISqlTabularProxy
                    => BulkCopy(typeof(T), 
                        src.Cast<ISqlTabularProxy>(), 
                        BatchSize, 
                        map(exclusions, x => x.ToString()), 
                        Timeout, 
                        LockTable, 
                        Transactional
                        );

        ISqlProxyMetadataIndex ISqlProxyBroker.Metadata
            => Metadata;

        Option<T> ISqlProxyBroker.Operations<T>()
            => Metadata.FindOperationProvider<T>()
                       .Map(t => (T)Activator.CreateInstance(t, Self), 
                            () => none<T>(error($"Provider for {typeof(T).Name} could not be found")));

        public Option<IReadOnlyList<SqlSchemaTableRow>> GetProcedureResultSchema(SqlProcedureName proc, params (string, object)[] arguments)
            => Use(CreateProcedureCommand(proc, arguments),
                    c => ReadProxies<SqlSchemaTableRow>(c.GetSchemaTable()));

        public Option<IReadOnlyList<SqlSchemaTableRow>> GetScriptResultSchema(string sql)
            => Use(CreateCommand(sql),
                c => ReadProxies<SqlSchemaTableRow>(c.GetSchemaTable()));

        public IEnumerable<TDst> Stream<TSrc, TDst>(string sql)
            where TSrc : class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new()
            => stream<TDst>();

        public IEnumerable<TDst> Stream<TSrc, TDst>()
            where TSrc : class, ISqlTabularProxy, new()
            where TDst : class, ISqlTabularProxy, new()
            => stream<TDst>();

        public override string ToString()
            => $"[{ConnectionString.ServerName}].[{ConnectionString.DatabaseName}] {MetadataIndex}";
    }

    public class SqlProxyBroker<A> : SqlProxyBroker, ISqlProxyBroker<A>
        where A : class, ISqlProxyAssembly, new()
    {
        public SqlProxyBroker(ISqlProxyMetadataIndex Metadata, SqlConnectionString cs, Action<SqlNotification> observer = null)
            : base(Metadata, cs, m => observer(m))
        {

        }

        public Assembly ProxyAssembly
            => typeof(A).Assembly;
    }

}
