create table [Factory].[Table]
(
  	FactoryKey bigint not null
		constraint DF_Table_FactoryKey 
			default(next value for [Factory].[FactorySequence]),

	Identifier nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TableName nvarchar(128) not null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_Table_CreateTS default(getdate()),

	constraint PK_Table primary key(FactoryKey),
	constraint UQ_Table unique(Identifier)

)
	
