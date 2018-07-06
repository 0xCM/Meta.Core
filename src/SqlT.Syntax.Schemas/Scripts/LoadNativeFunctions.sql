insert [SqlT.Syntax].[Syntax].[NativeFunction]
(
	FunctionName
)
select distinct
	Keyword
from   
	[SqlT.SqlDocs].[SqlDocs].[MarkdownHelpKeyword]
where 
	SegmentName = 'functions' 
and Keyword not in(select FunctionName  from [SqlT.Syntax].[Syntax].[NativeFunction])
and Keyword not like '%)'
