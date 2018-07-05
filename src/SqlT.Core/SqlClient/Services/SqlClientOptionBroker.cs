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

    public class SqlClientOptionBroker : ISqlClientOptionBroker
    {
        ISqlClientBroker ClientBroker { get; }

        public SqlClientOptionBroker(ISqlClientBroker ClientBroker)
            => this.ClientBroker = ClientBroker;

        public SqlConnectionString ConnectionString 
            => ClientBroker.ConnectionString;

        public Option<ISqlBrokerSession> CreateSession()
            => ClientBroker.CreateSession();

        public Option<int> ExecuteNonQuery(string sql)
            => ClientBroker.ExecuteNonQuery(sql);
        
        public Option<int> ExecuteProcedure(SqlProcedureName procedure, params (string, object)[] arguments)
            => ClientBroker.ExecuteProcedure(procedure, arguments);

        public ScalarResult<T> ExecuteScalarFunction<T>(SqlFunctionName function, params object[] arguments)
            => ClientBroker.ExecuteScalarFunction<T>(function, arguments);

        public ScalarResult<T> ExecuteScalarFunction<T>(SqlFunctionName function, params (string, object)[] arguments)
            => ClientBroker.ExecuteScalarFunction<T>(function, arguments);

        public ScalarResult<T> ExecuteScalarScript<T>(string sql, params (string, object)[] arguments)
            => ClientBroker.ExecuteScalarScript<T>(sql, arguments);

        public Option<object> ExecuteScalarScript(string sql)        
            => ClientBroker.ExecuteScalarScript(sql);

        public Option<T> NextSequenceValue<T>(SqlSequenceName sequence)
            => ClientBroker.NextSequenceValue<T>(sequence);

        public Option<IReadOnlyList<T>> NextSequenceValues<T>(SqlSequenceName sequence, int cout)
            => ClientBroker.NextSequenceValues<T>(sequence, cout);

        public void RegisterConverter<TSrc, TDst>(SqlConversionDirection direction, Func<TSrc, TDst> f)
            => ClientBroker.RegisterConverter(direction, f);

        public Option<SqlDataFrame> Select(string sql)
            => ClientBroker.Select(sql);

        public Option<IReadOnlyList<T>> Select<T>(string sql) where T : new()
            => ClientBroker.Select<T>(sql);
        
        public Option<object> ExecuteScalarFunction(SqlFunctionName function, params object[] arguments)
            => ClientBroker.ExecuteScalarFunction(function, arguments);
    }

}
