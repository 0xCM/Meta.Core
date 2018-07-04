//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using sxc = contracts;

    /// <summary>
    /// An immutable field set that presents the universe of native <see cref="sxc.ISqlDataType"/> types
    /// </summary>
    public sealed class SqlNativeTypes : TypedItemList<SqlNativeTypes, sxc.ISqlDataType>
    {
        public static readonly SqlUnknownType unknown = SqlUnknownType.Instance;

        public static readonly SqlFixedBinaryType binary = SqlFixedBinaryType.Instance;
        public static readonly SqlVarBinaryType varbinary = SqlVarBinaryType.Instance;
        public static readonly SqlImageType image = SqlImageType.Instance;
        public static readonly SqlRowVersionType rowversion = SqlRowVersionType.Instance;
        public static readonly SqlTimestampType timestamp = SqlTimestampType.Instance;

        public static readonly SqlCharType sqlchar = SqlCharType.Instance;
        public static readonly SqlNVarCharType nvarchar = SqlNVarCharType.Instance;
        public static readonly SqlNCharType nchar = SqlNCharType.Instance;
        public static readonly SqlNTextType ntext = SqlNTextType.Instance;
        public static readonly SqlDeprecatedTextType text = SqlDeprecatedTextType.Instance;
        public static readonly SqlSysNameType sysname = SqlSysNameType.Instance;
        public static readonly SqlVarCharType varchar = SqlVarCharType.Instance;
        public static readonly SqlXmlType xml = SqlXmlType.Instance;

        public static readonly SqlBigIntType bigint = SqlBigIntType.Instance;
        public static readonly SqlBitType bit = SqlBitType.Instance;
        public static readonly SqlSmallIntType smallint = SqlSmallIntType.Instance;
        public static readonly SqlIntType sqlint = SqlIntType.Instance;
        public static readonly SqlTinyIntType tinyint = SqlTinyIntType.Instance;

        public static readonly SqlDecimalType sqldecimal = SqlDecimalType.Instance;
        public static readonly SqlNumericType numeric = SqlNumericType.Instance;
        public static readonly SqlMoneyType money = SqlMoneyType.Instance;
        public static readonly SqlFloatType sqlfloat = SqlFloatType.Instance;
        public static readonly SqlRealType real = SqlRealType.Instance;
        public static readonly SqlSmallMoneyType smallmoney = SqlSmallMoneyType.Instance;

        public static readonly SqlDateType date = SqlDateType.Instance;
        public static readonly SqlDateTimeType datetime = SqlDateTimeType.Instance;
        public static readonly SqlDateTime2Type datetime2 = SqlDateTime2Type.Instance;
        public static readonly SqlDateTimeOffsetType datetimeoffset = SqlDateTimeOffsetType.Instance;
        public static readonly SqlSmallDateTimeType smalldatetime = SqlSmallDateTimeType.Instance;
        public static readonly SqlTimeType time = SqlTimeType.Instance;

        public static readonly SqlGeographyType geography = SqlGeographyType.Instance;
        public static readonly SqlGeometryType geometry = SqlGeometryType.Instance;
        public static readonly SqlHierarchyIdType hierarchy = SqlHierarchyIdType.Instance;

        public static readonly SqlVariantType sql_variant = SqlVariantType.Instance;
        public static readonly SqlUniqueIdentifierType uniqueidentifier = SqlUniqueIdentifierType.Instance;

    }


}
