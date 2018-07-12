create view [PF].[PlatformDatabaseServer] as
	select 
		s.HostId,
		s.SqlNodeId,
		s.SqlAlias,
		n.NodeName,
		n.HostName,
		HostNetworkName = n.NetworkName,
		n.HostIP,
		s.SqlInstanceName,
		s.SqlInstancePort,
		s.FileStreamRoot,
		s.DefaultDataDir,
		s.DefaultBackupDir,
		s.DefaultLogDir,
		s.AdminLogDir,
		s.SqlOperatorName,
		s.SqlOperatorPass,
		n.WinOperatorName,
		n.WinOperatorPass		
	from 
		PF.[DatabaseServerRegistry] s 
			inner join [PF].[PlatformServerRegistry] n on 
				n.NodeId = s.HostId

GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[DatabaseServer]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'View',
    @level1name = N'PlatformDatabaseServer',
    @level2type = NULL,
    @level2name = NULL

