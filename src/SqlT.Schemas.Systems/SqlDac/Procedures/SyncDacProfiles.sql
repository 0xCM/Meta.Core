create procedure [SqlDac].[SyncDacProfiles](@Profiles [SqlDac].[DacProfileDefinition] readonly) as
	
	merge into [SqlDac].[DacProfile] as Dst
		using @Profiles as Src on
			Dst.ProfileFileName = Src.ProfileFileName
	when not matched then insert
	(

		ProfileFileName,
		SourcePackage,
		TargetServer,
		TargetDatabase,
		ProfileXml,
		ProfilePath

	)
	values
	(
		Src.ProfileFileName,
		Src.SourcePackage,
		Src.TargetServer,
		Src.TargetDatabase,
		Src.ProfileXml,
		Src.ProfileSourcePath
	)
	when matched and not exists
	(
		select

		Src.SourcePackage,
		Src.TargetServer,
		Src.TargetDatabase,
		Src.ProfileXml,
		Src.ProfileSourcePath

		intersect

		select

		Dst.SourcePackage,
		Dst.TargetServer,
		Dst.TargetDatabase,
		Dst.ProfileXml,
		Dst.ProfilePath
	)
	then update set
		Dst.SourcePackage = Src.SourcePackage,
		Dst.TargetServer = Src.TargetServer,
		Dst.TargetDatabase = Src.TargetDatabase,
		Dst.ProfileXml = Src.ProfileXml,
		Dst.ProfilePath = Src.ProfileSourcePath
	when not matched by source then delete;


	
