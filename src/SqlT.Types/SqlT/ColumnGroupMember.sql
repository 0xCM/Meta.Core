create type [SqlT].[ColumnGroupMember] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	ObjectSchema nvarchar(128) not null,
	ObjectName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	GroupTypeName nvarchar(75) not null
)
	
