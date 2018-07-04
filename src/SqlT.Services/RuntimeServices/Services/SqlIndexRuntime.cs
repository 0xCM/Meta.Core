﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlSystem;
    using SqlT.Syntax;

    class SqlIndexRuntime : SqlElementRuntime<SqlIndexRuntime, ISqlIndexHandle>, ISqlIndexRuntime
    {
        static readonly string ixproperty = $"indexproperty(object_id('@TableName'), '@IndexName', '@PropertyName')";
        static readonly string rebuild = $"alter index [@IndexName] on @TableName rebuild";
        static readonly string disable = $"alter index [@IndexName] on @TableName disable";
        static readonly string drop_if_exists = $"drop index if exists [@IndexName] on @TableName";
        static readonly string drop = $"drop index [@IndexName] on @TableName";

        string create(IEnumerable<SqlColumnName> columns, bool clustered, bool unique)
            => "create "
                + (unique ? "unique " : String.Empty)
                + (clustered ? "clustered" : "nonclustered ")
                + "index [" + Handle.ElementName + $"] on {Handle.TableName}("
                + string.Join(",", columns)
                + ")";

        public SqlIndexRuntime(IApplicationContext C, ISqlIndexHandle Handle)
            : base(C, Handle)
        {

        }

        Option<SqlBooleanValue> BinaryIndexProperty(string PropertyName)
        {
            var sql = SqlScript.FromText(ixproperty, new
            {
                TableName = Handle.TableName.FullName,
                IndexName = Handle.ElementName.ToString(),
                PropertyName
            }).ToString();

            return Handle.Broker.ExecuteScalarScript<int>(sql)
                   .TryMapValue(x => x != 0 ? SqlBooleanValue.True : SqlBooleanValue.False);
        }

        Option<SqlBooleanValue> ISqlIndexRuntime.Exists()
            => BinaryIndexProperty(index_property_name.IndexID);

        Option<SqlBooleanValue> ISqlIndexRuntime.IsClustered()
            => BinaryIndexProperty(index_property_name.IsClustered);

        public Option<SqlBooleanValue> IsDisabled()
            => BinaryIndexProperty(index_property_name.IsDisabled);

        Option<SqlBooleanValue> ISqlIndexRuntime.IsEnabled()
            => IsDisabled().Map(x => 
                x == SqlBooleanValue.False 
                ? SqlBooleanValue.True 
                : SqlBooleanValue.False
            );

        Option<SqlBooleanValue> ISqlIndexRuntime.IsUnique()
            => BinaryIndexProperty(index_property_name.IsUnique);

        Option<int> ISqlIndexRuntime.Disable()
            => Broker.ExecuteNonQuery(SqlScript.FromText(
                disable, new
                {
                    TableName = Handle.TableName.FullName,
                    IndexName = Handle.ElementName.ToString(),
                })).ToOption();

        Option<int> ISqlIndexRuntime.Rebuild()
            => Broker.ExecuteNonQuery(SqlScript.FromText(rebuild, 
                new
                {
                    TableName = Handle.TableName.FullName,
                    IndexName = Handle.ElementName.ToString(),
                })).ToOption();

        public Option<int> Drop(bool IfExists = true)
            => Broker.ExecuteNonQuery(SqlScript.FromText(
                IfExists ? drop_if_exists : drop, new
                {
                    TableName = Handle.TableName.FullName,
                    IndexName = Handle.ElementName.ToString(),
                })).ToOption();


        public Option<int> Create(IEnumerable<SqlColumnName> columns, bool clustered = false, bool unique = false)
        {
            var sql = create(columns, clustered, unique);
            return Broker.ExecuteNonQuery(sql).ToOption();
        }

        public Option<int> Create(IEnumerable<SqlColumnName> columns, IEnumerable<SqlColumnName> includes, bool clustered = false, bool unique = false)
        {
            var sql = create(columns, clustered, unique)
                + " include(" + string.Join(",", columns) + ")";
            return Broker.ExecuteNonQuery(sql).ToOption();
        }

    }
}