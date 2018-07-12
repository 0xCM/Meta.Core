create type [PF].[DatabaseDropEventData] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	LoginName nvarchar(128) not null,
	EventTS datetime2(0) not null
)
