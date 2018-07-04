//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using SqlT.Models;

    
    using sxc = contracts;

    /// <summary>
    /// Defines structal model for native type references
    /// </summary>
    public static class SqlNativeTypeRefs
    {

        public sealed class BIGINT : native_typeref<SqlBigIntType>
        {

            internal BIGINT(bool nullable)
                : base(SqlBigIntType.Instance, nullable)
            { }
        }

        public sealed class BINARY : native_typeref<SqlFixedBinaryType>
        {
            internal BINARY(bool isNullable, int? Length = null)
                : base(SqlFixedBinaryType.Instance, isNullable, MaxLength: Length)
            { }
        }

        public sealed class BIT : native_typeref<SqlBitType>
        {
            internal BIT(bool nullable)
                : base(SqlBitType.Instance, nullable)
            { }
        }

        public sealed class CHAR : native_typeref<SqlCharType>
        {
            internal CHAR(bool isNullable, int? Length = null)
                : base(SqlCharType.Instance, isNullable, MaxLength: Length)
            { }
        }

        public sealed class DATETIME2 : native_typeref<SqlDateTime2Type>
        {
            internal DATETIME2(bool nullable, byte? scale)
                : base(SqlDateTime2Type.Instance, nullable, scale)
            { }
        }

        public sealed class DATETIMEOFFSET : native_typeref<SqlDateTimeOffsetType>
        {
            internal DATETIMEOFFSET(bool nullable)
                : base(SqlDateTimeOffsetType.Instance, nullable)
            { }
        }

        public sealed class DATETIME : native_typeref<SqlDateTimeOffsetType>
        {
            internal DATETIME(bool nullable)
                : base(SqlDateTimeOffsetType.Instance, nullable)
            { }
        }

        public sealed class DATE : native_typeref<SqlDateType>
        {
            internal DATE(bool nullable)
                : base(SqlDateType.Instance, nullable)
            { }
        }

        public sealed class DECIMAL : native_typeref<SqlDecimalType>
        {
            internal DECIMAL(bool nullable, byte? precision, byte? scale)
                : base(SqlDecimalType.Instance, IsNullable: nullable, NumericPrecision: precision, NumericScale: scale)
            { }
        }

        public sealed class SqlDeprecatedTextRef : native_typeref<SqlDeprecatedTextType>
        {
            internal SqlDeprecatedTextRef(bool isNullable)
                : base(SqlDeprecatedTextType.Instance, isNullable)
            { }
        }

        public sealed class FLOAT : native_typeref<SqlFloatType>
        {
            internal FLOAT(bool nullable)
                : base(SqlFloatType.Instance, nullable)
            { }
        }

        public sealed class INT : native_typeref<SqlIntType>
        {
            internal INT(bool nullable)
                : base(SqlIntType.Instance, nullable)
            { }

        }

        public sealed class GEOGRAPHY : native_typeref<SqlGeographyType>
        {
            internal GEOGRAPHY(bool nullable)
                : base(SqlGeographyType.Instance, nullable)
            { }
        }

        public sealed class MONEY : native_typeref<SqlMoneyType>
        {
            internal MONEY(bool nullable)
                : base(SqlMoneyType.Instance, nullable)
            { }
        }

        public sealed class TIME : native_typeref<SqlTimeType>
        {
            internal TIME(bool nullable, byte? scale)
                : base(SqlTimeType.Instance, nullable, scale)
            { }
        }

        public sealed class UNIQUEIDENTIFIER : native_typeref<SqlUniqueIdentifierType>
        {
            internal UNIQUEIDENTIFIER(bool nullable)
                : base(SqlUniqueIdentifierType.Instance, nullable)
            { }

        }

        public sealed class NTEXT : native_typeref<SqlNTextType>
        {
            internal NTEXT(bool nullable)
                : base(SqlNTextType.Instance, nullable)
            { }
        }

        public sealed class NUMERIC : native_typeref<SqlNumericType>
        {
            internal NUMERIC(bool nullable, byte? precision, byte? scale)
                : base(SqlNumericType.Instance, IsNullable: nullable, NumericPrecision: precision, NumericScale: scale)
            { }
        }

        public sealed class SYSNAME : native_typeref<SqlSysNameType>
        {
            internal SYSNAME()
                : base(SqlSysNameType.Instance)
            { }
        }

        public sealed class GEOMETRY : native_typeref<SqlGeometryType>
        {
            internal GEOMETRY(bool nullable)
                : base(SqlGeometryType.Instance, nullable)
            { }
        }

        public sealed class SMALLINT : native_typeref<SqlSmallIntType>
        {
            internal SMALLINT(bool nullable)
                : base(SqlSmallIntType.Instance, nullable)
            { }
        }

        public sealed class HIERARCHYID : native_typeref<SqlHierarchyIdType>
        {
            internal HIERARCHYID(bool nullable)
                : base(SqlHierarchyIdType.Instance, nullable)
            { }
        }

        public sealed class TINYINT : native_typeref<SqlTinyIntType>
        {
            internal TINYINT(bool nullable)
                : base(SqlTinyIntType.Instance, nullable)
            { }
        }

        public sealed class NVARCHAR : native_typeref<SqlNVarCharType>
        {
            internal NVARCHAR(bool nullable, int? length)
                : base(SqlNVarCharType.Instance, nullable, length)
            { }

            internal NVARCHAR(bool nullable, bool MAX)
                : base(SqlNVarCharType.Instance, nullable, null)
            { }
        }

        public sealed class REAL : native_typeref<SqlRealType>
        {
            internal REAL()
                : base(SqlRealType.Instance)
            { }
        }

        public sealed class ROWVERSION : native_typeref<SqlRowVersionType>
        {
            internal ROWVERSION()
                : base(SqlRowVersionType.Instance)
            { }
        }
        public sealed class NCHAR : native_typeref<SqlNCharType>
        {
            internal NCHAR(bool nullable, int? length)
                : base(SqlNCharType.Instance, nullable, length)
            { }
        }
        public sealed class SMALLDATETIME : native_typeref<SqlSmallDateTimeType>
        {
            internal SMALLDATETIME(bool nullable)
                : base(SqlSmallDateTimeType.Instance, nullable)
            { }
        }


        public sealed class VARCHAR : native_typeref<SqlVarCharType>
        {
            internal VARCHAR(bool nullable, int? length)
                : base(SqlVarCharType.Instance, nullable, length)
            { }

            internal VARCHAR(bool nullable, bool MAX)
                : base(SqlVarCharType.Instance, nullable, null)
            { }

        }

        public sealed class XML : native_typeref<SqlXmlType>
        {
            internal XML(bool nullable)
                : base(SqlXmlType.Instance, nullable)
            { }
        }

        public sealed class SQL_VARIANT : native_typeref<SqlVariantType>
        {
            internal SQL_VARIANT(bool nullable)
                : base(SqlVariantType.Instance, nullable)
            { }
        }

        public sealed class SMALLMONEY : native_typeref<SqlSmallMoneyType>
        {
            internal SMALLMONEY()
                : base(SqlSmallMoneyType.Instance)
            { }
        }

        public sealed class SqlTimestampRef : native_typeref<SqlTimestampType>
        {
            internal SqlTimestampRef()
                : base(SqlTimestampType.Instance)
            { }
        }

        public sealed class VARBINARY : native_typeref<SqlVarBinaryType>
        {
            internal VARBINARY(bool nullable, int? length)
                : base(SqlVarBinaryType.Instance, nullable, length)
            { }
        }

    }
}