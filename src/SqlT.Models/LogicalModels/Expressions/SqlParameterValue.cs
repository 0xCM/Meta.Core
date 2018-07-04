//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;    


    public class SqlParameterValue : SyntaxExpression<SqlParameterValue>
    {
        public SqlParameterValue(SqlParameterName ParameterName, CoreDataValue AssignedValue)
        {
            require(AssignedValue);

            this.ParameterName = ParameterName;
            this.AssignedValue = AssignedValue;
        }
        public SqlParameterName ParameterName { get; }

        public CoreDataValue AssignedValue { get; }

        public string Format()
            => $"{ParameterName}={AssignedValue}";

        public override string ToString()
            => Format();
    }

    public static class SqlParameterValueExtensions
    {
        public static string Format(this IEnumerable<SqlParameterValue> values)
            => string.Join(",", map(values,v => v.Format()));
    }
}
