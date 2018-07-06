create table [SqlDocs].[MarkdownTableRow]
(
	StoreKey int not null 
		constraint DF_MarkdownTableRow_StoreKey 
			default(next value for [SqlDocs].[MarkdownTableRowSequence]),
	SegmentName nvarchar(75) not null,		
	DocumentTitle nvarchar(250) not null,
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
	CellValue09 nvarchar(250) null,
	CreateTS datetime2(0) constraint DF_MarkdownTableRow_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_MarkdownTableRow primary key(StoreKey),	
	constraint UQ_MarkdownTableRow unique(SegmentName, DocumentTitle, TablePosition, RowNumber),
	constraint FK_MarkdownTalbeRow_MarkdownTable foreign key(SegmentName,DocumentTitle,TablePosition)
		references [SqlDocs].[MarkdownTable](SegmentName, DocumentTitle,TablePosition)
			on delete cascade 
			on update cascade
)
GO

create sequence [SqlDocs].[MarkdownTableRowSequence]
	as int start with 1 cache 100;
