create procedure [SqlDocs].[SyncMarkdownHelpKeywords](@Keywords [SqlDocs].[MarkdownHelpKeyword] readonly)
	as merge into [SqlDocs].[MarkdownHelpKeyword] as Dst
		using @Keywords as Src on
			Src.SegmentName = Dst.SegmentName
		and	Src.DocumentTitle = Dst.DocumentTitle
		and Src.Keyword = Dst.Keyword
	when not matched then insert
	(
		SegmentName,
		DocumentTitle,
		Keyword
	)
	values
	(
		Src.SegmentName,
		Src.DocumentTitle,
		Src.Keyword
	)
	when not matched by source then delete;

	
