create procedure [Factory].[SpecifyMergeProc](@Proc [Factory].[MergeProc] readonly, @Columns [Factory].[MergeColumn] readonly) as


	begin transaction

		insert [Factory].[MergeProc]
		(
			MergeProcSchema, 
			MergeProcName, 
			SourceObjectSchema, 
			SourceObjectName, 
			TaretObjectSchema, 
			TargetObjectName, 
			SyncWithSource, 
			[Description] 
		)
		select 
			MergeProcSchema, 
			MergeProcName, 
			SourceObjectSchema, 
			SourceObjectName, 
			TaretObjectSchema, 
			TargetObjectName, 
			SyncWithSource, 
			Documentation 
		from @Proc



		insert [Factory].[MergeColumn]
		(
			ColumnPosition, 
			SourceColumn, 
			TargetColumn, 
			IsMatchColumn 
		)
		select 
			ColumnPosition, 
			SourceColumn, 
			TargetColumn, 
			IsMatchColumn 
		from 
			@Columns

	commit transaction