create function [SqlDocs].[DocumentKeywords]() returns table as return
	select 
		f.FileLocation,
		f.SegmentName, 
		f.DocumentTitle, 
		kw.Keyword  
	from 
		[SqlDocs].[MarkdownHelpKeyword] kw inner join 
			[SqlDocs].[MarkdownFile] f on 
				f.DocumentTitle = kw.DocumentTitle 
	
