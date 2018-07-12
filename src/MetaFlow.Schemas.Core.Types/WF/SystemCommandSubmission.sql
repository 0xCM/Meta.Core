create type [WF].[SystemCommandSubmission] as table
(
 	SourceNodeId nvarchar(75) not null, 
	CommandNode nvarchar(75) not null, 
	TargetSystemId nvarchar(75) not null, 
	CommandUri nvarchar(75) not null,
	CommandBody nvarchar(max) null,
	CorrelationToken nvarchar(250) null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemCommandSubmission',
    @level2type = NULL,
    @level2name = NULL
GO
