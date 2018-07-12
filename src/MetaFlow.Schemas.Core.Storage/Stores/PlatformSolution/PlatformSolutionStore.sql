create table [PF].[PlatformSolutionStore]
(
	SystemKey bigint not null
		constraint DF_PlatformSolution_SystemKey default(next value for [PF].[SystemKeySequence]),
	SystemId nvarchar(75) not null,
	SolutionId nvarchar(75) not null,
	SolutionName nvarchar(75) not null,
	
	CreateTS datetime2(0) not null 
		constraint DF_PlatformSolution_CreateTS default(getdate()),
	UpdateTS  datetime2(0) null,

	constraint PK_PlatformSolution primary key(SystemKey),
	constraint FK_PlatformSolution_PlatformSystem foreign key(SystemId)
		references [PF].[PlatformSystemRegistry](SystemId)
			on delete cascade
			on update cascade
)
GO
create trigger [PF].[PlatformSolutionUpdated] 
	on [PF].[PlatformSolutionStore] after update as
		update [PF].[PlatformSolutionStore] set 
			UpdateTS = getdate()
		from 
			[PF].[PlatformSolutionStore] x 
		inner join 
			inserted on x.SystemKey = x.SystemKey
GO

		