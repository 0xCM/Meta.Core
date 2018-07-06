CREATE SEQUENCE SqlTest.[Seq01]
		AS int
		START WITH 1
		INCREMENT BY 1
		NO MAXVALUE
		NO CYCLE
		CACHE 10
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SQL Test Table01',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'SEQUENCE',
    @level1name = N'Seq01',
    @level2type = NULL,
    @level2name = NULL
GO
