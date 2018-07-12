create type [T0].[SystemArtifact] as table
(
	SystemId nvarchar(75) not null,
	ArtifactId nvarchar(75) not null,
	ArtifactType nvarchar(75) not null
)
	
