create table [PF].[ArtifactReferenceStore]
(
	SystemKey bigint not null 
		constraint DF_ArtifactReference_SystemKey default(next value for [PF].[SystemKeySequence]),
	SpecFileName nvarchar(75) not null,
	SpecLabel nvarchar(75) not null,
	AreaName nvarchar(75) not null,
	SectionName nvarchar(75) not null,
	ReferenceType nvarchar(75) not null,
	SpecContent nvarchar(max) not null,
	CreateTS datetime2(0) not null
		constraint DF_ArtifactReference_CreateTS default(getdate()),

	UpdateTS datetime2(0) null
	
)
GO

create trigger [PF].[ArtifactReferenceSpecUpdated] 
	on [PF].[ArtifactReferenceStore] after update as
		update [PF].[ArtifactReferenceStore] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformServerRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
GO



	