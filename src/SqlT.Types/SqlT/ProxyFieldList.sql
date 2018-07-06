create type [SqlT].[ProxyFieldList] as table
(
	ListName nvarchar(75) not null,
	SourceTableSchema nvarchar(128) not null,
	SourceTableName nvarchar(128) not null,
	IdentifierColumn nvarchar(128) not null,
	TableTypeSchema nvarchar(128) null,
	TableTypeName nvarchar(128) null,
	TypedIdentifierType nvarchar(75) null,
	IdentifierValueColumn nvarchar(128) null
)

	
