//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using Meta.Core;

    public class SqlDataTypeNames : TypedItemList<SqlDataTypeNames, string>
    {
        public const string BIGINT = "bigint";
        public const string BIT = "bit";
        public const string SMALLINT = "smallint";
        public const string INT = "int";
        public const string TINYINT = "tinyint";

        public const string BINARY = "binary";
        public const string VARBINARY = "varbinary";
        public const string IMAGE = "image";

        public const string CHAR = "char";
        public const string NVARCHAR = "nvarchar";
        public const string NCHAR = "nchar";
        public const string NTEXT = "ntext";
        public const string TEXT = "text";
        public const string SYSNAME = "sysname";
        public const string VARCHAR = "varchar";

        public const string DECIMAL = "decimal";
        public const string NUMERIC = "numeric";
        public const string MONEY = "money";
        public const string FLOAT = "float";
        public const string REAL = "real";
        public const string SMALLMONEY = "smallmoney";

        public const string DATE = "date";
        public const string DATETIME = "datetime";
        public const string DATETIME2 = "datetime2";
        public const string DATETIMEOFFSET = "datetimeoffset";
        public const string SMALLDATETIME = "smalldatetime";
        public const string TIME = "time";

        public const string ROWVERSION = "rowversion";
        public const string TIMESTAMP = "timestamp";

        public const string SQL_VARIANT = "sql_variant";
        public const string UNIQUEIDENTIFIER = "uniqueidentifier";
        public const string XML = "xml";

        public const string GEOGRAPHY = "geography";
        public const string GEOMETRY = "geometry";
        public const string HIERARCHYID = "hierarchyid";

    }
}
