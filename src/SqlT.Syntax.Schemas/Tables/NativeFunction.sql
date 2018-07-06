create table [Syntax].[NativeFunction]
(
	FunctionName nvarchar(128) not null,	
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_NativeFunction_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint PK_FunctionName primary key(FunctionName)

)
GO

