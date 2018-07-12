create trigger OnDatabaseDropped on all server for drop_database as
	
	set nocount on;
	
	begin transaction

		declare @eventdata xml = eventdata();			
		declare @DbNames table (DatabaseName sysname);

		insert [$(DatabaseName)].[PF].[DatabaseDropLog]
		(
			ServerName,
			DatabaseName,
			LoginName,
			EventTS
		)
		output 
			inserted.DatabaseName
		into @DbNames
		select
			@eventdata.value('(/EVENT_INSTANCE/ServerName)[1]', 'nvarchar(128)'),
			@eventdata.value('(/EVENT_INSTANCE/DatabaseName)[1]', 'nvarchar(128)'),
			@eventdata.value('(/EVENT_INSTANCE/LoginName)[1]', 'nvarchar(128)'),
			@eventdata.value('(/EVENT_INSTANCE/PostTime)[1]', 'datetime2(0)')

		
		declare @ServerId nvarchar(75) 
			= (select SqlNodeId from [$(DatabaseName)].[PF].[ExecutingServer])
		
		delete [$(DatabaseName)].[PF].[PlatformDatabaseRegistry]
			where DatabaseName in (select DatabaseName from @DbNames);

	commit transaction

GO

