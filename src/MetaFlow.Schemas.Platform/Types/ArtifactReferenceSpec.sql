create type [PF].[ArtifactReferenceSpec] as table
(
	SpecFileName nvarchar(75) not null,
	SpecLabel nvarchar(75) not null,
	AreaName nvarchar(75) not null,
	SectionName nvarchar(75) not null,
	ReferenceType nvarchar(75) not null,
	SpecContent nvarchar(max) not null
)

