create table [Syntax].[ObjectType]
(
	TypeCode nvarchar(75) not null,	
	TypeDescription nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_ObjectType_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint PK_ObjectType primary key(TypeCode)

)
GO

