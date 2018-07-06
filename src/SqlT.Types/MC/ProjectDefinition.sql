create type [MC].[ProjectDefinition] as table
(
	AreaId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	ProjectId nvarchar(75) not null,
	ProjectType nvarchar(75) not null,
	ProjectName nvarchar(250) not null

)
	
