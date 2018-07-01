//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public class OperationParameter
    {

        public static readonly OperationParameter Anonymous = new OperationParameter(String.Empty);


        public static implicit operator string(OperationParameter x)
            => toString(x);

        public static implicit operator OperationParameter(string x)
            => new OperationParameter(x);

        public OperationParameter()
        {
            ParameterName = string.Empty;
        }

        public OperationParameter(string ParameterName)
        {
            this.ParameterName = ParameterName;
        }

        public string ParameterName { get; set; }


        public bool IsAnyonymous
            => isBlank(ParameterName);
        public override string ToString()
            => toString(ParameterName);
    }

}