create function [SqlTest].[Table10Select](@MinDate date, @MaxDate date) returns table as return
select 
	[Col02], 
	[Col03], 
	[Col04] 
from 
	[SqlTest].Table10 
where 
	Col04 between @MinDate and @MaxDate
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table10Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Function',
    @level1name = N'Table10Select'
GO