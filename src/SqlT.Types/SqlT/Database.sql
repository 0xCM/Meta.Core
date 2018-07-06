create type [SqlT].[Database] as table
(
 	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	DatabaseType nvarchar(128) not null
)
