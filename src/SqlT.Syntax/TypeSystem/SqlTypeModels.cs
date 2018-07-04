//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using sxc = contracts;
    using static data_types;
    using sx = SqlSyntax;

    using SqlT.Core;

    using static SqlTypeDescriptions;


    public sealed class SqlBigIntType : integer<SqlBigIntType>, sxc.native_type
    {
        public static readonly SqlBigIntType Instance = new SqlBigIntType();

        SqlBigIntType()
            : base(sx.BIGINT.KeywordName)
        {

        }
    }

    public sealed class SqlBitType : integer<SqlBitType>, sxc.native_type
    {
        public static readonly SqlBitType Instance = new SqlBitType();

        SqlBitType()
            : base(sx.BIT.KeywordName)
        {

        }
    }

    public sealed class SqlCharType : fixed_text<SqlCharType>, sxc.native_type
    {
        public static readonly SqlCharType Instance = new SqlCharType();

        SqlCharType()
            : base(sx.CHAR.KeywordName)
        {

        }

        public override bool IsAnsiTextType
            => true;

        public override bool IsUnicodeTextType
            => false;

        public override bool CanSpecifyLength
            => true;

    }

    public sealed class SqlDateTime2Type : chronology<SqlDateTime2Type>, sxc.native_type
    {
        public static readonly SqlDateTime2Type Instance = new SqlDateTime2Type();

        SqlDateTime2Type()
            : base(sx.DATETIME2.KeywordName)
        {

        }

        public override bool CanSpecifyScale
            => true;
    }

    public sealed class SqlDateTimeOffsetType : chronology<SqlDateTimeOffsetType>, sxc.native_type
    {
        public static readonly SqlDateTimeOffsetType Instance = new SqlDateTimeOffsetType();

        SqlDateTimeOffsetType()
            : base(sx.DATETIMEOFFSET.KeywordName)
        {

        }

        public override bool CanSpecifyScale
            => false;
    }

    public sealed class SqlDateTimeType : chronology<SqlDateTimeType>, sxc.native_type
    {
        public static readonly SqlDateTimeType Instance = new SqlDateTimeType();

        SqlDateTimeType()
            : base(sx.DATETIME.KeywordName)
        {

        }

        public override bool CanSpecifyScale
            => false;


    }

    public sealed class SqlDateType : chronology<SqlDateType>, sxc.native_type
    {
        public static readonly SqlDateType Instance = new SqlDateType();


        SqlDateType()
            : base(sx.DATE.KeywordName)
        {

        }

        public override bool CanSpecifyScale
            => false;

    }

    public sealed class SqlDecimalType : precise_fractional<SqlDecimalType>, sxc.native_type
    {

        public static readonly SqlDecimalType Instance = new SqlDecimalType();

        SqlDecimalType()
            : base(sx.DECIMAL.KeywordName)
        {

        }

        public override bool CanSpecifyPrecision
            => true;

        public override bool CanSpecifyScale
            => true;
    }


    public sealed class SqlFixedBinaryType : binary<SqlFixedBinaryType>, sxc.native_type, sxc.fixed_binary_type
    {
        public static readonly SqlFixedBinaryType Instance = new SqlFixedBinaryType();

        SqlFixedBinaryType()
            : base(sx.BINARY.KeywordName)
        {

        }

        public override bool CanSpecifyLength
            => true;
    }

    public sealed class SqlFloatType : floating<SqlFloatType>, sxc.native_type
    {
        public static readonly SqlFloatType Instance = new SqlFloatType();

        SqlFloatType()
            : base(sx.FLOAT.KeywordName)
        {

        }
    }


    public sealed class SqlGeographyType : clr_type<SqlGeographyType>, sxc.native_type
    {
        public static readonly SqlGeographyType Instance = new SqlGeographyType();

        SqlGeographyType()
            : base(sx.GEOGRAPHY.KeywordName)
        { }


    }

    public sealed class SqlGeometryType : clr_type<SqlGeometryType>, sxc.native_type
    {
        public static readonly SqlGeometryType Instance = new SqlGeometryType();


        SqlGeometryType()
            : base(sx.GEOMETRY.KeywordName)
        { }


    }

    public class SqlRealType : floating<SqlRealType>, sxc.native_type
    {

        public static readonly SqlRealType Instance = new SqlRealType();

        SqlRealType()
            : base(sx.REAL.KeywordName)
        {

        }
    }

    public sealed class SqlHierarchyIdType : clr_type<SqlHierarchyIdType>, sxc.native_type
    {
        public static readonly SqlHierarchyIdType Instance = new SqlHierarchyIdType();

        SqlHierarchyIdType()
            : base(sx.HIERARCHYID.KeywordName)
        { }

    }

    public sealed class SqlUniqueIdentifierType : data_type<SqlUniqueIdentifierType>, sxc.native_type
    {
        public static readonly SqlUniqueIdentifierType Instance = new SqlUniqueIdentifierType();

        SqlUniqueIdentifierType()
            : base(sx.UNIQUEIDENTIFIER.KeywordName, DataTypeCategory.Guid)
        { }

    }

    public sealed class SqlTinyIntType : integer<SqlTinyIntType>, sxc.native_type
    {

        public static readonly SqlTinyIntType Instance = new SqlTinyIntType();

        SqlTinyIntType()
            : base(sx.TINYINT.KeywordName)
        {

        }

    }

    public sealed class SqlTimeType : chronology<SqlTimeType>, sxc.native_type
    {
        SqlTimeType()
            : base(sx.TIME.KeywordName)
        {

        }

        public static readonly SqlTimeType Instance = new SqlTimeType();

        public override bool CanSpecifyScale
            => true;
    }

    public sealed class SqlIntType : integer<SqlIntType>, sxc.native_type
    {

        public static readonly SqlIntType Instance = new SqlIntType();

        SqlIntType()
            : base(sx.INT.KeywordName)
        {

        }
    }

    public sealed class SqlNumericType : precise_fractional<SqlNumericType>, sxc.native_type
    {
        public static readonly SqlNumericType Instance = new SqlNumericType();

        SqlNumericType()
            : base(NUMERIC.TypeName.ToLower())
        {

        }

        public override bool CanSpecifyPrecision
            => true;

        public override bool CanSpecifyScale
            => true;

    }


    public sealed class SqlSmallIntType : integer<SqlSmallIntType>, sxc.native_type
    {

        public static readonly SqlSmallIntType Instance = new SqlSmallIntType();

        SqlSmallIntType()
            : base(sx.SMALLINT.KeywordName)
        {

        }

    }

    public class SqlNCharType : fixed_text<SqlNCharType>, sxc.native_type
    {
        public static readonly SqlNCharType Instance = new SqlNCharType();

        SqlNCharType()
            : base(sx.NCHAR.KeywordName)
        {

        }

        public override bool IsAnsiTextType
            => false;

        public override bool IsUnicodeTextType
            => true;
    }

    public sealed class SqlNVarCharType : text<SqlNVarCharType>, sxc.native_type
    {
        public static readonly SqlNVarCharType Instance = new SqlNVarCharType();

        SqlNVarCharType()
            : base(NVARCHAR.TypeName.ToLower())
        {

        }

        public override bool IsAnsiTextType
            => false;

        public override bool IsUnicodeTextType
            => true;

        public override bool IsFixedLength
            => false;

        public override bool CanSpecifyLength
            => true;
    }

    public sealed class SqlRowVersionType : binary<SqlRowVersionType>, sxc.native_type
    {

        public static readonly SqlRowVersionType Instance = new SqlRowVersionType();

        SqlRowVersionType()
            : base(sx.ROWVERSION.KeywordName)
        { }


        public override bool CanSpecifyNullability
            => false;

        public override bool CanSpecifyLength
            => false;
    }

    public sealed class SqlSmallDateTimeType : chronology<SqlSmallDateTimeType>, sxc.native_type
    {
        public static readonly SqlSmallDateTimeType Instance = new SqlSmallDateTimeType();

        SqlSmallDateTimeType()
            : base(sx.SMALLDATETIME.KeywordName)
        {

        }

        public override bool CanSpecifyScale
            => false;
    }

    public sealed class SqlSmallMoneyType : currency<SqlSmallMoneyType>, sxc.native_type
    {
        public static readonly SqlSmallMoneyType Instance = new SqlSmallMoneyType();

        SqlSmallMoneyType()
            : base(sx.SMALLMONEY.KeywordName)
        {

        }
    }

    public sealed class SqlMoneyType : currency<SqlMoneyType>, sxc.native_type
    {
        public static readonly SqlMoneyType Instance = new SqlMoneyType();

        SqlMoneyType()
            : base(sx.MONEY.KeywordName)
        {

        }


    }

    public sealed class SqlVarCharType : text<SqlVarCharType>, sxc.native_type
    {
        public static readonly SqlVarCharType Instance = new SqlVarCharType();

        SqlVarCharType()
            : base(sx.VARCHAR.KeywordName)
        {

        }

        public override bool IsAnsiTextType
            => true;

        public override bool IsUnicodeTextType
            => false;

        public override bool CanSpecifyLength
            => true;

        public override bool IsFixedLength
            => false;

    }

    public sealed class SqlSysNameType : text<SqlSysNameType>, sxc.native_type
    {
        public static readonly SqlSysNameType Instance = new SqlSysNameType();

        SqlSysNameType()
            : base(sx.SYSNAME.KeywordName)
        { }

        public override bool IsFixedLength
            => false;

        public override bool CanSpecifyLength
            => false;

        public override bool CanSpecifyNullability
            => false;
    }


    public sealed class SqlVarBinaryType : binary<SqlVarBinaryType>, sxc.native_type
    {
        public static readonly SqlVarBinaryType Instance = new SqlVarBinaryType();

        SqlVarBinaryType()
            : base(sx.VARBINARY.KeywordName)
        {

        }

        ModelOption<sxc.native_type> sxc.ISqlDataType.BaseType
            => (Instance as sxc.native_type).BaseType;


        public override bool CanSpecifyLength
            => true;
    }

    public sealed class SqlUnknownType : data_type<SqlUnknownType>
    {

        public static readonly SqlUnknownType Instance = new SqlUnknownType();


        SqlUnknownType()
            : base(SqlDataTypeName.Empty, DataTypeCategory.None)
        {

        }
    }

    public sealed class SqlTimestampType : binary<SqlTimestampType>, sxc.native_type
    {
        public static readonly SqlTimestampType Instance = new SqlTimestampType();

        SqlTimestampType()
            : base(sx.TIMESTAMP.KeywordName)
        { }

        public override bool CanSpecifyNullability
            => false;

        public override bool CanSpecifyLength
            => false;
    }

    public sealed class SqlXmlType : text<SqlXmlType>, sxc.native_type 
    {
        public static readonly SqlXmlType Instance = new SqlXmlType();

        SqlXmlType()
            : base(sx.XML.KeywordName)
        { }

        public override bool IsFixedLength
            => false;

        public override bool CanSpecifyLength
            => false;
    }

    public sealed class SqlVariantType : data_type<SqlVariantType>, sxc.native_type
    {
        public static readonly SqlVariantType Instance = new SqlVariantType();

        SqlVariantType()
            : base(sx.SQL_VARIANT.KeywordName, DataTypeCategory.Variant)
        {

        }

        public override bool CanSpecifyLength
            => false;

        ModelOption<sxc.native_type> sxc.ISqlDataType.BaseType
            => (Instance as sxc.native_type).BaseType;
    }

    public sealed class SqlDeprecatedTextType : text<SqlDeprecatedTextType>, sxc.native_type
    {
        public static readonly SqlDeprecatedTextType Instance = new SqlDeprecatedTextType();

        SqlDeprecatedTextType()
            : base(sx.TEXT.KeywordName)
        {

        }
        public override bool IsFixedLength
            => false;

        public override bool CanSpecifyLength
            => false;

        public override bool IsAnsiTextType
            => true;

        public override bool IsUnicodeTextType
            => false;
    }

    public sealed class SqlImageType : binary<SqlImageType>, sxc.native_type
    {
        public static readonly SqlImageType Instance = new SqlImageType();

        public override bool CanSpecifyLength
            => false;
        SqlImageType()
            : base(sx.IMAGE.KeywordName)
        {

        }
    }

    public sealed class SqlNTextType : text<SqlNTextType>, sxc.native_type
    {
        public static readonly SqlNTextType Instance = new SqlNTextType();


        SqlNTextType()
            : base(NTEXT.TypeName.ToLower())
        {

        }

        public override bool IsFixedLength
            => false;

        public override bool CanSpecifyLength
            => false;

        public override bool IsAnsiTextType
            => false;

        public override bool IsUnicodeTextType
            => true;
    }
}