create view [PF].[ExecutingServer] as
	select 
		s.HostId, 
		s.SqlNodeId,
		s.SqlInstanceName, 
		s.SqlInstancePort, 
		s.SqlAlias, 
		s.FileStreamRoot, 
		s.DefaultDataDir, 
		s.DefaultLogDir, 
		s.DefaultBackupDir, 
		s.AdminLogDir
	from [PF].[DatabaseServerRegistry] s 
				where s.SqlAlias in (select VariableValue from [PF].[PlatformVariableStore] where VariableName = 'SqlNode')
GO


