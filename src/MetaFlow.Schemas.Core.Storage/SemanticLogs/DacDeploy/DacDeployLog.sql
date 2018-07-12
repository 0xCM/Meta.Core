create table [PF].[DacDeployLog]
(
	DeploymentId bigint not null
		constraint DF_DacDeployLog_DeploymentId 
			default(next value for [PF].[DacDeploymentIdSequence]),
	SourceNodeId nvarchar(75) not null,
	SourcePackage nvarchar(128) not null,
	TargetNodeId nvarchar(75) not null,
	TargetDatabase nvarchar(128) not null,
	CorrelationToken nvarchar(250) not null,
	StartTS datetime2(0) not null
		constraint DF_DacDeployLog_StartTS default(getdate()),
	Completed bit not null
		constraint DF_DacDeployLog_Completed default(0),	
	CompletionTS datetime2(0) null,
	Succeeded bit not null
		constraint DF_DacDeployLog_Succeeded default(0),	
	CompletionMessage nvarchar(1024) null,	

	CreateTS datetime2(0) not null 
		constraint DF_DacDeployLog_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

			
	constraint PK_DacDeployLog primary key(DeploymentId)
	
)
GO


create trigger [PF].[DacDeployLogUpdated] 
	on [PF].[DacDeployLog] after update as
		update [PF].[DacDeployLog] set 
			UpdateTS = getdate()
	from 
		[PF].[DacDeployLog] x 
			inner join inserted on 
				inserted.DeploymentId = x.DeploymentId
GO

create sequence [PF].[DacDeploymentIdSequence]
	as bigint start with 1 cache 10
GO



create sequence [PF].[RuntimeKeySequence]
	as bigint start with 1 cache 100;
GO

