CREATE SEQUENCE [SqlTest].[Seq10]
		AS BIGINT
		START WITH 25
		INCREMENT BY 50
		NO MAXVALUE
		NO CYCLE
		CACHE 100
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Generates keys for [SqlTest].[Table10]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'SEQUENCE',
    @level1name = N'Seq10',
    @level2type = NULL,
    @level2name = NULL
GO
