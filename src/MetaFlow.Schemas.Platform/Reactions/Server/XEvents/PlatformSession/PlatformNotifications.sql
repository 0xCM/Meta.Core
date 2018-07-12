--See: http://sqlmag.com/site-files/sqlmag.com/files/archive/sqlmag.com/content/content/142603/wpd-sql-extevtandnotif-us-sw-01112012_1.pdf
create event session PlatformNotifications 
	on server 
	add event sqlserver.error_reported 
	(
		action 
		(
			 sqlserver.session_id,
			 sqlserver.client_app_name,
			 sqlserver.client_hostname,
			 sqlserver.database_id,
			 sqlserver.username
		)
		where 
			([error_number] >= 50000)
	)
	add target 
		package0.ring_buffer,
	add target package0.event_file(
		set 
			filename=N'PlatformNotifications.xel',
			max_file_size=(5),
			max_rollover_files=(4)
			)	
	with 
		(max_dispatch_latency = 1 seconds);

GO

alter event session [PlatformNotifications] on server 
	with (startup_state=on)
GO

alter event session [PlatformNotifications] on server 
	add event sqlserver.login(SET collect_database_name=(1)
		action(sqlserver.username))
GO

