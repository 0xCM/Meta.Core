namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;



    class SqlFormatter : ISqlFormatter
    {
        static readonly IReadOnlySet<string> TextFormatTypes
            = roset("String", "DateTime", "Guid");

        public string FormatSelectList(IReadOnlyList<SqlColumnIdentifier> cols)
        {
            var sb = new StringBuilder();
            if (cols.Count != 0)
            {
                var firstPos = cols.First().ColumnPosition;
                var finalPos = cols.Last().ColumnPosition;
                foreach (var col in cols)
                {
                    sb.Append($"\t[{col.ColumnName}]");
                    if (col.ColumnPosition != finalPos)
                        sb.AppendLine(",");
                    else
                        sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public string FormatValue(object value)
        {
            if (value == null)
                return "null";

            var t = value.GetType();

            if (TextFormatTypes.Contains(value.GetType().Name))
                return $"'{value}'";
            else
                return value.ToString();
            
        }
    }
}
