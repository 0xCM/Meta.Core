CREATE TYPE [SqlTest].[TableType01] AS TABLE
(
	TTCol01 INT NOT NULL,
	TTCol02 decimal(19,4) not null,
	TTCol03 bigint not null
	
)
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[TableType01]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TYPE',
    @level1name = N'TableType01',
    @level2type = NULL,
    @level2name = NULL
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[TableType01].[TTCol01]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TYPE',
    @level1name = N'TableType01',
    @level2type = N'COLUMN',
    @level2name = N'TTCol01'
GO
