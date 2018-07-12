create table [PF].[PlatformStoreChangeLog]
(
	LogEntryId bigint not null
		constraint DF_PlatformStoreChangeLog_LogEntryId
			default (next value for [PF].[PlatformStoreChangeSequence]),

	StoreName nvarchar(128) not null,
	SystemKey bigint not null,
	ChangeType char(1) not null,
	ChangeTS datetime2(0) not null,
		
	constraint PK_PlatformStoreChangeLog primary key(LogEntryId)
)
GO
create sequence [PF].[PlatformStoreChangeSequence]
	as bigint start with 1 cache 10
GO

