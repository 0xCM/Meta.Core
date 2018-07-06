create table [Factory].[TableColumn] 
(
 	FactoryKey bigint not null
		constraint DF_TableColumn_FactoryKey 
			default(next value for [Factory].[FactorySequence]),

	TableIdentifier nvarchar(75) not null,
	ColumnName nvarchar(128) not null,
	ColumnPosition int not null,
	DataTypeName nvarchar(128) not null,
	IsNullable bit not null,
	[Length] int null,
	[Precision] tinyint null,
	Scale tinyint null,
	IsIdentity bit not null,
	ComputationExpression nvarchar(250) null,
	ComputationPersisted bit null,
	Documentation nvarchar(250) null,
	
	CreateTS datetime2(0) not null
		constraint DF_TableColumn_CreateTS default(getdate()),

	constraint PK_TableColumn primary key(FactoryKey),
	constraint FK_TableColumn_Table foreign key(TableIdentifier)
		references [Factory].[Table](Identifier)
			on delete cascade


	
)

	
