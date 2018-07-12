create trigger [PF].[OnPlatformEntityUpdated] 
	on [PF].[PlatformEntityStore] after update as

	set nocount on;

	declare 
		@UpdateTS datetime2(0) = getdate();

	update [PF].[PlatformEntityStore] set 
			UpdateTS = @UpdateTS
	from 
		[PF].[PlatformEntityStore] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey;

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
		ChangeType = 'U',
		EventTS = @UpdateTS
	from
		inserted



GO



	