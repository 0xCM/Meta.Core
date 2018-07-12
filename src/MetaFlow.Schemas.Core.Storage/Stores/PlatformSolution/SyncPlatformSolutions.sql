create procedure [PF].[SyncPlatformSolutions](@Solutions [T0].[PlatformSolution] readonly) as
	merge into [PF].[PlatformSolutionStore] as Dst
	using @Solutions as Src
		on Src.SystemId = Dst.SystemId
	and Src.SolutionId = Dst.SolutionId
	when not matched then insert
	(
		SystemId,
		SolutionId,
		SolutionName
	)
	values
	(
		Src.SystemId,
		Src.SolutionId,
		Src.SolutionName
	)
	when not matched by source then delete
	;



	
