create trigger [PF].[OnPlatformEntityDeleted] 
	on [PF].[PlatformEntityStore] after delete as

	set nocount on;

	insert [PF].[PlatformEntityChangeLog]
	(
		HostId,
		EntityName,
		ChangeType,
		EventTS
	)
	select
		HostId = [PF].[HostId](),
		EntityName,
		ChangeType = 'D',
		EventTS = getdate()
	from
		deleted



GO



	