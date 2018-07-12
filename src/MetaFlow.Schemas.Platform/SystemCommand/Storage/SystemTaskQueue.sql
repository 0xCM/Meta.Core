create table [WF].[SystemTaskQueue]
(
	TaskId bigint not null 
		constraint DF_SystemTaskQueue_TaskId 
			default(next value for [WF].[PlatformTaskSequence]),		
	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystemId nvarchar(75) not null,
	CommandUri nvarchar(250) not null,	
	CommandBody nvarchar(max) null 
		constraint CK_SystemTaskQueue_CommandBody check(isjson(CommandBody)>0),    	
	ResultBody nvarchar(max) null
		constraint CK_SystemTaskQueue_ResultBody check(isjson(ResultBody)>0),  
	SubmittedTS datetime2(0) not null
		constraint DF_SystemTaskQueue_SubmittedTS			
			default (getdate()),
	Dispatched bit not null
		constraint DF_SystemTaskQueue_Dispatched
			default (0),
	DispatchTS datetime2(0) null,	
	Completed bit not null
		constraint DF_SystemTaskQueue_Completed
			default (0),
	CompleteTS datetime2(0) null,
	Succeeded bit not null
		constraint DF_SystemTaskQueue_Succeeded
			default(0),	
	ResultDescription nvarchar(max) null,
	CorrelationToken nvarchar(250) null,	
	CreateTS datetime2(0) not null
		constraint DF_SystemTaskQueue_CreateTS
			default (getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_SystemTaskQueue primary key(TaskId)
		
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[TaskQueue]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'SystemTaskQueue',
    @level2type = NULL,
    @level2name = NULL
GO


create sequence [WF].[PlatformTaskSequence]
	as bigint start with 1 cache 100
GO

