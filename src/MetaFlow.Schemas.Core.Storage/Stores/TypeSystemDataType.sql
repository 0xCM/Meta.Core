create table [PF].[TypeSystemDataType]
(
	SystemKey int not null
			constraint DF_DataType_TypeSpaceKey default(next value for [PF].[SystemKeySequence]),	
	TypeSystemId int not null,
	DataTypeName nvarchar(75) not null,
	RuntimeType nvarchar(500) not null,

	CreateTS datetime2(0) not null 
		constraint DF_DataType_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_DataType primary key(SystemKey),
	constraint UQ_DataType unique(DataTypeName),
	constraint FK_DataType_TypeSystem foreign key(TypeSystemId)
		references [PF].[TypeSystemType](TypeCode)


)
	

