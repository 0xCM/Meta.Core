create procedure [PF].[SyncPlatformAgents](@Agents [T0].[PlatformAgent] readonly) as
	merge into [PF].[PlatformAgentRegistry] as Dst
	using @Agents as Src
		on Src.SystemId = Dst.SystemId
	and Src.AgentId = Dst.AgentId
	when not matched then insert
	(
		SystemId,
		AgentId
	)
	values
	(
		Src.SystemId,
		Src.AgentId
	)	
	when not matched by source then delete;



	
