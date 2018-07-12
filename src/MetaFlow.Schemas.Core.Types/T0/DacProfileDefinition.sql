create type [T0].[DacProfileDefinition] as table
(
	ProfileFileName nvarchar(250) not null,
	SourcePackage nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,	
	TargetDatabase nvarchar(128) not null,
	ProfileXml nvarchar(max) not null,
	ProfileSourcePath nvarchar(250) null
	
)
	
