create procedure [WF].[DispatchAgentCommands](@TargetNode nvarchar(75), @MaxCount int) as
	
	set nocount on;
	set xact_abort on;

	declare @Commands [WF].[AgentCommand];
		
	with Src as
	(
		select top(@MaxCount) 
			c.* 
		from 
			[WF].[AgentCommandQueue] c 
		where 
			Dispatched = 0 
		and TargetNodeId = @TargetNode
		order by 
			CommandId
	)
	
	update Src set 
		Src.Dispatched = 1,
		Src.DispatchTS = getdate()
	output 
		inserted.CommandId,
		inserted.SourceNodeId,
		inserted.TargetNodeId,
		inserted.CorrelationToken,
		inserted.AgentId,
		inserted.CommandName,
		inserted.Arg1Name, inserted.Arg1Value,
		inserted.Arg2Name, inserted.Arg2Value,
		inserted.Arg3Name, inserted.Arg3Value,
		inserted.Arg4Name, inserted.Arg4Value,
		inserted.Arg5Name, inserted.Arg5Value,
		inserted.Arg6Name, inserted.Arg6Value
	into @Commands
	(
		CommandId,
		SourceNodeId,
		TargetNodeId,
		CorrelationToken,
		AgentId,
		CommandName,
		Arg1Name, Arg1Value,
		Arg2Name, Arg2Value,
		Arg3Name, Arg3Value,
		Arg4Name, Arg4Value,
		Arg5Name, Arg5Value,
		Arg6Name, Arg6Value
	)	
	
	select * from @Commands

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[AgentCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Procedure',
    @level1name = N'DispatchAgentCommands'

