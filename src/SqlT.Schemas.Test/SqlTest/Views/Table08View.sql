CREATE VIEW [SqlTest].[Table08View]
	AS SELECT 
		[Col01], 
		[Col02], 
		[Col03] 
	FROM 
		Table08
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Table 08 View',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'VIEW',
    @level1name = N'Table08View',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table08Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'VIEW',
    @level1name = N'Table08View',
    @level2type = NULL,
    @level2name = NULL
GO
