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
    using static metacore;    
    using sxc = SqlT.Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {

        [TSqlBuilder]
        public static TSql.DataTypeReference TSqlReference(this sxc.type_ref subject)
        {
            if (subject.is_table_type)
            {
                return new TSql.UserDataTypeReference
                {
                    Name = subject.type_name.TSqlSchemaObjectName()
                };

            }
            else
            {
                var typeref = subject as sxc.data_type_ref;
                var tql = new TSql.SqlDataTypeReference
                {
                    Name = subject.type_name.TSqlSchemaObjectName(),
                    SqlDataTypeOption = typeref.TSqlDataTypeOption(),
                };

                if (typeref.length != null)
                {
                    tql.Parameters.Add(new TSql.IntegerLiteral() { Value = typeref.length.ToString() });
                }
                else
                {
                    if (typeref.precision != null && typeref.scale != null)
                    {
                        tql.Parameters.Add(new TSql.IntegerLiteral() { Value = typeref.precision.ToString() });
                        tql.Parameters.Add(new TSql.IntegerLiteral() { Value = typeref.scale.ToString() });
                    }
                    else if(typeref.scale != null)
                    {
                        tql.Parameters.Add(new TSql.IntegerLiteral() { Value = typeref.scale.ToString() });
                    }
                    else if(typeref.precision != null)
                    {
                        tql.Parameters.Add(new TSql.IntegerLiteral() { Value = typeref.precision.ToString() });
                    }
                }
                return tql;
            }
        }

    }
}