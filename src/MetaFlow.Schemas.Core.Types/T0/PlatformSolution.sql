create type [T0].[PlatformSolution] as table
(
	SystemId nvarchar(75) not null,
	SolutionId nvarchar(75) not null,
	SolutionName nvarchar(75) not null
)
