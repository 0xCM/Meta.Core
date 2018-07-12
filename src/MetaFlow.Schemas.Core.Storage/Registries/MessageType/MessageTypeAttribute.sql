create table [PF].[MessageTypeAttribute]
(
	SystemKey bigint not null 
		constraint DF_MessageTypeAttribute_SystemKey default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
 	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	ColumnPosition int not null,
	DataTypeName nvarchar(128) not null,
	IsNullable bit not null,
	[Length] int null,
	[Precision] tinyint null,
	Scale tinyint null,
	[Description] nvarchar(250) null,

 	CreateTS datetime2(0) not null 
		constraint DF_MessageTypeAttribute_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_MessageTypeAttribute primary key(SystemKey),
	constraint UQ_MessageTypeAttribute unique(SchemaName,TypeName,ColumnName),
	constraint FK_MessageTypeAttribute_MessageType foreign key(SchemaName,TypeName)
		references [PF].[MessageTypeRegistry](SchemaName,TypeName)
		on delete cascade
		on update cascade

)
