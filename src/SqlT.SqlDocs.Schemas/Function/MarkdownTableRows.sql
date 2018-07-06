create function [SqlDocs].[MarkdownTableRows]() returns table as return
	select	
		RowIndex = row_number() over(order by r.SegmentName, r.DocumentTitle, r.TablePosition, RowNumber),
		r.SegmentName,
		r.DocumentTitle, 		
		t.TableNumber,
		t.TablePosition,
		r.RowNumber, 
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
		[SqlDocs].[MarkdownTableRow] r 
			inner join [SqlDocs].[DocumentTableIdentity] t on 
				t.SegmentName = r.SegmentName	
			and	t.DocumentTitle = r.DocumentTitle				
			and t.TablePosition = r.TablePosition
	
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlDocs].[MarkdownTableRow]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDocs',
    @level1type = N'FUNCTION',
    @level1name = N'MarkdownTableRows',
    @level2type = NULL,
    @level2name = NULL
	

