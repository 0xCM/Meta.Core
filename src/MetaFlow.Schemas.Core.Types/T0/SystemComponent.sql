create type [T0].[SystemComponent] as table
(
	ComponentId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ComponentType nvarchar(75) not null,
	ComponentVersion nvarchar(75) not null,
	ComponentTS datetime2(0) not null



	
)
