create procedure [PF].[SyncSqlProxyDefinitions](@Specs [T0].[SqlProxyDefinition] readonly) as

	merge into [PF].[SystemProxyDefinition] as Dst
	using @Specs as Src
		on 
		Src.AssemblyDesignator = Dst.AssemblyDesignator
		and Src.ProfileName = Dst.ProfileName
	when not matched then insert
	(
		AssemblyDesignator,
		SystemId,
		ProfileName,
		SourceNode,
		SourceDatabase,
		TargetAssembly,
		ProfileText
	)
	values
	(
		Src.AssemblyDesignator,
		Src.SystemId,
		Src.ProfileName,
		Src.SourceNode,
		Src.SourceDatabase,
		Src.TargetAssembly,
		Src.ProfileText
	)
	when matched and not exists
	(
		select
			Src.SystemId,
			Src.SourceNode,
			Src.SourceDatabase,
			Src.TargetAssembly,
			Src.ProfileText
	
		intersect

		select
			Dst.SystemId,
			Dst.SourceNode,
			Dst.SourceDatabase,
			Dst.TargetAssembly,
			Dst.ProfileText

	)
	then update set
		Dst.SystemId = Src.SystemId,
		Dst.SourceNode = Src.SourceNode,
		Dst.SourceDatabase = Src.SourceDatabase,
		Dst.TargetAssembly = Src.TargetAssembly,
		Dst.ProfileText = Src.ProfileText
	when not matched by source then delete		
		;
