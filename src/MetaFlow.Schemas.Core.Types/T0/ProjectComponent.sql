create type [T0].[ProjectComponent] as table
(
	SystemId nvarchar(75) not null,
	ProjectName nvarchar(150) not null,
	ComponentId nvarchar(75) not null,
	TargetAssembly nvarchar(150) not null,
	ComponentType nvarchar(75) not null,
	IsSqlProject bit not null,
	TargetDatabase nvarchar(128) null,
	ComponentVersion nvarchar(75) null,
	ComponentTS datetime2(0) not null
)

	
