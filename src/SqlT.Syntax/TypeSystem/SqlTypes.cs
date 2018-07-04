//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Models;

    using System.Linq;
    using System.Collections.Generic;

    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static SqlNativeTypeRefs;
    using static SqlKeyPhraseTypes;

    public static class SqlTypes
    {
        public static BIT bit(bool nullable = true)
            => new BIT(nullable);

        public static SMALLINT smallint(bool nullable = true)
            => new SMALLINT(nullable);

        public static INT sqlint(bool nullable = true)
            => new INT(nullable);

        public static INT sqlint(kwt.NULL nullable)
            => new INT(true);

        public static INT sqlint(NOTNULL nullable)
            => new INT(false);

        public static TINYINT tinyint(bool nullable)
            => new TINYINT(nullable);

        public static BIGINT bigint(bool nullable = true)
            => new BIGINT(nullable);

        public static BINARY binary(int length, bool nulable = true)
            => new BINARY(nulable, length);

        public static BINARY binary(int length, kwt.NULL nullable)
            => new BINARY(true, length);

        public static BINARY binary(int length, NOTNULL nullable)
            => new BINARY(false, length);

        public static VARBINARY varbinary(int length, bool nullable = true)
            => new VARBINARY(nullable, length);

        public static VARBINARY varbinary(int length, kwt.NULL nullable)
            => new VARBINARY(true, length);

        public static VARBINARY varbinary(int length, NOTNULL nullable)
            => new VARBINARY(false, length);

        public static ROWVERSION rowversion()
            => new ROWVERSION();

        public static CHAR sqlchar(int length, bool nullable = true)
            => new CHAR(nullable, length);

        public static CHAR sqlchar(int length, kwt.NULL nullable)
            => new CHAR(true, length);

        public static CHAR sqlchar(int length, NOTNULL nullable)
            => new CHAR(false, length);

        public static NVARCHAR nvarchar(int length, bool nullable = true)
            => new NVARCHAR(nullable, length);

        public static NVARCHAR nvarchar(int length, kwt.NULL nullable)
            => new NVARCHAR(true, length);

        public static NVARCHAR nvarchar(int length, NOTNULL nullable)
            => new NVARCHAR(false, length);

        public static NVARCHAR nvarchar(kwt.MAX MAX, bool nullable = true)
            => new NVARCHAR(nullable, true);

        public static NCHAR nchar(int length, bool nullable = true)
            => new NCHAR(nullable, length);

        public static NCHAR nchar(int length, kwt.NULL NULL)
            => new NCHAR(true, length);

        public static NCHAR nchar(int length, NOTNULL NOTNULL)
            => new NCHAR(false, length);

        public static NVARCHAR sysname()
            => new NVARCHAR(false, 128);

        public static VARCHAR varchar(int length, bool nullable = true)
            => new VARCHAR(nullable, length);

        public static VARCHAR varchar(int length, kwt.NULL nullable)
            => new VARCHAR(true, length);

        public static VARCHAR varchar(int length, NOTNULL nullable)
            => new VARCHAR(false, length);

        public static VARCHAR varchar(kwt.MAX MAX, bool nullable = true)
            => new VARCHAR(nullable, true);

        public static XML xml(bool nullable = true)
            => new XML(nullable);

        public static XML xml(NOTNULL nullable)
            => new XML(false);

        public static XML xml(kwt.NULL nullable)
            => new XML(true);

        public static DECIMAL sqldecimal(byte precision, byte scale, bool nullable = true)
            => new DECIMAL(nullable, precision, scale);

        public static DECIMAL sqldecimal(byte precision, byte scale, kwt.NULL NULL)
            => new DECIMAL(true, precision, scale);

        public static DECIMAL sqldecimal(byte precision, byte scale, NOTNULL NOTNULL)
            => new DECIMAL(false, precision, scale);
        
        public static MONEY money(bool nullable = true)
            => new MONEY(nullable);

        public static MONEY money(kwt.NULL nullable)
            => new MONEY(true);

        public static MONEY money(NOTNULL nullable)
            => new MONEY(true);

        public static FLOAT sqlfloat(bool nullable = true)
            => new FLOAT(nullable);

        public static DATE date(bool nullable = true)
            => new DATE(nullable);

        public static DATETIME datetime(bool nullable)
            => new DATETIME(nullable);

        public static DATETIME2 datetime2(byte scale, bool nullable = true )
            => new DATETIME2(nullable, scale);

        public static DATETIME2 datetime2(byte scale, NOTNULL nullable)
            => new DATETIME2(false, scale);

        public static DATETIME2 datetime2(byte scale, kwt.NULL nullable)
            => new DATETIME2(true, scale);

        public static DATETIMEOFFSET datetimeoffset(bool nullable = true)
            => new DATETIMEOFFSET(nullable);

        public static SMALLDATETIME smalldatetime(bool nullable = true)
            => new SMALLDATETIME(nullable);

        public static TIME time(byte scale, bool nullable = true)
            => new TIME(nullable, scale);

        public static TIME time(byte scale, kwt.NULL nullable)
            => new TIME(true, scale);

        public static TIME time(byte scale, NOTNULL nullable)
            => new TIME(false, scale);

        public static GEOGRAPHY geography(bool nullable = true)
            => new GEOGRAPHY(nullable);

        public static GEOMETRY geometry(bool nullable)
            => new GEOMETRY(nullable);

        public static SQL_VARIANT sql_variant(bool nullable = true)
            => new SQL_VARIANT(nullable);

        public static UNIQUEIDENTIFIER uniqueidentifier(bool nullable = true)
            => new UNIQUEIDENTIFIER(nullable);

        public static UNIQUEIDENTIFIER uniqueidentifier(kwt.NULL nullable)
            => new UNIQUEIDENTIFIER(true);

        public static UNIQUEIDENTIFIER uniqueidentifier(NOTNULL nullable)
            => new UNIQUEIDENTIFIER(false);
    }

}