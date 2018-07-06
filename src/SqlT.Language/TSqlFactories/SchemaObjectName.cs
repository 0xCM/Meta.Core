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
    using SqlT.Language;
    using SqlT.Syntax;
    using static metacore;
    using sxc = Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.SchemaObjectName TSqlSchemaObjectName(this sxc.ISqlDataType model)
        {
            var son = new TSql.SchemaObjectName();
            son.Identifiers.Add(model.Name.UnquotedLocalName.TSqlIdentifier());
            return son;
        }

        [TSqlBuilder]
        public static TSql.SchemaObjectName TSqlSchemaObjectName(this sxc.sql_object src, bool quoted = true)
            => src.ObjectName.TSqlSchemaObjectName(quoted);

        [TSqlBuilder]
        public static TSql.SchemaObjectName TSqlSchemaObjectName(this TSql.SqlDataTypeOption tsql, bool quoted = false)
        {
            var name = new TSql.SchemaObjectName();
            name.Identifiers.Add(new TSql.Identifier()
            {
                QuoteType = TSql.QuoteType.NotQuoted,
                Value = tsql.ToString()
            });
            return name;
        }


        [TSqlBuilder]
        public static TSql.SchemaObjectName TSqlSchemaObjectName(this sxc.ISqlObjectName src, bool quoted = true)
        {
            var n = new TSql.SchemaObjectName();
            if (src.IsSystemObject && not(src.IsDatabaseQualified()))
            {
                n.Identifiers.Add(src.UnqualifiedName.TSqlIdentifier(false));
                return n;
            }
            else
            {
                if (isNotBlank(src.ServerNamePart))
                    n.Identifiers.Add(src.ServerNamePart.TSqlIdentifier(quoted));

                if (isNotBlank(src.DatabaseNamePart))
                    n.Identifiers.Add(src.DatabaseNamePart.TSqlIdentifier(quoted));

                if (isNotBlank(src.SchemaNamePart))
                    n.Identifiers.Add(src.SchemaNamePart.TSqlIdentifier(quoted));

                if (isNotBlank(src.UnqualifiedName))
                    n.Identifiers.Add(src.UnqualifiedName.TSqlIdentifier(quoted));

                return n;
            }

        }

    }

}