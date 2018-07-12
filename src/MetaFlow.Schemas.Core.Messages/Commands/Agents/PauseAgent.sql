create type [C0].[PauseAgent] as table
(
	CommandNode nvarchar(75) not null,
	AgentId nvarchar(75) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[AgentControlCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'PauseAgent',
    @level2type = NULL,
    @level2name = NULL
GO





	
