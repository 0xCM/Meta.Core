create procedure [PF].[LogPlatformStoreChanges](@Changes [T0].[PlatformStoreChange] readonly) as
	set nocount on;

	declare 
		@EntryCount int = 0;
	
	insert [PF].[PlatformStoreChangeLog]
	(
		StoreName,
		SystemKey,
		ChangeType,
		ChangeTS
	)
	select 
		StoreName,
		SystemKey,
		ChangeType,
		ChangeTS
	from
		@Changes;

	set @EntryCount = @@ROWCOUNT;

	return @EntryCount;
