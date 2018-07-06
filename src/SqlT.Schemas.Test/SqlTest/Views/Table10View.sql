create view [SqlTest].[Table10View] as
select 
	[Col02], 
	[Col03], 
	[Col04] 
from 
	[SqlTest].Table10 
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table10Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'View',
    @level1name = N'Table10View'
GO