create procedure [PF].[SyncPlatformProjects](@Projects [T0].[PlatformProject] readonly) as
	merge into [PF].[PlatformProjectRegistry] as Dst
	using @Projects as Src
		on Src.SystemId = Dst.SystemId
	and Src.ProjectId = Dst.ProjectId
	when not matched then insert
	(
		SystemId,
		SolutionId,
		ProjectId,
		ProjectName,
		TargetAssembly,
		IsSqlProject,
		TargetDatabase
		
	)
	values
	(
		Src.SystemId,
		Src.SolutionId,
		Src.ProjectId,
		Src.ProjectName,
		Src.TargetAssembly,
		Src.IsSqlProject,
		Src.TargetDatabase

	)
	when matched and not exists
	(
		select 
			Src.ProjectName,
			Src.TargetAssembly,
			Src.SolutionId,
			Src.IsSqlProject,
			Src.TargetDatabase


		intersect

		select
			Dst.ProjectName,
			Dst.TargetAssembly,
			Dst.SolutionId,
			Dst.IsSqlProject,
			Dst.TargetDatabase

	)
	then update set
		Dst.ProjectName = Src.ProjectName,
		Dst.TargetAssembly =Src.TargetAssembly,
		Dst.SolutionId = Src.SolutionId,
		Dst.IsSqlProject = Src.IsSqlProject,
		Dst.TargetDatabase = Src.TargetDatabase
		
	when not matched by source then delete
	;



	
