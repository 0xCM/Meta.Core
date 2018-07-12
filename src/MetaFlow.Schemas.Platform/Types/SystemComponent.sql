create type [PF].[SystemComponent] as table
(
	ComponentId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ComponentType nvarchar(75) not null,
	RegisteredVersion nvarchar(75) not null



	
)
