create procedure [SqlTest].[pTable0CSelect](@TopCount int) as
	select top(@TopCount) 
		t.Col01,
		t.Col02,
		t.Col03
	from [SqlTest].Table0C t
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table0CRecord]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Procedure',
    @level1name = N'pTable0CSelect'
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[pTable0CSelect]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Procedure',
    @level1name = N'pTable0CSelect'
GO