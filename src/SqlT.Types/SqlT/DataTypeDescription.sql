create type [SqlT].[DataTypeDescription] as table
(
	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,
	TypeName nvarchar(128) not null,
	IsUserDefined bit not null,
	[MaxLength] smallint not null,
	[Precision] tinyint not null,
	[Scale] tinyint not null,
	IsNullable bit NULL,
	IsClrType bit not null
)
	
