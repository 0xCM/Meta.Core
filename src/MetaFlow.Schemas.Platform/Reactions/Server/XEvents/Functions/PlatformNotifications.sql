/* Example:
declare 
	@SrcFile nvarchar(250) = 'C:\SqlData\Disk00\MSSQL14.MSSQLSERVER\MSSQL\Log\PlatformNotifications_0_131550729980750000.xel',
	@MaxCount int = 500,
	@MinOffset int = 0;

select * from [PF].[ShredXEventFileData](@SrcFile,@MaxCount,@MinOffset)
*/
create function [PF].[PlatformNotifications](@SrcFile nvarchar(500), @MaxCount int = 500, @MinOffset int = 0) returns table as return
	with RBD as
	(
		select 
			[name], 
			target_name, 
			target_data = cast(xet.target_data as xml)
		from 
			sys.dm_xe_session_targets xet
				inner join sys.dm_xe_sessions xe
					on xe.[address] = xet.event_session_address
		where 
			xe.[name] = 'PlatformNotifications'
		and xet.[target_name] = 'ring_buffer'
	),
	EFD as
	(
		select 
			d.* 
		from 
			[PF].[XEventDataBlocks](@SrcFile, @MaxCount, @MinOffset)  d

		

	)
	SELECT 
		[timestamp] = xed.event_data.value('(@timestamp)[1]', 'datetime2'),
		[message] = xed.event_data.value('(data[@name="message"]/value)[1]', 'nvarchar(500)'), 
		[error_number] = xed.event_data.value('(data[@name="error_number"]/value)[1]', 'int'), 
		[severity] = xed.event_data.value('(data[@name="severity"]/value)[1]', 'int'),
		client_hostname = xed.event_data.value('(action[@name="client_hostname"]/value)[1]', 'nvarchar(75)'),
		client_app_name = xed.event_data.value('(action[@name="client_app_name"]/value)[1]', 'nvarchar(75)'),
		username = xed.event_data.value('(action[@name="username"]/value)[1]', 'nvarchar(128)')

	FROM EFD
		cross apply event_data.nodes('//event') AS xed (event_data)


GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[PF].[PlatformNotification]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'PlatformNotifications',
    @level2type = NULL,
    @level2name = NULL
GO
