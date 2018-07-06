create table [SqlDom].[EnumLiteral]
(
	EnumName varchar(250),
	LiteralName varchar(250),
	LiteralValue int,
	CreateTS datetime2(0) not null
		constraint DF_EnumLiteral_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_EnumLiteral primary key(EnumName,LiteralName),
	constraint FK_EnumLiteral_DomElement foreign key(EnumName)
		references [SqlDom].[Element](ElementName)
)
	
GO

