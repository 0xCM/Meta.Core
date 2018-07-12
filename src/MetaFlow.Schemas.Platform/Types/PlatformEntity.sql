create type [PF].[PlatformEntity] as table
(
	EntityName nvarchar(75) not null,
	TypeUri nvarchar(250) not null,
	Body nvarchar(max) not null
)
	
