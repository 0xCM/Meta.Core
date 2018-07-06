create type [SqlT].[ProxyGenerationSpec] as table
(
	ServerName sysname,
	DatabaseName sysname,
	ProfileName nvarchar(75) not null,
	ProfileText nvarchar(max) not null 
)