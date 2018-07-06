create procedure [SqlDocs].[SyncSyntaxBlocks]
(
	@Blocks [SqlDocs].[SqlSyntaxBlock] readonly
) as
	
	declare 
		@LoadTS datetime2(0) = getdate();

		merge into [SqlDocs].[SqlSyntaxBlock] as Dst
			using @Blocks as Src on
				Src.SegmentName = Dst.SegmentName
			and	Src.DocumentTitle = Dst.DocumentTitle
			and Src.SyntaxPosition = Dst.SyntaxPosition
		when not matched then insert
		(
			SegmentName,
			DocumentTitle,
			SyntaxPosition,
			SyntaxContent
		
		)
		values
		(
			Src.SegmentName,
			Src.DocumentTitle,
			Src.SyntaxPosition,
			Src.SyntaxContent

		)
		when matched and not exists
		(
			select
	
				Src.SyntaxContent

			intersect

			select

				Dst.SyntaxContent

		)
		then update set
			Dst.SyntaxContent = Src.SyntaxContent,
			Dst.UpdateTS = getdate()
		when not matched by source then delete;
