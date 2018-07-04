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

    public sealed class SqlScalarFunctionCall
    {
        public SqlScalarFunctionCall(SqlFunctionName FunctionName, params SqlScriptArgument[] Arguments)
        {
            this.FunctionName = FunctionName;
            this.Arguments = Arguments.ToList();
        }

        public SqlFunctionName FunctionName { get; }

        public IReadOnlyList<SqlScriptArgument> Arguments { get; }

        public override string ToString()
            => $"{FunctionName}(" + string.Join(",", Arguments) + ")";
    }
}
