create type [SqlT].[ObjectFacet] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	SchemaName nvarchar(128) not null,
	ObjectName nvarchar(128) not null
)
	
	
