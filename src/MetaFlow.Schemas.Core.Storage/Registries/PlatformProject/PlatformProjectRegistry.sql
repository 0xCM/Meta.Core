create table [PF].[PlatformProjectRegistry]
(
	SystemKey bigint not null 
		constraint DF_PlatformProject_SystemKey default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
	SolutionId nvarchar(75) not null,	
	ProjectId nvarchar(75) not null,
	ProjectName nvarchar(150) not null,
	TargetAssembly nvarchar(150) not null,
	IsSqlProject bit not null,
	TargetDatabase nvarchar(128) null,
	CreateTS datetime2(0) not null 
		constraint DF_PlatformProject_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_PlatformProject primary key(SystemKey),
	constraint UQ_PlatformProject unique(ProjectId),
	constraint UQ_PlatformProject_Assembly unique(TargetAssembly),

	
)
GO
create trigger [PF].[PlatformProjectUpdated] 
	on [PF].[PlatformProjectRegistry] after update as
		update [PF].[PlatformProjectRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[PlatformProjectRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
