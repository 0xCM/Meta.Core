//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;
    using SqlT.Language;

    using static metacore;

    public static partial class SqlDatabaseX
    {
        public static SqlDatabaseHandle Database(this ISqlHandle h)
            => h.Broker.Database(h.Broker.ConnectionString.QualifiedDatabaseName);

        public static ISqlTableHandle Table(this ISqlDatabaseHandle h, SqlTableName name)
            => new SqlTableHandle(h.Broker, name);

        public static ISqlSequenceHandle Sequence(this ISqlDatabaseHandle h, SqlSequenceName name)
                    => new SqlSequenceHandle(h.Broker, name);

        public static ISqlSchemaHandle Schema(this ISqlDatabaseHandle h, SqlSchemaName name)
            => new SqlSchemaHandle(h.Broker, name);

        public static ISqlServerHandle Server(this ISqlDatabaseHandle h)
            => h.Broker.Server();

        public static Option<SqlElementExists> Exists(this ISqlDatabaseHandle h)
            => h.ExecuteScalarScript<int>(h.DatabaseName.SQL_EXISTS())
                .TryMapValue(yes => yes == 1 ? SqlElementExists.Yes : SqlElementExists.No);
       
        public static ISystemViewProvider SystemViews(this ISqlDatabaseHandle h)
            => SqlSystemViews.Create(new SystemViewsSettings
                (
                    h.Broker.ConnectionString,
                    Source: h.DatabaseName
                ));

        public static ScalarResult<T> ExecuteScalarScript<T>(this ISqlDatabaseHandle h,
            string sql, params (string, object)[] args)
                => h.Broker.ExecuteScalarScript<T>(sql, args);

        public static Option<ISqlDatabaseHandle> Create(this ISqlDatabaseHandle h, SqlDatabase model)
            => h.Broker.ExecuteNonQuery(model.TSqlCreate().GenerateScript()).TryMapValue(_ => h);
    }
}