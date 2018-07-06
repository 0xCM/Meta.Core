create procedure [SqlT].[SyncSqlProxyDefinitions](@Specs [SqlT].[ProxyProfileDefinition] readonly) as

	merge into [SqlStore].[SqlProxyDefinitionStore] as Dst
	using @Specs as Src
		on 
		Src.AssemblyDesignator = Dst.AssemblyDesignator
		and Src.ProfileName = Dst.ProfileName
	when not matched then insert
	(
		AssemblyDesignator,
		ProfileName,
		SourceNode,
		SourceDatabase,
		TargetAssembly,
		ProfileText
	)
	values
	(
		Src.AssemblyDesignator,
		Src.ProfileName,
		Src.SourceNode,
		Src.SourceDatabase,
		Src.TargetAssembly,
		Src.ProfileText
	)
	when matched and not exists
	(
		select
			Src.SourceNode,
			Src.SourceDatabase,
			Src.TargetAssembly,
			Src.ProfileText
	
		intersect

		select

			Dst.SourceNode,
			Dst.SourceDatabase,
			Dst.TargetAssembly,
			Dst.ProfileText

	)
	then update set
		Dst.SourceNode = Src.SourceNode,
		Dst.SourceDatabase = Src.SourceDatabase,
		Dst.TargetAssembly = Src.TargetAssembly,
		Dst.ProfileText = Src.ProfileText,
		Dst.UpdateTS = getdate()
	when not matched by source then delete		
		;
