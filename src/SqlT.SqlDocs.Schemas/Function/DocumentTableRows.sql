create function [SqlDocs].[DocumentTableRows](@DocumentTitle nvarchar(250), @TableNumber int =1, @FirstRowNumber int = 1) returns table as return
	select	
		RowIndex,
		SegmentName,
		DocumentTitle, 		
		TableNumber,
		TablePosition,
		RowNumber, 
		CellValue01, 
		CellValue02, 
		CellValue03, 
		CellValue04, 
		CellValue05, 
		CellValue06, 
		CellValue07, 
		CellValue08, 
		CellValue09 
	
	from 
		[SqlDocs].[MarkdownTableRows]()  
	where 
		DocumentTitle like  concat('%', @DocumentTitle, '%')
	and TableNumber = @TableNumber
	and RowNumber >= @FirstRowNumber
	
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlDocs].[MarkdownTableRow]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDocs',
    @level1type = N'FUNCTION',
    @level1name = N'DocumentTableRows',
    @level2type = NULL,
    @level2name = NULL
	

