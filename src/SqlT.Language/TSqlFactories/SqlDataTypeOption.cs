//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;    
    using SqlT.Syntax;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sxc = SqlT.Syntax.contracts;

    public static partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.SqlDataTypeOption TSqlDataTypeOption(this sxc.ISqlDataType src)
            => parseEnum<TSql.SqlDataTypeOption>(src.Name.UnquotedLocalName);

        [TSqlBuilder]
        public static TSql.SqlDataTypeOption TSqlDataTypeOption(this sxc.data_type_ref src)
        {
            var value = TSql.SqlDataTypeOption.None;
            Enum.TryParse(src.type_name.UnqualifiedName, true, out value);
            return value;
        }
    }
}