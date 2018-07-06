create table [SqlDocs].[MarkdownTable]
(
	StoreKey int not null 
		constraint DF_MarkdownTable_StoreKey 
			default(next value for [SqlDocs].[MarkdownTableSequence]),
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,	
	TablePosition int not null,
	[RowCount] int not null,
	ColumnCount int not null,
	CreateTS datetime2(0) constraint DF_MarkdownTable_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_MarkdownTable primary key(StoreKey),	
	constraint UQ_MarkdownTable unique(SegmentName, DocumentTitle,TablePosition),
	constraint FK_MarkdownTable_MarkdownFile foreign key(SegmentName, DocumentTitle)
		references [SqlDocs].[MarkdownFile](SegmentName, DocumentTitle)
			on update cascade
			on delete cascade
			
)
GO

create sequence [SqlDocs].[MarkdownTableSequence]
	as int start with 1 cache 100;
