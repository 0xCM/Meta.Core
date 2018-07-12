create view [WF].[AgentStatusSummary] as
	select
		HostId,
		SystemId,
		AgentId,
		AgentState,
		StatusSummary,
		AsOfTS,
		Pulse = abs(datediff(second, getutcdate(), AsofTS))
	from
		[WF].[AgentStatusLog]
	
