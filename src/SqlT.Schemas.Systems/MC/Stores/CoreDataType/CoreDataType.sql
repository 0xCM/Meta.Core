create table [MC].[CoreDataType]
(
	StoreKey int not null
		constraint DF_CoreDataType_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	DataTypeName nvarchar(128) not null,
	ClrTypeName nvarchar(128) not null,
	IsInteger bit not null,
	IsText bit not null,
	IsBoolean bit not null,
	IsTemporal bit not null,
	CanSpecifyLength bit not null,
	CanSpecifyPrecision bit not null,
	CanSpecifyScale bit not null,

	CreateTS datetime2(0) not null
		constraint DF_CoreDataType_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint PK_CoreDataType primary key(StoreKey),
	constraint UQ_CoreDataType unique(DataTypeName)

)
GO
