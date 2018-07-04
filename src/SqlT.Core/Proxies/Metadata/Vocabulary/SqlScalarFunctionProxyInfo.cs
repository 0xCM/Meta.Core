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

    public class SqlScalarFunctionProxyInfo : SqlFunctionProxyInfo
    {

        public SqlScalarFunctionProxyInfo
            (                
                Type RuntimeType,
                SqlFunctionName FunctionName,
                IReadOnlyList<SqlParameterProxyInfo> Parameters,
                SqlName ReturnTypeName
            )
            : base(SqlProxyKind.ScalarFunction, RuntimeType, FunctionName, Parameters)
        {
            this.ReturnTypeName = ReturnTypeName;
            this.ObjectName = FunctionName;
        }

        public SqlName ReturnTypeName { get; }

        public new SqlFunctionName ObjectName { get; }
    }

}
