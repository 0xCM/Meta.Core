//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;
    public abstract class SqlObjectProxyInfo : SqlProxyInfo
    {
        readonly sxc.ISqlObjectName _ObjectName;

        protected SqlObjectProxyInfo
            (
            SqlProxyKind ProxyKind,
            object ClrElement,
            sxc.ISqlObjectName ObjectName,
            ISqlObjectDocumentation Documentation = null
            ) : base(ProxyKind, ClrElement, Documentation)
                => _ObjectName = ObjectName;

        public sxc.ISqlObjectName ObjectName 
            => _ObjectName;

        public string FullName 
            => ObjectName.ToString();

        public override string ToString() 
            => FullName;
    }


    public abstract class SqlObjectProxyInfo<N> : SqlProxyInfo<N>
        where N : SqlObjectName<N>, new()
    {

        protected SqlObjectProxyInfo(SqlProxyKind ProxyKind, object ClrElement, N SqlName, ISqlObjectDocumentation Documentation = null) 
            : base(SqlName, ProxyKind, ClrElement, Documentation)
        {

        }


        public string FullName
            => SqlName.ToString();

        public override string ToString()
            => FullName;
    }

}