create procedure [SqlT].[SyncDatabases](@ServerName nvarchar(128), @Databases [SqlT].[Database] readonly) as

	with Dst as
	(
		select * from [SqlStore].[Database] where ServerName = @ServerName
	)
	merge into Dst using @Databases as Src
		on Src.DatabaseName = Dst.DatabaseName
	when not matched then insert
	(
		ServerName,
		DatabaseName,
		DatabaseType
	)
	values
	(
		Src.ServerName,
		Src.DatabaseName,
		Src.DatabaseType
	)
	when matched and not exists 
	(

		select
			Src.DatabaseType

		intersect

		select
			Dst.DatabaseType

	)		
	then update set
		Dst.DatabaseType = Src.DatabaseType
	when not matched by source then delete;

	
