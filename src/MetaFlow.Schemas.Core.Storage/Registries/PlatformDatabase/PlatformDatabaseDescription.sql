create view [PF].[PlatformDatabaseDescription] as
	select 
		s.HostId,
		n.NodeName,
		n.HostName,	
		n.HostIP,
		s.SqlNodeId,
		SqlInstancePort = isnull(s.SqlInstancePort,1433),
		s.SqlAlias,
		s.FileStreamRoot,
		db.DatabaseName,  
		db.DatabaseType,
		db.IsPrimary,
		db.IsEnabled,
		db.IsModel,
		db.IsRestore,
		s.SqlInstanceName
	from 
		[PF].[PlatformDatabaseRegistry] db 
			inner join PF.[DatabaseServerRegistry] s on s.HostId = db.ServerId
			inner join PF.[PlatformServerRegistry] n on n.NodeId = db.ServerId



