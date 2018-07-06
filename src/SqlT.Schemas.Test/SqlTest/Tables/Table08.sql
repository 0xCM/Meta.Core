CREATE TABLE [SqlTest].[Table08]
(
	Col01 INT NOT NULL PRIMARY KEY,
	Col02 nvarchar(50) not null,
	Col03 smallint not null
)
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table08Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table08',
    @level2type = NULL,
    @level2name = NULL
GO
