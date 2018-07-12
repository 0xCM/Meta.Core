create type [T0].[PlatformEntity] as table
(
	EntityName nvarchar(75) not null,
	TypeUri nvarchar(250) not null,
	Body nvarchar(max) not null
)
	
