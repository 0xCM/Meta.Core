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
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Concurrent;

    using Meta.Core;
    using SqlT.Types;

    using sxc = SqlT.Syntax.contracts;

    using static metacore;    
    
    /// <summary>
    /// Convenience gateway to proxy metatadata facilities
    /// </summary>
    public static class PXM
    {
        static ReadOnlySet<Type> TypeTableContracts
            = roset(typeof(ITinyTypeTable), typeof(ISmallTypeTable), typeof(ILargeTypeTable));

        public static bool IsTypeTable(SqlTableProxyInfo p)
            => roset(p.RuntimeType.GetInterfaces().ToArray()).Intersect(TypeTableContracts).Any();


        public static ISqlProxyMetadataIndex PMI { get; }

        static PXM()
        {
            PMI = AppDomain.CurrentDomain.SqlProxyMetadataIndex();
        }

        static Assembly A<X>()
            where X : ISqlProxy
            => typeof(X).Assembly;

        static ISqlProxyMetadataIndex PMX(Assembly A)
            => A.SqlProxyMetadataIndex();

        static ISqlProxyMetadataIndex PMX<X>()
            where X : ISqlProxy
            => A<X>().SqlProxyMetadataIndex();

        public static IEnumerable<SqlTableProxyInfo> Tables
            => PMI.Tables;

        public static SqlTableProxyInfo Table(Type ProxyType)
            => PMI.Table(ProxyType);

        public static SqlTableProxyInfo Table(SqlTableName Name)
            => PMI.Table(Name);

        public static SqlTableProxyInfo Table<T>()
            where T : class, ISqlTableProxy, new()
            => PMX<T>().Table<T>();

        public static SqlTableName TableName<T>()
            where T : class, ISqlTableProxy, new()
            => Table<T>().ObjectName;

        public static SqlTabularProxyInfo Tabular(Type ProxyType)
            => PMI.Tabular(ProxyType);

        public static IEnumerable<SqlColumnProxyInfo> Columns(Type ProxyType)
            => Tabular(ProxyType).Columns;

        public static IEnumerable<SqlColumnProxyInfo> Columns<T>()
            where T : class, ISqlTabularProxy, new()
            => from c in Tabular<T>().Columns
               select c;

        public static SqlColumnProxyInfo Column<T>(string ColumnName)
            where T : class, ISqlTabularProxy, new()
            => (from c in Tabular<T>().Columns
                where c.ColumnName == ColumnName
                select c).Single();

        public static SqlColumnProxyInfo Column<T>(Expression<Func<T, object>> Selector)
            where T : class, ISqlTabularProxy, new()
            => Column<T>(Selector.SelectedPropertyName());

        public static SqlColumnProxyInfo Column(Type ProxyType, ClrPropertyName PropertyName)
            => Tabular(ProxyType).FindColumnByRuntimeName(PropertyName);

        public static IEnumerable<SqlColumnName> ColumnNames(Type ProxyType)
            => Columns(ProxyType).Select(x => x.ColumnName);

        public static IEnumerable<SqlColumnName> ColumnNames<T>()
            where T : class, ISqlTabularProxy, new()
            => from c in Columns<T>() select c.ColumnName;

        public static SqlTabularProxyInfo Tabular<T>()
            where T : class, ISqlTabularProxy, new()
            => PMX<T>().Tabular<T>();

        public static sxc.tabular_name TabularName<T>()
            where T : class, ISqlTabularProxy, new()
            => Tabular<T>().ObjectName;

        public static sxc.tabular_name TabularName(Type ProxyType)
            => Tabular(ProxyType).ObjectName;

        public static IEnumerable<SqlProcedureProxyInfo> Procedures
            => PMI.Procedures;

        public static SqlProcedureProxyInfo Procedure(Type ProxyType)
            => PMI.Procedure(ProxyType);

        public static SqlProcedureProxyInfo Procedure(SqlProcedureName Name)
            => PMI.Procedure(Name);

        public static SqlProcedureProxyInfo Procedure<T>()
            where T : class, ISqlProcedureProxy, new()
            => PMX<T>().Procedure<T>();

        public static SqlProcedureName ProcedureName<T>()
            where T : class, ISqlProcedureProxy, new()
            => Procedure<T>().ObjectName;

        public static SqlObjectProxyInfo Object<T>()
            where T : class, ISqlObjectProxy, new()
            => PMX<T>().Describe(typeof(T));

        public static sxc.ISqlObjectName ObjectName<T>()
            where T : class, ISqlObjectProxy, new()
            => Object<T>().ObjectName;

        public static IEnumerable<SqlTableTypeProxyInfo> TableTypes
            => PMI.TableTypes;

        public static SqlTableTypeProxyInfo TableType(Type ProxyType)
            => PMI.TableType(ProxyType);

        public static SqlTableTypeProxyInfo TableType(SqlTableTypeName Name)
            => PMI.TableType(Name);

        public static SqlTableTypeProxyInfo TableType<T>()
            where T : class, ISqlTableTypeProxy, new()
            => PMX<T>().TableType<T>();

        public static SqlTableTypeName TableTypeName<T>()
            where T : class, ISqlTableTypeProxy, new()
            => TableType<T>().ObjectName;

        public static SqlTableTypeName TableTypeName(Type ProxyType)            
            => TableType(ProxyType).ObjectName;

        public static IEnumerable<SqlIndexProxyInfo> Indexes
            => PMI.Indexes;

        public static SqlTableFunctionProxyInfo TableFunction<F, R>()
              where F : class, ISqlTableFunctionProxy<F, R>, new()
                    where R : class, ISqlTabularProxy, new()
            => PMX<F>().TableFunction<F>();

        public static SqlFunctionName TableFunctionName<F, R>()
              where F : class, ISqlTableFunctionProxy<F, R>, new()
                    where R : class, ISqlTabularProxy, new()
            => TableFunction<F, R>().ObjectName;

        public static SqlTableFunctionProxyInfo TableFunction<T>()
            where T : ISqlTableFunctionProxy, new()
                => typeof(T).Assembly.ProxyBrokerFactory().Metadata.TableFunction<T>();

        public static IEnumerable<SqlTableFunctionProxyInfo> TableFunctions
            => PMI.TableFunctions;

        public static IEnumerable<SqlPrimaryKeyProxyInfo> PrimaryKeys
            => PMI.PrimaryKeys;

        public static SqlPrimaryKeyProxyInfo PrimaryKey(Type ProxyType)
            => PMI.PrimaryKey(ProxyType);

        public static SqlPrimaryKeyProxyInfo PrimaryKey<P>()
            where P : class, ISqlPrimaryKeyProxy, new()
          => PMX<P>().PrimaryKey<P>();
    }
}