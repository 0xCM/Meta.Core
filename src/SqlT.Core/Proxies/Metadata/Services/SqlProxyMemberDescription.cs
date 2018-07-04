//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    using N = SqlT.Syntax.SqlDataTypeNames;

    /// <summary>
    /// Describes a proxy data member and the database element to which it corresponds/represents
    /// </summary>
    public class SqlProxyMemberDescription
    {

        public static SqlProxyMemberDescription FromProperty(PropertyInfo p)
        {
            var typeInfo = SqlDataTypeAttribute.ReadFrom(p)?.TypeDescription
                         ?? InferTypeDescription(p.PropertyType);
            return new SqlProxyMemberDescription(p, typeInfo);
        }

        public static IReadOnlyList<SqlProxyMemberDescription> FromType(Type t)
            => t.GetProperties().Select(FromProperty).ToList();

        static SqlTypeInfo InferTypeDescription(Type t)
        {
            var isNullable = t.IsNullableType();
            var nnType = t.GetNonNullableType();
            var typeName = String.Empty;
            byte? precision = null;
            byte? scale = null;
            int? length = null;
            switch (Type.GetTypeCode(nnType))
            {
                case TypeCode.Boolean:
                    typeName = N.BIT;
                    break;
                case TypeCode.Byte:
                    typeName = N.TINYINT;
                    break;
                case TypeCode.Char:
                    typeName = N.NCHAR;
                    break;
                case TypeCode.DateTime:
                    typeName = N.DATETIME2;
                    scale = 3;
                    break;
                case TypeCode.Decimal:
                    typeName = N.DECIMAL;
                    precision = 19;
                    scale = 4;
                    break;
                case TypeCode.Double:
                    typeName = N.FLOAT;
                    break;
                case TypeCode.Single:
                    typeName = N.REAL;
                    break;
                case TypeCode.SByte:
                case TypeCode.Int16:
                    typeName = N.SMALLINT;
                    break;
                case TypeCode.Int32:
                    typeName = N.INT;
                    break;
                case TypeCode.Int64:
                    typeName = N.BIGINT;
                    break;
                case TypeCode.Object:
                    typeName = N.SQL_VARIANT;
                    break;
                case TypeCode.String:
                    typeName = N.NVARCHAR;
                    length = -1;
                    break;
                case TypeCode.UInt16:
                    typeName = N.INT;
                    break;
                case TypeCode.UInt32:
                    typeName = N.BIGINT;
                    break;
                default:
                    typeName = N.SQL_VARIANT;
                    break;
            }
            return new SqlTypeInfo(typeName, typeName, isNullable, length, precision, scale);
        }


        public SqlProxyMemberDescription(MemberInfo Member, SqlTypeInfo Description)
        {
            this.Member = Member;
            this.Description = Description;
        }

        public MemberInfo Member { get; }

        public SqlTypeInfo Description { get; }

        public override string ToString()
            => $"{Member} : {Description}";
    }
}
