create trigger [PF].[OnPlatformVariableDeleted] 
	on [PF].[PlatformVariableStore] after delete as
	
	set nocount on
			
	declare 
		@StoreName sysname = (select object_name(parent_object_id) from sys.objects where parent_object_id = @@PROCID),
		@ChangeTS datetime2(0) = getdate(),
		@Changes [T0].[PlatformStoreChange],
		@ChangeType char(1) = 'D';
	
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
	
	    

	


