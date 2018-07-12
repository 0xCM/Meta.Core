create procedure [XE].[StorePlatformNotifications](@Notifications [XE].[PlatformNotification] readonly) as
	

	insert [XE].[PlatformNotificationStore]
	(
		[timestamp],
		[message],
		[error_number],
		[severity],
		client_hostname,
		client_app_name,
		username
	)
	select
		[timestamp],
		[message],
		[error_number],
		[severity],
		client_hostname,
		client_app_name,
		username
	from
		@Notifications
	
