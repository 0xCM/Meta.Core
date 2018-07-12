create table [PF].[PlatformEntityChangeLog]
(
	EntryId bigint not null 
		constraint DF_PlatformEntityChangeLog_EntryId 
			default(next value for [PF].[LogEntrySequence]),
	HostId nvarchar(75) not null,
	EntityName nvarchar(75) not null,
	ChangeType char(1) not null,
	EventTS datetime2(0) not null,
	CreateTS datetime2(0) not null
		constraint DF_PlatformEntityChangeLog_CreateTS
			default(getdate())


)
