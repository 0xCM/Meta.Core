create table [SqlStore].[FieldListDefinition]
(
	StoreKey int not null
		constraint DF_FieldListDefinition_StoreKey default(next value for [SqlStore].[StoreKeySequence]),
	AssemblyDesignator nvarchar(75) not null,
	ProfileName nvarchar(75) not null,
	ListName nvarchar(75) not null,
	SourceTableSchema nvarchar(128) not null,
	SourceTableName nvarchar(128) not null,
	IdentifierColumn nvarchar(128) not null,
	TableTypeSchema nvarchar(128) null,
	TableTypeName nvarchar(128) null,
	TypedIdentifierType nvarchar(75) null,
	IdentifierValueColumn nvarchar(128) null,
	CreateTS  datetime2(0) not null
		constraint DF_FieldListDefinition_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,

	constraint PK_FieldListDefinition primary key(StoreKey),
	constraint UQ_FieldListDefinition unique(AssemblyDesignator,ProfileName,ListName),
	constraint FK_FieldListDefinition_GenerationProfile 
		foreign key(AssemblyDesignator,ProfileName)
		references [SqlStore].[GenerationProfile](AssemblyDesignator,ProfileName)


)
