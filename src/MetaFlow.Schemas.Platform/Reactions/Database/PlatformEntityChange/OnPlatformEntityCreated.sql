create trigger [PF].[OnPlatformEntityCreated] 
	on [PF].[PlatformEntityStore] after insert as

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
		ChangeType = 'I',
		EventTS = CreateTS
	from
		inserted
