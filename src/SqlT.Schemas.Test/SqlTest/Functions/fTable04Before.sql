create function SqlTest.fTable04Before (@StartDate date) returns table as return
	select 
		[t].[Id], 
		[t].[Code], 
		[t].[StartDate], 
		[t].[EndDate] 
	from 
		SqlTest.Table04 t where t.StartDate <= @StartDate
GO


EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table04Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Function',
    @level1name = N'fTable04Before'
GO