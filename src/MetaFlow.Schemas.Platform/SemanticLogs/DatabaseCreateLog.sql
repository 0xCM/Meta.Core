create table [PF].[DatabaseCreateLog]
(	
	EntryId bigint not null 
		constraint DF_DatabaseCreateLog_EntryId 
			default(next value for [PF].[LogEntrySequence]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	LoginName nvarchar(128) not null,
	EventTS datetime2(0) not null,
	CreateTS datetime2(0) not null
		constraint DF_DatabaseCreateLog_CreateTS
			default(getdate())
)
GO
