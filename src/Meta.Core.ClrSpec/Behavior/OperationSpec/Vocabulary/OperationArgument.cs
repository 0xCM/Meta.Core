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
    using System.Text;

    using static metacore;

    public class OperationArgument
    {
        public static implicit operator OperationArgument((string, string) arg)
            => new OperationArgument(arg.Item1, arg.Item2);

        public static implicit operator OperationArgument((OperationParameter, string) arg)
            => new OperationArgument(arg.Item1, arg.Item2);

        public static implicit operator (string, string) (OperationArgument arg)
            => (arg.Name, arg.Value);


        public static readonly OperationArgument Empty = new OperationArgument();

        public static OperationArgument Parse(string expression)
        {
            if (isBlank(expression))
                return Empty;

            var parts = expression.Split(':');
            if (parts.Length == 1)
                return new OperationArgument(parts[0]);
            else if (parts.Length == 2)
                return new OperationArgument(parts[0], parts[1]);
            else
                return new OperationArgument(parts[0], $"bag({string.Join("/|_|\\", parts.Skip(1))}");

        }

        public OperationArgument()
        {
            Name = OperationParameter.Anonymous;
            Value = string.Empty;

        }

        public OperationArgument(OperationParameter Parameter)
        {
            this.Name = Parameter;
            this.Value = string.Empty;
        }

        public OperationArgument(OperationParameter Parameter, string Value)
        {
            this.Name = Parameter;
            this.Value = Value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
            => $"{Name}: {Value}";

    }


}