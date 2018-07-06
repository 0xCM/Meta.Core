CREATE TABLE [SqlTest].[Table0D]
(
	Col01 INT NOT NULL,
	Col02 decimal(19,4) not null,
	Col03 bigint not null
	constraint PK_Table0D primary key(Col01)
)
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[Table0D]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0D',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[Table0D].[Col01]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0D',
    @level2type = N'COLUMN',
    @level2name = N'Col01'
GO
