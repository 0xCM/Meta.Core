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

    using sxc = SqlT.Syntax.contracts;

    public class SqlTableFunctionResultProxyInfo : SqlTabularProxyInfo
    {
        public SqlTableFunctionResultProxyInfo(Type RuntimeType, sxc.tabular_name ResultName, IReadOnlyList<SqlColumnProxyInfo> Columns)
            : base(SqlProxyKind.TableFunctionResult, RuntimeType, ResultName, Columns)
        {

        }

        public override Type RuntimeType 
            => ClrElement as Type;
    }
}