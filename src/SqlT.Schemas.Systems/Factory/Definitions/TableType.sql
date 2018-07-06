create table [Factory].[TableType]
(
  	FactoryKey bigint not null
		constraint DF_TableType_FactoryKey 
			default(next value for [Factory].[FactorySequence]),

	Identifier nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_TableType_CreateTS default(getdate()),

	constraint PK_TableType primary key(FactoryKey),
	constraint UQ_TableType unique(Identifier)

)
	
