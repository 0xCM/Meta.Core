create type [T0].[TargetedDatabaseComponent] as table
(
	SystemId nvarchar(75) not null,
	TargetedDatabase nvarchar(128) not null,
	ComponentId nvarchar(75) not null,
	ComponentVersion nvarchar(75) not null,
	ComponentTS datetime2(0) not null,
	SqlPackageName nvarchar(75) not null

)
	
