create view [PF].[HostDatabase] as
	select 
		db.ServerId, 
		db.DatabaseName, 
		db.DatabaseType,
		db.IsPrimary,
		db.IsEnabled,
		db.IsModel,
		db.IsRestore
	from 
		[PF].[PlatformDatabaseRegistry] db 
			where db.ServerId in (select SqlNodeId from [ExecutingServer])
				and db.DatabaseType <> 'None'
				
