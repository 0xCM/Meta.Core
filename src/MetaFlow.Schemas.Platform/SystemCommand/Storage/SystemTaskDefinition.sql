create table [WF].[SystemTaskDefinitionStore]
(
	TaskId bigint not null 
		constraint DF_SystemTaskDefinition_TaskId 
			default(next value for [WF].[PlatformTaskSequence]),		
	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystemId nvarchar(75) not null,
	CommandUri nvarchar(250) not null,	
	CommandBody nvarchar(max) null 
		constraint CK_SystemTaskDefinition_CommandBody check(isjson(CommandBody)>0),    	
	DefinedTS datetime2(0) not null
		constraint DF_SystemTaskDefinition_SubmittedTS			
			default (getdate()),
	Enqueued bit not null
		constraint DF_SystemTaskDefinition_Dispatched
			default (0),
	EnqueuedTS datetime2(0) null,
	CorrelationToken nvarchar(250) null,	
	CreateTS datetime2(0) not null
		constraint DF_SystemTaskDefinition_CreateTS
			default (getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_SystemTaskDefinition primary key(TaskId)
		
)
GO
