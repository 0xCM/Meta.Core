create type [PF].[PlatformProject] as table
(
	SystemId nvarchar(75) not null,
	SolutionId nvarchar(75) not null,	
	ProjectId nvarchar(75) not null,
	ProjectName nvarchar(150) not null,
	TargetAssembly nvarchar(150) not null

)