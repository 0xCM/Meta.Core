namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;



    public interface ISqlFormatter
    {
        //string FormatOrderBy(IReadOnlyList<SqlColumnName> cols);
        string FormatSelectList(IReadOnlyList<SqlColumnIdentifier> cols);
        //string FormatSelectStatement(IReadOnlyList<SqlColumnIdentifier> cols, int? top = null);
        //string FormatSelectConditions(IReadOnlyList<string> conditions);
    }

}