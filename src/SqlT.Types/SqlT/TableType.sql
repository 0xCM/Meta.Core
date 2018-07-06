create type [SqlT].[TableType] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	[Description] nvarchar(250) not null

)
	
