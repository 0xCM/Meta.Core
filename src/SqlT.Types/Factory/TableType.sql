create type [Factory].[TableType] as table
(
	Identifier nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	[Description] nvarchar(250) not null

)
	
