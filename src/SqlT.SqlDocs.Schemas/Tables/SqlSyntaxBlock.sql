create table [SqlDocs].[SqlSyntaxBlock]
(
	StoreKey int not null 
		constraint DF_SqlSyntaxBlock_StoreKey 
			default(next value for [SqlDocs].[SqlSyntaxSequence]),
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	SyntaxPosition int not null,
	SyntaxContent nvarchar(max) not null,
	CreateTS datetime2(0) constraint DF_SqlSyntaxBlock_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_SqlSyntaxBlock primary key(StoreKey),	
	constraint UQ_SqlSyntaxBlock unique(SegmentName,DocumentTitle,SyntaxPosition),
	constraint FK_SqlSyntaxBlock_MarkdownFile foreign key(SegmentName,DocumentTitle)
		references [SqlDocs].[MarkdownFile](SegmentName,DocumentTitle)
			on update cascade
			on delete cascade


)
GO
create sequence [SqlDocs].[SqlSyntaxSequence]
	as int start with 1 cache 100;

	
