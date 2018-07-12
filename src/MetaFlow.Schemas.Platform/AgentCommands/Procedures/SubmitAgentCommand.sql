create procedure [WF].[SubmitAgentCommand]
(
	@SourceNode nvarchar(75),
	@TargetNode nvarchar(75), 
	@AgentId nvarchar(75), 
	@CommandName nvarchar(75), 
	@CorrelationToken nvarchar(250) = null
) as
	set nocount on
	set xact_abort on

	declare @Commands [WF].[AgentCommand];
	
	insert [WF].[AgentCommandQueue]
	(
		SourceNodeId,
		TargetNodeId,
		AgentId,
		CommandName,
		CorrelationToken
	)
	output
		inserted.CommandId,
		inserted.SourceNodeId,
		inserted.TargetNodeId,
		inserted.CommandName,
		inserted.AgentId,
		inserted.CorrelationToken
	into @Commands
	(
		CommandId,
		SourceNodeId,
		TargetNodeId,
		CommandName,
		AgentId,
		CorrelationToken
	)
	select
		@SourceNode,
		@TargetNode,
		@AgentId,
		@CommandName,
		isnull(@CorrelationToken, newid())
	
	select * from @Commands;

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[AgentCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'SubmitAgentCommand',
    @level2type = NULL,
    @level2name = NULL
GO

	
