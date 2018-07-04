namespace types {
    
    export type native_data_type =
        | kw.BIT
        | kw.TINYINT
        | kw.SMALLINT
        | kw.INT
        | kw.BIGINT
        | kw.FLOAT
        | kw.REAL
        | kw.NUMERIC
        | kw.DECIMAL
        | kw.MONEY
        | kw.SMALLMONEY
        | kw.BINARY
        | kw.VARBINARY
        | kw.IMAGE
        | kw.TIMESTAMP
        | kw.ROWVERSION
        | kw.NVARCHAR
        | kw.VARCHAR
        | kw.CHAR
        | kw.NCHAR
        | kw.TEXT
        | kw.NTEXT
        | kw.XML
        | kw.TIME
        | kw.DATE
        | kw.DATETIME
        | kw.DATETIME2
        | kw.DATETIMEOFFSET
        | kw.SMALLDATETIME
        | kw.UNIQUEIDENTIFIER
        | kw.GEOMETRY
        | kw.GEOGRAPHY
        | kw.HIERARCHYID
        | kw.SQL_VARIANT
        | kw.SYSNAME

}