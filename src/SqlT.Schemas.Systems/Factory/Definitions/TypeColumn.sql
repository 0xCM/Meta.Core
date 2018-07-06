create table [Factory].[TypeColumn] 
(
 	FactoryKey bigint not null
		constraint DF_TypeColumn_FactoryKey 
			default(next value for [Factory].[FactorySequence]),

	TableTypeIdentifier nvarchar(75) not null,
	ColumnName nvarchar(128) not null,
	ColumnPosition int not null,
	DataTypeName nvarchar(128) not null,
	IsNullable bit not null,
	[Length] int null,
	[Precision] tinyint null,
	Scale tinyint null,
	[Description] nvarchar(250) null,

	CreateTS datetime2(0) not null
		constraint DF_TypeColumn_CreateTS default(getdate()),

	constraint PK_TypeColumn primary key(FactoryKey),
	constraint FK_TypeColumn_TableType foreign key(TableTypeIdentifier)
		references [Factory].[TableType](Identifier)
			on delete cascade

	
)

	
