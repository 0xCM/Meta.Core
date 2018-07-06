	create view  [SqlDocs].[DocumentTableIdentity] as
	select		
		SegmentName,
		DocumentTitle, 
		TablePosition,
		TableNumber = row_number() over(partition by SegmentName, DocumentTitle order by TablePosition)	
	from 
		[SqlDocs].[MarkdownTableRow]
	group by
		SegmentName,
		DocumentTitle,
		TablePosition
GO
