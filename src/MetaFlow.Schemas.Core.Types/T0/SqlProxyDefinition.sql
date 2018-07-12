create type [T0].[SqlProxyDefinition] as table
(
	AssemblyDesignator nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ProfileName nvarchar(75) not null,
	SourceNode nvarchar(75) not null,
	SourceDatabase nvarchar(128),
	TargetAssembly nvarchar(128),
	ProfileText nvarchar(max) not null 
)