create type [MC].[CoreDataTypeInfo] as table
(
	DataTypeName nvarchar(128) not null,
	ClrTypeName nvarchar(128) not null,
	IsInteger bit not null,
	IsText bit not null,
	IsBoolean bit not null,
	IsTemporal bit not null,
	CanSpecifyLength bit not null,
	CanSpecifyPrecision bit not null,
	CanSpecifyScale bit not null

)

	
