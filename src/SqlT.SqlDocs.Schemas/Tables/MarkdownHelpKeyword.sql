create table [SqlDocs].[MarkdownHelpKeyword]
(
	StoreKey int not null 
		constraint DF_MarkdownHelpKeyword_StoreKey 
			default(next value for [SqlDocs].[MarkdownHelpKeywordSequence]),
	SegmentName nvarchar(75) not null,	
	DocumentTitle nvarchar(250) not null,
	Keyword nvarchar(75) not null,
	CreateTS datetime2(0) constraint DF_MarkdownHelpKeyword_CreateTS default(getdate()),
	constraint PK_MarkdownKelpKeyword primary key(StoreKey),
	constraint UQ_MarkdownHelpKeyword unique(SegmentName, DocumentTitle,Keyword),
	constraint FK_MarkdownHelpKeyword_MarkdownFile foreign key(SegmentName, DocumentTitle)
		references [SqlDocs].[MarkdownFile](SegmentName, DocumentTitle)
			on update cascade
			on delete cascade
)	
GO
create sequence [SqlDocs].[MarkdownHelpKeywordSequence]
	as int start with 1 cache 100;

