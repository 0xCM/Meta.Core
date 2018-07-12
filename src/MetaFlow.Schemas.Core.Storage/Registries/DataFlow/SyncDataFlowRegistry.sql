create procedure [PF].[SyncTypedDataFlowRegistry](@Entries [T0].[TypedDataFlowDescriptor] readonly) as
	merge into [PF].[TypedDataFlowRegistry] as Dst 
		using @Entries as Src 
			on Src.SourceAssembly = Dst.SourceAssembly
		and Src.TargetAssembly = Dst.TargetAssembly
		and Src.DataFlowName = Dst.DataFlowName

	when not matched then insert
	(
		SourceAssembly,
		TargetAssembly,
		DataFlowName,
		WorkflowTypeUri,
		ArgumentTypeUri

	)
	values
	(
		Src.SourceAssembly,		
		Src.TargetAssembly,
		Src.DataFlowName,
		Src.WorkflowTypeUri,
		Src.ArgumentTypeUri
	)
	when matched and not exists 
	(
		select 
			Src.WorkflowTypeUri,
			Src.ArgumentTypeUri
			

		intersect

		select 
			Dst.WorkflowTypeUri,
			Dst.ArgumentTypeUri
			
	
	)
	then update set
		Dst.WorkflowTypeUri = Src.WorkflowTypeUri,
		Dst.ArgumentTypeUri = Src.ArgumentTypeUri
		
	when not matched by source then delete;




	
