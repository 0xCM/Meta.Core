create table [PF].[ReceivedFile]
(
	FileId uniqueidentifier not null,
	[FileName] nvarchar(255) not null,
	[FileSize] bigint not null,
	ReceivedTime datetime2(0) not null,
	LastWriteTime datetime2(0) not null,
	ReceiptPath nvarchar(500) not null,

	CreateTS datetime2(0) not null 
		constraint DF_ReceivedFile_CreateTS default(getdate()),
	constraint PK_ReceivedFile primary key(FileId)
)
