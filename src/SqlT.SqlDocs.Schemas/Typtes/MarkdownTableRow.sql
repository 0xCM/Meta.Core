create type [SqlDocs].[MarkdownTableRow] as table
(
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	TableNumber int null,
	TablePosition int not null,
	RowNumber int not null,
	CellValue01 nvarchar(250) null,
	CellValue02 nvarchar(250) null,
	CellValue03 nvarchar(250) null,
	CellValue04 nvarchar(250) null,
	CellValue05 nvarchar(250) null,
	CellValue06 nvarchar(250) null,
	CellValue07 nvarchar(250) null,
	CellValue08 nvarchar(250) null,
	CellValue09 nvarchar(250) null
)
	
