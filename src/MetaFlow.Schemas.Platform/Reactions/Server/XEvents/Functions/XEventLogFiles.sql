create function [PF].[XEventLogFiles](@LogDir nvarchar(500)) 
	returns table as return
	select 
		[FilePath], 
		[IsDirectory], 
		[CreationTime], 
		[LastWriteTime], 
		[Size] 
	from 
		[SqlT].[Dir](@LogDir,'*.xel');
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[PF].[XEventLogFile]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'XEventLogFiles',
    @level2type = NULL,
    @level2name = NULL
GO


-- Example
-- 	declare @LogDir nvarchar(500) = 'Z:\unc\n00.Logs\';
-- select * from [PF].[XEventLogFiles](@LogDir) 





