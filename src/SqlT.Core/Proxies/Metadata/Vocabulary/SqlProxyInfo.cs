//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    

    /// <summary>
    /// Base type for types included in the proxy metadata model
    /// </summary>
    public abstract class SqlProxyInfo : ISqlProxyInfo
    {

        static dynamic DocumentElement(SqlTableProxyInfo P, SqlTableDocumentation D)
        {
            var cols = P.Columns.Select(c 
                => new SqlColumnProxyInfo(c.ClrElement, c.ColumnName, c.Position, c.SqlType, D[c.ColumnName]
                )).ToList();           
            return new SqlTableProxyInfo(P.RuntimeType, P.ObjectName, cols, P.Indexes, P.PrimaryKey, D);
        }
            

        public static P Document<P,D>(P ProxyInfo, D Documentation)
            where P : SqlProxyInfo
            where D : SqlElementDocumetation 
            => DocumentElement((dynamic)ProxyInfo, (dynamic)Documentation);
        

        protected SqlProxyInfo(SqlProxyKind ProxyKind, object ClrElement, ISqlElementDocumentation Documentation)
        {
            this.ProxyKind = ProxyKind;
            this.ClrElement = ClrElement;
            this.Documentation = Documentation ?? SqlElementDocumetation.Empty;
        }

        public object ClrElement { get; }

        public SqlProxyKind ProxyKind { get; }

        public ISqlElementDocumentation Documentation { get; }

        public abstract Type RuntimeType { get; }

    }

    public abstract class SqlProxyInfo<N> : SqlProxyInfo
        where N : SqlName<N>, new()
    {


        protected SqlProxyInfo(N SqlName, SqlProxyKind ProxyKind, object ClrElement, ISqlElementDocumentation Documentation)
            : base(ProxyKind, ClrElement, Documentation)
        {
            this.SqlName = SqlName;            
        }

        public N SqlName { get; }
    }

}