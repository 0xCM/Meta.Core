create type [T0].[PlatformComponent] as table
(
	ComponentId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ClassifierId nvarchar(75) not null	
)
