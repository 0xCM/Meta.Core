create table [SqlStore].[NativeDataType]
(
	StoreKey int not null
		constraint DF_NativeDataType_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	TypeName nvarchar(128) not null,
	[MaxLength] int null,
	[Precision] tinyint null,	
	[Scale] tinyint null,	
	IsNullable bit not null,
	IsClrType bit not null,
	CreateTS datetime2(0) not null
		constraint DF_NativeDataType_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_NativeDataType primary key(StoreKey),
	constraint UQ_NativeDataType unique(TypeName),
)

GO
