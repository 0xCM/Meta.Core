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
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;

    public static partial class SqlTFactory
    {
        public static typeref ModelSequenceDataType(this TSql.CreateSequenceStatement src)
        {
            var dto = cast<TSql.DataTypeSequenceOption>(src.SequenceOptions.First(o => o.OptionKind == TSql.SequenceOptionKind.As));
            return dto.DataType.ModelReference(new SqlDataFacets(true));
        }

        [TSqlBuilder]
        public static typeref ModelReference(this TSql.DataTypeReference tsql, SqlDataFacets model)
        {

            return new typeref
                (
                    ReferencedType: SqlDataTypes.Find(tsql.Name.ToDataTypeName()),
                    Facets: model
                );
        }

        [TSqlBuilder]
        public static typeref ModelReference(this TSql.SqlDataTypeReference tsql, bool isNullable)
        {
            var len = default(int?);
            var precision = default(byte?);
            var scale = default(byte?);
            switch (tsql.SqlDataTypeOption)
            {

                case TSql.SqlDataTypeOption.Binary:
                case TSql.SqlDataTypeOption.VarBinary:
                case TSql.SqlDataTypeOption.VarChar:
                case TSql.SqlDataTypeOption.NVarChar:
                case TSql.SqlDataTypeOption.NChar:
                case TSql.SqlDataTypeOption.Char:
                    {
                        if (tsql.Parameters.Count != 1)
                            throw new NotSupportedException();

                        if (sx.MAX.IsMatch(tsql.Parameters[0].Value))
                            len = -1;
                        else
                            int.Parse(tsql.Parameters[0].Value);
                    }
                    break;
                case TSql.SqlDataTypeOption.Time:
                case TSql.SqlDataTypeOption.DateTime2:
                    scale = tsql.Parameters.Count == 1 ? Byte.Parse(tsql.Parameters[0].Value) : (byte)7;
                    break;
                case TSql.SqlDataTypeOption.Decimal:
                case TSql.SqlDataTypeOption.Numeric:
                    {
                        if (tsql.Parameters.Count != 2)
                            throw new NotSupportedException();

                        precision = Byte.Parse(tsql.Parameters[0].Value);
                        scale = Byte.Parse(tsql.Parameters[1].Value);
                    }
                    break;

            }

            return new typeref
                (
                    ReferencedType: SqlDataTypes.Find(tsql.Name.ToDataTypeName()),
                    IsNullable: isNullable,
                    MaxLength: len,
                    NumericPrecision: precision,
                    NumericScale: scale
                 );
        }

    }
}