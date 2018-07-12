create type [WF].[SystemTask] as table
(
	TaskId bigint not null,
  	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystemId nvarchar(75) not null,
	CommandUri nvarchar(250) not null,
	CommandBody nvarchar(max) null,
	SubmittedTS datetime2(0) not null,
	DispatchTS datetime2(0) null,
	CorrelationToken nvarchar(250) not null
)
	
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[Task]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemTask',
    @level2type = NULL,
    @level2name = NULL
GO




