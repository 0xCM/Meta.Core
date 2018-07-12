create table [WF].[SystemTaskArchive]
(
	TaskId bigint not null,
	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystemId nvarchar(75) not null,
	CommandUri nvarchar(250) not null,	
	CommandBody nvarchar(max) null, 
	ResultBody nvarchar(max) null,
	SubmittedTS datetime2(0) not null,
	Dispatched bit not null,
	DispatchTS datetime2(0) null,
	Completed bit not null,		
	CompleteTS datetime2(0) null,
	Succeeded bit not null,
	ResultDescription nvarchar(max) null,
	CorrelationToken nvarchar(250) null,	
	ArchivedTS datetime2(0) not null
		constraint DF_SystemTaskArchive_ArchiveTS
			default (getdate()),
	
	constraint PK_SystemTaskArchive primary key(TaskId)

)
	
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[TaskArchive]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'SystemTaskArchive',
    @level2type = NULL,
    @level2name = NULL
GO
