create table [Syntax].[DataType]
(
	TypeName nvarchar(128) not null,	
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_DataType_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint PK_DataType primary key(TypeName)

)
GO

