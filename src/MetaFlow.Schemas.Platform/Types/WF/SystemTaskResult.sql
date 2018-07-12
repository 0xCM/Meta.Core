create type [WF].[SystemTaskResult] as table
(
	TaskId bigint not null,
  	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	Succeeded bit not null,
	ResultBody nvarchar(max) null,
	ResultDescription nvarchar(max) null,	
	CorrelationToken nvarchar(250) null	
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[Result]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemTaskResult',
    @level2type = NULL,
    @level2name = NULL
GO




