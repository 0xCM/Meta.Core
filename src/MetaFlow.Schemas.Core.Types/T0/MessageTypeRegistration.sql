create type [T0].[MessageTypeRegistration] as table
(
	SystemId nvarchar(75) not null,
	SchemaName nvarchar(128) not null,
	TypeName nvarchar(128) not null,
	MessageClass nvarchar(75) not null,
	[Description] nvarchar(250) null
)



	
