create type [MC].[SolutionDefinition] as table
(
	AreaId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	SolutionId nvarchar(75) not null,
	SolutionName nvarchar(250) not null

)
	
