namespace types {

    export type variant_base_type =
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
        | kw.NVARCHAR
        | kw.VARCHAR
        | kw.CHAR
        | kw.NCHAR
        | kw.TIME
        | kw.DATE
        | kw.DATETIME
        | kw.DATETIME2
        | kw.DATETIMEOFFSET
        | kw.SMALLDATETIME
        | kw.UNIQUEIDENTIFIER
}
