create procedure [PF].[UnregisterMissingHostDatabases] as
	
	set nocount on;

	declare @Removed table
	(
		DatabaseName nvarchar(128) not null, 
		DatabaseType nvarchar(75) not null
	);

	delete [PF].[HostDatabase] 
		output
			deleted.DatabaseName,
			deleted.DatabaseType
		into @Removed
		where
			DatabaseName not in (select [name] from sys.databases);

	select * from @Removed

GO	