create procedure [PF].[SyncDistributionRegistry](@Entries [T0].[DistributionDescription] readonly) as
	merge into [PF].[DistributionRegistry] as Dst 
		using @Entries as Src 
			on Src.DistributionId = Dst.DistributionId		
	when not matched then insert
	(
		DistributionId,
		[Description]
	)
	values
	(
		Src.DistributionId,
		Src.[Description]
	)
	when matched and not exists 
	(
		select 
			Src.[Description]

		intersect

		select 
			Dst.[Description]
	
	)
	then update set
		Dst.[Description] = Src.[Description]
	when not matched by source then delete;




	
