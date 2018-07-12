create function [PF].[ArchivedPlatformNotifications](@SrcNodeId varchar(10), @MaxLogCount int = 1) returns table as return
	with LogFiles as
	( 
		select top(@MaxLogCount)
			f.FilePath,
			f.Size,
			f.CreationTime,
			f.LastWriteTime 
		from 
			[PF].[XEventLogFiles](concat('Z:\logs\',@SrcNodeId)) f
		order by 
			f.CreationTime
	)
	select 
		SrcFile = f.FilePath,
		SrcFileCreateTS = f.CreationTime,
		SrcFileWriteTS = f.CreationTime,
		LogTS = x.[timestamp], 
		Severity = x.severity, 
		MsgId = x.[error_number],
		Msg = x.[message],
		ClientHost = x.client_hostname,
		ClientApp = x.client_app_name,
		UserName = x.username
	from 
		LogFiles f 
			cross apply [PF].[PlatformNotifications](f.FilePath, 50000,0) x

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[PF].[ArchivedPlatformNotification]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'ArchivedPlatformNotifications',
    @level2type = NULL,
    @level2name = NULL
GO
