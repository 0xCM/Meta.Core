create type [SqlDac].[DacProfileDefinition] as table
(
	ProfileFileName nvarchar(250) not null,
	SourcePackage nvarchar(75) not null,
	TargetServer nvarchar(128) not null,	
	TargetDatabase nvarchar(128) not null,
	ProfileXml nvarchar(max) not null,
	ProfileSourcePath nvarchar(250) null
	
)
	
