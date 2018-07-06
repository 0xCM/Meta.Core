create table [SqlDocs].[MarkdownFile]
(
	StoreKey int not null 
		constraint DF_MarkdownFile_StoreKey 
			default(next value for [SqlDocs].[MarkdownFileSequence]),
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	FileLocation nvarchar(500) not null,
	ModifiedDate date null,
	FileSize bigint not null,
	CreateTS datetime2(0) constraint DF_MarkdownFile_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_MarkdownFile primary key(StoreKey),
	constraint UQ_MarkdownFile_Location unique(FileLocation),
	constraint UQ_MarkdownFile_Title unique(SegmentName, DocumentTitle)
)
GO

create sequence [SqlDocs].[MarkdownFileSequence]
	as int start with 1 cache 100;
