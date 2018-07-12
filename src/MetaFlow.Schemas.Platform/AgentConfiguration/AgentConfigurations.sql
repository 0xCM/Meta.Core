create function [WF].[AgentConfigurations]() returns table as return
	
	select
		AgentId,
		IsEnabled,
		SpinFrequency
	from
		[WF].[AgentConfigurationStore]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[WF].[AgentConfiguration]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Function',
    @level1name = N'AgentConfigurations',
    @level2type = NULL,
    @level2name = NULL

	

