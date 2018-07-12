create table [PF].[FileReceiptLog]
(
	EntryId bigint not null
		constraint DF_FileReceiptLog_EntryId default(next value for [PF].[FileReceiptSequence]),
	HostId nvarchar(75) not null,
 	FileId uniqueidentifier not null,
	[FileName] nvarchar(255) not null,
	FileType nvarchar(75) not null,
	ReceiptPath nvarchar(500) not null,
	WrittenTS datetime2(0) not null,
	ReceiptTS datetime2(0) not null,
	LoggedTS datetime2(0) not null 
		constraint DF_FileReceiptLog_LoggedTS default(getdate()),
	SystemRV timestamp
	constraint PK_FileReceiptLog primary key(EntryId)

)
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[LogTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'FileReceiptLog',
    @level2type = NULL,
    @level2name = NULL
GO

create sequence [PF].[FileReceiptSequence]
	as bigint start with 1 cache 10
GO

