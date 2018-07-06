create table [SqlDocs].[MarkdownFileContent]
(
	StoreKey int not null 
		constraint DF_MarkdownFileContent_StoreKey 
			default(next value for [SqlDocs].[MarkdownFileContentSequence]),
	SegmentName nvarchar(75) not null,
	DocumentTitle nvarchar(250) not null,
	FileLocation nvarchar(500) not null,
	ModifiedDate date null,
	FileSize bigint not null,
	FileContent nvarchar(max) not null,

	CreateTS datetime2(0) constraint DF_MarkdownFileContent_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_MarkdownFileContent primary key(StoreKey),
	constraint UQ_MarkdownFileContent unique(SegmentName, DocumentTitle),
	constraint UQ_MarkdownFileContent_Location unique(FileLocation),

)
GO
create sequence [SqlDocs].[MarkdownFileContentSequence]
	as int start with 1 cache 100;
	
