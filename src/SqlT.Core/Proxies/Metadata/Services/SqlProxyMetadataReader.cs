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
    using System.Reflection;
    using System.Linq.Expressions;
    using System.Collections.Concurrent;

    /// <summary>
    /// Constructs proxy metadata by scraping it off the proxy types and attributions
    /// </summary>
    /// <remarks>
    /// Intended to only be used by the metadata infrastructure
    /// </remarks>
    static class SqlProxyMetadataReader
    {
        public static bool HasAttribute<A>(this MemberInfo t) where A : Attribute
            => System.Attribute.IsDefined(t, typeof(A));

        static A Attribute<A>(this PropertyInfo property)
            where A : Attribute => property.GetCustomAttribute<A>();


        static SqlTypeInfo DescribeSqlType(this PropertyInfo ClrElement)
        {
            var a = ClrElement.GetCustomAttribute<SqlTypeFacetsAttribute>();
            if (a != null)
                return a.DescribeType();

            return new SqlTypeInfo();
        }

        static SqlColumnProxyInfo DescribeColumn(this PropertyInfo ClrElement)
        {
            var a = ClrElement.GetCustomAttribute<SqlColumnAttribute>();
            var sqlType = ClrElement.DescribeSqlType();
            return new SqlColumnProxyInfo(ClrElement, a.ColumnName, a.Position, sqlType);
        }

        static IReadOnlyList<SqlColumnProxyInfo> DescribeColumns(this SqlProxyType ProxyType)
        {
            var descriptions = new List<SqlColumnProxyInfo>();
            var properties = ProxyType.GetPropertyIndex();
            for(var pos = 0; pos < properties.Count; pos++)
            {
                var prop = properties[pos];
                var a = prop.GetCustomAttribute<SqlColumnAttribute>();
                var sqlType = prop.DescribeSqlType();
                if (a != null)
                    descriptions.Add(new SqlColumnProxyInfo(prop, a.ColumnName, a.Position, sqlType));
                else
                    descriptions.Add(new SqlColumnProxyInfo(prop, prop.Name, pos, sqlType));
            }
            return descriptions;
        }


        public static IReadOnlyList<SqlColumnProxyInfo> DescribeColumns(this Type ClrElement)
            => ClrElement.GetProperties()
                         .Where(p => p.HasAttribute<SqlColumnAttribute>())
                         .Select(p => p.DescribeColumn())
                         .OrderBy(p => p.Position)
                         .ToList();



        public static IReadOnlyList<SqlParameterProxyInfo> DescribeParameters(this Type ClrElement)
            => ClrElement.GetProperties()
                         .Where(p => p.HasAttribute<SqlParameterAttribute>())
                         .Select(p => p.DescribeParameter())
                         .OrderBy(p => p.Position)
                         .ToList();
        public static SqlParameterProxyInfo DescribeParameter(this PropertyInfo ClrElement)
        {
            var a = ClrElement.GetCustomAttribute<SqlParameterAttribute>();
            return new SqlParameterProxyInfo(ClrElement, a.ParameterName, a.Position, a.IsStructured, a.IsOutput);
        }

        public static SqlPrimaryKeyName GetSqlObjectName(this SqlPrimaryKeyAttribute a)
            => new SqlPrimaryKeyName(a.SchemaName, a.ObjectName);

       
        static SqlViewName GetSqlObjectName(this SqlViewAttribute a)
            => new SqlViewName(a.SchemaName, a.ObjectName);


        public static SqlTabularProxyInfo DescribeTabularResult(this Type type, SqlNamedResultAttribute a)
            => new SqlNamedResultProxyInfo(type, a.ResultName, type.DescribeColumns());

        public static SqlViewProxyInfo DescribeView(this Type type, SqlViewAttribute a)
            => new SqlViewProxyInfo(type, a.GetSqlObjectName(), type.DescribeColumns());

        static SqlIndexColumnProxyInfo DescribeIndexColumn(this PropertyInfo ClrElement)
        {
            var a = ClrElement.GetCustomAttribute<SqlIndexColumnAttribute>();
            var sqlType = ClrElement.DescribeSqlType();
            return new SqlIndexColumnProxyInfo
                (
                    ClrElement,
                    a.ReferencedColumnName,
                    a.ReferencedColumnPosition,
                    a.IndexColumnPosition,
                    sqlType
                );
        }

        static IReadOnlyList<SqlIndexColumnProxyInfo> DescribeIndexColumns(this Type ClrElement)
            => ClrElement.GetProperties()
                         .Where(p => p.HasAttribute<SqlIndexColumnAttribute>())
                         .Select(p => p.DescribeIndexColumn())
                         .OrderBy(p => p.Position)
                         .ToList();

        public static SqlIndexProxyInfo DescribeIndex(this Type type, SqlIndexAttribute a)
            => new SqlIndexProxyInfo(type, a.TableName, a.IndexName, type.DescribeIndexColumns());

        public static SqlTableProxyInfo DescribeTable(this Type type, SqlTableAttribute a,
            IReadOnlyDictionary<string, IReadOnlyList<SqlIndexProxyInfo>> indexLU = null,
            IReadOnlyDictionary<string, SqlPrimaryKeyProxyInfo> primaryKeyLU = null
            )
        {

            var ptype = SqlProxyType.Create(type);
            var tableName = ptype.InferTableName();

            var indexes = (indexLU != null && indexLU.ContainsKey(tableName.FullName))
                        ? indexLU[tableName.FullName]
                        : new SqlIndexProxyInfo[] { };

            var pk = (primaryKeyLU != null && primaryKeyLU.ContainsKey(tableName.FullName))
                   ? primaryKeyLU[tableName.FullName]
                   : null;

            return new SqlTableProxyInfo(ptype, tableName, ptype.DescribeColumns(), indexes, pk);
        }

        public static SqlTableTypeProxyInfo DescribeTableType(this Type type, SqlRecordAttribute a)
            => new SqlTableTypeProxyInfo(type, a.TableTypeName, type.DescribeColumns());

        static SqlPrimaryKeyColumnProxyInfo DescribePrimaryKeyColumn(this PropertyInfo ClrElement)
        {
            var a = ClrElement.GetCustomAttribute<SqlPrimaryKeyColumnAttribute>();
            var sqlType = ClrElement.DescribeSqlType();
            return new SqlPrimaryKeyColumnProxyInfo
                (
                    ClrElement,
                    a.ReferencedColumnName,
                    a.ReferencedColumnPosition,
                    a.KeyColumnPosition,
                    sqlType
                );
        }

        public static IReadOnlyList<SqlColumnProxyInfo> DescribePrimaryKeyColumns(this Type ClrElement)
            => ClrElement.GetProperties()
                         .Where(p => p.HasAttribute<SqlPrimaryKeyColumnAttribute>())
                         .Select(p => p.DescribePrimaryKeyColumn())
                         .OrderBy(p => p.Position)
                         .ToList();

        public static SqlPrimaryKeyProxyInfo DescribePrimaryKey(this Type type, SqlPrimaryKeyAttribute a)
            => new SqlPrimaryKeyProxyInfo(type, a.TableObjectName, a.GetSqlObjectName(), type.DescribePrimaryKeyColumns());

        public static SqlTabularProxyInfo DescribeTabularResult(this Type type, SqlTableFunctionResultAttribute a)
            => new SqlTableFunctionResultProxyInfo(type,
                new SqlTableName(a.SchemaName, a.FunctionName), type.DescribeColumns());

        public static SqlRoutineProxyInfo DescribeRoutine(this Type ClrElement,
            IReadOnlyDictionary<Type, SqlTableTypeProxyInfo> recordLU,
            IReadOnlyDictionary<Type, SqlTabularProxyInfo> resultLU
            )
        {
            var a = ClrElement.GetCustomAttribute<SqlRoutineAttribute>();

            var parameters = ClrElement.DescribeParameters();

            var genericContract = ClrElement.GetInterfaces().Where(
                x => x.IsGenericType
                    && x.GetGenericArguments().Length == 2
                    && x.Name.Contains(nameof(ISqlRoutineProxy))).FirstOrDefault();

            var resultType
                    = genericContract != null
                    ? genericContract.GetGenericArguments()[1]
                    : null;

            var resultProxyInfo = resultType
                    != null
                    ? (recordLU.ContainsKey(resultType) ? recordLU[resultType]
                            : (resultLU.ContainsKey(resultType) ? resultLU[resultType] : null))
                    : null;
            return
                a is SqlProcedureAttribute
                ? (SqlRoutineProxyInfo)
                    new SqlProcedureProxyInfo(ClrElement, new SqlProcedureName(a.SchemaName, a.ObjectName), parameters, resultProxyInfo)
                : (SqlRoutineProxyInfo)
                    new SqlTableFunctionProxyInfo(ClrElement, new SqlFunctionName(a.SchemaName, a.ObjectName), parameters, resultProxyInfo);
        }

    }





}