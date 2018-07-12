create type [WF].[SystemTaskDefinition] as table
(
	TaskId bigint not null,
  	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystemId nvarchar(75) not null,
	CommandUri nvarchar(250) not null,
	CommandBody nvarchar(max) null,
	DefinedTS datetime2(0) not null,
	Enqueued bit not null,
	EnqueuedTS datetime2(0) null,
	CorrelationToken nvarchar(250) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[WorkflowTask]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemTaskDefinition',
    @level2type = NULL,
    @level2name = NULL
GO




