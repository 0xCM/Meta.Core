create type [SqlT].[UserDataType] as table
(
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	TypeSchema nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	BaseTypeName nvarchar(128) not null,
	Documentation nvarchar(250) null,
	[MaxLength] smallint not null,
	[Precision] tinyint not null,
	[Scale] tinyint not null,
	IsNullable bit not null
)

