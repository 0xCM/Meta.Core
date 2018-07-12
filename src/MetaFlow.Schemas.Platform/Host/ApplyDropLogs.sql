create procedure [PF].[ApplyDropLogs] as

	begin transaction

	declare @Applications table(DatabaseName sysname not null);

	delete [PF].[HostDatabase]
		output 
			deleted.DatabaseName into @Applications
		where 
			DatabaseName in (select DatabaseName from [PF].[DatabaseDropLog] where Applied = 0)

	update [PF].[DatabaseDropLog] 
		set Applied = 1,
		 AppliedTS = getdate()
	where
		DatabaseName in (select DatabaseName from @Applications);

	commit transaction

	
	
	
