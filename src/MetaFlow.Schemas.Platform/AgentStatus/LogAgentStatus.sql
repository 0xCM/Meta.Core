create procedure [WF].[LogAgentStatus](@Records [WF].[AgentStatus] readonly) as
	merge into [WF].[AgentStatusLog] with(tablock) as Dst 
		using @Records as Src on
			Src.HostId = Dst.HostId
		and Src.SystemId = Dst.SystemId
		and Src.AgentId = Dst.AgentId
	when not matched then
	insert
	(
		HostId,
		SystemId,
		AgentId,
		AgentState,
		StatusSummary
	)
	values
	(
		Src.HostId,
		Src.SystemId,
		Src.AgentId,
		Src.AgentState,
		Src.StatusSummary
	)
	when matched then 
		update  set
		Dst.AgentState = Src.AgentState,
		Dst.StatusSummary = Src.StatusSummary;
	