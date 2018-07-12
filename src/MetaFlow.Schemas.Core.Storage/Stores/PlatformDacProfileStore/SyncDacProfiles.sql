create procedure [PF].[SyncDacProfiles](@Profiles [T0].[DacProfileDefinition] readonly) as
	
	merge into [PF].[DacProfileStore] as Dst
		using @Profiles as Src on
			Dst.ProfileFileName = Src.ProfileFileName
	when not matched then insert
	(

		ProfileFileName,
		SourcePackage,
		TargetServerId,
		TargetDatabase,
		ProfileXml,
		ProfilePath

	)
	values
	(
		Src.ProfileFileName,
		Src.SourcePackage,
		Src.TargetNodeId,
		Src.TargetDatabase,
		Src.ProfileXml,
		Src.ProfileSourcePath
	)
	when matched and not exists
	(
		select

		Src.SourcePackage,
		Src.TargetNodeId,
		Src.TargetDatabase,
		Src.ProfileXml,
		Src.ProfileSourcePath

		intersect

		select

		Dst.SourcePackage,
		Dst.TargetServerId,
		Dst.TargetDatabase,
		Dst.ProfileXml,
		Dst.ProfilePath
	)
	then update set
		Dst.SourcePackage = Src.SourcePackage,
		Dst.TargetServerId = Src.TargetNodeId,
		Dst.TargetDatabase = Src.TargetDatabase,
		Dst.ProfileXml = Src.ProfileXml,
		Dst.ProfilePath = Src.ProfileSourcePath
	when not matched by source then delete;


	
