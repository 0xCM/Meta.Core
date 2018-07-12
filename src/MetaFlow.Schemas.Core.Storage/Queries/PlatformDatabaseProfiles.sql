create function [PF].[PlatformDatabaseProfiles]() returns table as return
	select 
		RowId = row_number() over(order by ServerId, DatabaseName),
		DupIdx =row_number() over(partition by ServerId, DatabaseName order by p.ProfilePath), 
		db.ServerId,
		db.DatabaseName,
		db.DatabaseType,	 
		p.ProfilePath,
		p.ProfileXml
	from 
		[PF].[PlatformDatabaseRegistry] db 
			left join [PF].[DacProfiles]() p on 
				p.TargetServerId = db.ServerId 
			and p.TargetDatabase = db.DatabaseName
GO

