create type [XE].[ArchivedPlatformNotification] as table
(
	LogFile nvarchar(500) not null,
	LogFileCreateTS datetime2(7) not null, 
	LogFileWriteTS datetime2(7) not null, 
	[timestamp] datetime2(0) not null,
	[message] nvarchar(250) not null,
	[error_number] int not null,
	[severity] tinyint not null,
	client_hostname nvarchar(128),
	client_app_name nvarchar(128),
	username nvarchar(128)

)
GO
