//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;


    public abstract class SqlFunctionProxyInfo : SqlRoutineProxyInfo
    {
        protected SqlFunctionProxyInfo
            (
                SqlProxyKind ProxyKind,
                Type RuntimeType,
                SqlFunctionName ObjectName,
                IReadOnlyList<SqlParameterProxyInfo> Parameters
            )
            : base(ProxyKind, RuntimeType, ObjectName, Parameters)
        {

            this.ObjectName = ObjectName;
        }

        public new SqlFunctionName ObjectName { get; }
            


    }
}