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

    public sealed class SqlScriptArgument
    {

        public SqlScriptArgument(SqlParameterName ParameterName, object ArgumentValue, bool IsOutputParameter = false)
        {
            this.ArgumentName = ParameterName;
            this.ArgumentValue = ArgumentValue;
            this.IsOutputParameter = IsOutputParameter;          
        }

        public string ArgumentName { get; }

        public object ArgumentValue { get; }

        public bool IsOutputParameter { get; }

        public override string ToString()
            => $"@{ArgumentName}={SqlScript.FormatScriptValue(ArgumentValue)}";

    }


}
