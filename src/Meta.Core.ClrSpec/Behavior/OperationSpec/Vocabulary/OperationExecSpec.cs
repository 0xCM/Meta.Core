//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OperationExecSpec
    {
        public static readonly OperationExecSpec Anonymous = new OperationExecSpec(string.Empty);

        public OperationExecSpec()
        {
            this.OperationName = String.Empty;
        }

        public OperationExecSpec(string OperationName, bool IsActive = false, params OperationArgument[] Arguments)
        {
            this.OperationName = OperationName;
            this.Arguments = OperationArguments.Create(Arguments).ToDictionary();
            this.IsActive = IsActive;
        }

        public string OperationName { get; set; }

        public bool IsActive { get; set; }

        public IReadOnlyDictionary<string, string> Arguments { get; set; }

        public override string ToString()
        {
            var args = OperationArguments.FromDictionary(Arguments).ToString();
            return $"{OperationName}({args})";
        }

    }
}