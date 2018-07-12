create table [PF].[DatabaseDropLog]
(	
	EntryId bigint not null 
		constraint DF_DatabaseDropLog_EntryId 
			default(next value for [PF].[LogEntrySequence]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	LoginName nvarchar(128) not null,
	EventTS datetime2(0) not null,
	Applied bit not null 
		constraint DF_DatabaseDropLog_Applied
			default(0),
	AppliedTS datetime2(0) null,
	CreateTS datetime2(0) not null
		constraint DF_DatabaseDropLog_CreateTS
			default(getdate()),

	constraint PK_DatabaseDropLog primary key(EntryId)
)
GO
