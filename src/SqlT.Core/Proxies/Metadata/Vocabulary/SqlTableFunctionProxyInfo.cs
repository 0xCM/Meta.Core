﻿//-------------------------------------------------------------------------------------------
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

    public class SqlTableFunctionProxyInfo : SqlFunctionProxyInfo
    {
        public SqlTableFunctionProxyInfo
            (
                Type RuntimeType,
                SqlFunctionName ObjectName,
                IReadOnlyList<SqlParameterProxyInfo> Parameters,
                SqlTabularProxyInfo ResultProxy
            )
            : base(SqlProxyKind.TableFuntion, RuntimeType, ObjectName, Parameters)
        {

            this.ResultProxy = ResultProxy;

        }


        public SqlTabularProxyInfo ResultProxy { get; }

    }
}