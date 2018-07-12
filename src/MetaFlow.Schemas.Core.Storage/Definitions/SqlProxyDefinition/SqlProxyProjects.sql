create function [PF].[SqlProxyProjects]() returns table as return
select 
	s.AssemblyDesignator,
	s.SystemId,
	s.ProfileName, 
	s.SourceDatabase, 
	s.TargetAssembly,
	ps.ProjectId,
	ps.ProjectName,
	ps.SolutionId,
	ProjectSystemId = ps.SystemId
		from [PF].[SystemProxyDefinition] s 
			left join [PF].[PlatformProjectRegistry] ps on 
				ps.TargetAssembly = s.TargetAssembly

