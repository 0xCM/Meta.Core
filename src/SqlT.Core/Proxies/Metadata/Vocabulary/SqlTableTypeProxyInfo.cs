//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;


    public class SqlTableTypeProxyInfo : SqlTabularProxyInfo
    {
        public SqlTableTypeProxyInfo(Type RuntimeType, SqlTableTypeName TypeName, IReadOnlyList<SqlColumnProxyInfo> Columns)
            : base(SqlProxyKind.TableType, RuntimeType, TypeName, Columns)
        {
            this.ObjectName = TypeName;
        }


        public new SqlTableTypeName ObjectName { get; }
    }
}