//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    public interface ISqlProxyMetadataProvider
    {
        /// <summary>
        /// All table proxy metadata
        /// </summary>
        IEnumerable<SqlTableTypeProxyInfo> TableTypes { get; }

        /// <summary>
        /// Find table proxy information given its proxy type
        /// </summary>
        /// <param name="ProxyType">The type for which metadata is to be found</param>
        /// <returns></returns>
        SqlTableTypeProxyInfo TableType(Type ProxyType);

        /// <summary>
        /// Finds proxy information given a database object name
        /// </summary>
        /// <param name="Name">The name of the table</param>
        /// <returns></returns>
        SqlTableTypeProxyInfo TableType(SqlTableTypeName Name);

        /// <summary>
        /// All primary key metadata
        /// </summary>
        IEnumerable<SqlPrimaryKeyProxyInfo> PrimaryKeys { get; }

        /// <summary>
        /// All table index proxy metadata
        /// </summary>
        IEnumerable<SqlIndexProxyInfo> Indexes { get; }

        /// <summary>
        /// Finds table proxy information from a given type parameter
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <returns></returns>
        SqlTableProxyInfo Table<P>() 
            where P : ISqlTableProxy, new();

        /// <summary>
        /// Find table proxy information given its proxy type
        /// </summary>
        /// <param name="ProxyType">The type for which metadata is to be found</param>
        /// <returns></returns>
        SqlTableProxyInfo Table(Type ProxyType);
        
        /// <summary>
        /// Finds table proxy information given a table name
        /// </summary>
        /// <param name="Name">The name of the table</param>
        /// <returns></returns>
        SqlTableProxyInfo Table(SqlTableName Name);

        /// <summary>
        /// Describes a promary key proxy identified by the primary key proxy type
        /// </summary>
        /// <param name="ProxyType">The primary key proxy type</param>
        /// <returns></returns>
        SqlPrimaryKeyProxyInfo PrimaryKey(Type ProxyType);

        /// <summary>
        /// Describes a promary key proxy identified by the primary key proxy type
        /// </summary>
        /// <typeparam name="P">The index proxy type</typeparam>
        /// <returns></returns>
        SqlPrimaryKeyProxyInfo PrimaryKey<P>() 
            where P : ISqlPrimaryKeyProxy;

        /// <summary>
        /// Describes an index proxy identified by the index proxy type
        /// </summary>
        /// <typeparam name="P">The index proxy type</typeparam>
        /// <returns></returns>
        SqlIndexProxyInfo Index<P>()
            where P : ISqlIndexProxy;

        /// <summary>
        /// Describes an index proxy identified by the index proxy type
        /// </summary>
        SqlIndexProxyInfo Index(Type ProxyType);

        /// <summary>
        /// Finds tabular metadata for as specified proxy type
        /// </summary>
        /// <typeparam name="P">The proxy type</typeparam>
        /// <returns></returns>
        SqlTabularProxyInfo Tabular<P>() 
            where P : ISqlTabularProxy, new();

        /// <summary>
        /// Finds tabular metatada for a specified proxy type
        /// </summary>
        /// <param name="proxyType"></param>
        /// <returns></returns>
        SqlTabularProxyInfo Tabular(Type proxyType);

        SqlColumnProxyInfo Column<P>(string MemberName) 
            where P : ISqlTabularProxy;

        IReadOnlyList<SqlColumnProxyInfo> Columns<TProxy>() 
            where TProxy : ISqlTabularProxy;

        SqlTableTypeProxyInfo TableType<P>() 
            where P : ISqlTableTypeProxy;

        /// <summary>
        /// Finds table function proxy information given a proxy type
        /// </summary>
        /// <typeparam name="P">The table function proxy type</typeparam>
        /// <returns></returns>
        SqlTableFunctionProxyInfo TableFunction<P>() 
            where P : ISqlTableFunctionProxy;

        /// <summary>
        /// Finds procedure proxy information given a procedure name
        /// </summary>
        /// <param name="Name">The name of the procedure</param>
        /// <returns></returns>
        SqlProcedureProxyInfo Procedure(SqlProcedureName Name);

        /// <summary>
        /// Describes an index proxy identified by the index proxy type
        /// </summary>
        SqlProcedureProxyInfo Procedure(Type ProxyType);

        /// <summary>
        /// Available procedure proxy descriptions
        /// </summary>
        /// <typeparam name="P">The procedure proxy type</typeparam>
        /// <returns></returns>
        SqlProcedureProxyInfo Procedure<P>() 
            where P : ISqlProcedureProxy;

        /// <summary>
        /// Available table function proxy descriptions
        /// </summary>
        IEnumerable<SqlTableFunctionProxyInfo> TableFunctions { get; }

        /// <summary>
        /// Available table proxy descriptions
        /// </summary>
        IEnumerable<SqlTableProxyInfo> Tables { get; }

        /// <summary>
        /// Enumerates all procedure proxies known to the provider
        /// </summary>
        IEnumerable<SqlProcedureProxyInfo> Procedures { get; }

        /// <summary>
        /// Describes a sequence proxy
        /// </summary>
        /// <typeparam name="P">The sequency proxy type</typeparam>
        /// <returns></returns>
        SqlSequenceProxyInfo Sequence<P>() 
            where P : ISqlSequenceProxy;

        /// <summary>
        /// Describes a view proxy
        /// </summary>
        /// <typeparam name="P">The view proxy type</typeparam>
        /// <returns></returns>
        SqlViewProxyInfo View<P>() 
            where P : ISqlViewProxy;

        SqlColumnProxyInfo Column<T, C>(Expression<Func<T, C>> ex0)
            where T : ISqlTabularProxy;
    }


}
