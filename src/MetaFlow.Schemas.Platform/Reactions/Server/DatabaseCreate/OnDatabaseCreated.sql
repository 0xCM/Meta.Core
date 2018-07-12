create trigger OnDatabaseCreated on all server for create_database as

	set nocount on;
	set xact_abort on
	 

	declare 
		@eventdata xml = eventdata();
	declare @DbNames table (DatabaseName sysname);

	insert [$(DatabaseName)].[PF].[DatabaseCreateLog]
	(
		ServerName,
		DatabaseName,
		LoginName,
		EventTS
	)
	output inserted.DatabaseName into @DbNames
	values
	(
		@eventdata.value('(/EVENT_INSTANCE/ServerName)[1]', 'nvarchar(128)'),
		@eventdata.value('(/EVENT_INSTANCE/DatabaseName)[1]', 'nvarchar(128)'),
		@eventdata.value('(/EVENT_INSTANCE/LoginName)[1]', 'nvarchar(128)'),
		@eventdata.value('(/EVENT_INSTANCE/PostTime)[1]', 'datetime2(0)')
	)

	

GO

