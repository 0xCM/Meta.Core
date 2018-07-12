create procedure [PF].[SyncDatabaseServers](@Servers [T0].[DatabaseServer] readonly) as
	merge into [PF].[DatabaseServerRegistry] as Dst
		using @Servers as Src on
			Src.SqlNodeId = Dst.SqlNodeId
		when not matched then insert
		(
			HostId,
			SqlNodeId,
			SqlInstanceName,
			SqlInstancePort,
			SqlAlias,
			FileStreamRoot,
			DefaultDataDir,
			DefaultLogDir,
			DefaultBackupDir,
			AdminLogDir,
			SqlOperatorName,
			SqlOperatorPass
		)
		values
		(

			Src.HostId,
			Src.SqlNodeId,
			Src.SqlInstanceName,
			Src.SqlInstancePort,
			Src.SqlAlias,
			Src.FileStreamRoot,
			Src.DefaultDataDir,
			Src.DefaultLogDir,
			Src.DefaultBackupDir,
			Src.AdminLogDir,
			Src.SqlOperatorName,
			Src.SqlOperatorPass
		)
		when matched and not exists
		(
			select 
				Src.HostId,
				Src.SqlInstanceName,
				Src.SqlInstancePort,
				Src.SqlAlias,
				Src.FileStreamRoot,
				Src.DefaultDataDir,
				Src.DefaultLogDir,
				Src.DefaultBackupDir,
				Src.AdminLogDir,
				Src.SqlOperatorName,
				Src.SqlOperatorPass

			intersect
			
			select 
				Dst.HostId,
				Dst.SqlInstanceName,
				Dst.SqlInstancePort,
				Dst.SqlAlias,
				Dst.FileStreamRoot,
				Dst.DefaultDataDir,
				Dst.DefaultLogDir,
				Dst.DefaultBackupDir,
				Dst.AdminLogDir,
				Dst.SqlOperatorName,
				Dst.SqlOperatorPass
	
		)
		then update set
			Dst.HostId = Src.HostId,
			Dst.SqlInstanceName = Src.SqlInstanceName,
			Dst.SqlInstancePort = Src.SqlInstancePort,
			Dst.SqlAlias = Src.SqlAlias,
			Dst.FileStreamRoot = Src.FileStreamRoot,
			Dst.DefaultDataDir = Src.DefaultDataDir,
			Dst.DefaultLogDir = Src.DefaultLogDir,
			Dst.DefaultBackupDir = Src.DefaultBackupDir,
			Dst.AdminLogDir = Src.AdminLogDir ,
			Dst.SqlOperatorName = Src.SqlOperatorName,
			Dst.SqlOperatorPass = Src.SqlOperatorPass
		when not matched by source then delete;
