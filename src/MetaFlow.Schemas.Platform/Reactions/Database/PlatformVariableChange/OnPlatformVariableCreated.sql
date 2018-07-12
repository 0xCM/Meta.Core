create trigger [PF].[OnPlatformVariableCreated] 
	on [PF].[PlatformVariableStore] after insert as
	
	set nocount on
			
	declare 
		@StoreName sysname = 'PlatformVariableStore', --(select object_name(parent_object_id) from sys.objects where parent_object_id = @@PROCID),
		@ChangeTS datetime2(0) = getdate(),
		@Changes [T0].[PlatformStoreChange],
		@ChangeType char(1) = 'I';
	
	insert @Changes
	(
	  StoreName,
	  SystemKey,
	  ChangeType,
	  ChangeTS
	)
	select
		@StoreName,
		SystemKey,
		@ChangeType,
		@ChangeTS
	from
		inserted
	
	    

	


