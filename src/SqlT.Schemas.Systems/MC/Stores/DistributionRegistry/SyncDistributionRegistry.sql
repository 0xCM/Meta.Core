create procedure [MC].[SyncDistributionRegistry](@Distributions [MC].[DistributionMoniker] readonly) as

	merge into [MC].[DistributionRegistry] as Dst
		using @Distributions as Src on
			Dst.DistributionId = Src.DistributionId
		and Dst.ContentType = Src.ContentType
		
	when not matched then insert
	(

		DistributionId,
		ContentType,
		ContentVersion
	)
	values
	(
		Src.DistributionId,
		Src.ContentType,
		Src.ContentVersion
	)
	when matched and not exists
	(
		select

		Dst.ContentVersion

		intersect

		select

		Dst.ContentVersion
	)
	then update set
		Dst.ContentVersion= Src.ContentVersion,
		Dst.UpdateTS = getdate()
	when not matched by source then delete;


	



	
