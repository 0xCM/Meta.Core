create table [XE].[PlatformNotificationStore]
(
	EventId bigint not null
		constraint PF_PlatformNotification_EventId default(next value for [XE].[PlatformNotificationSequence]),
	[timestamp] datetime2(0) not null,
	[message] nvarchar(250) not null,
	[error_number] int not null,
	[severity] tinyint not null,
	client_hostname nvarchar(128),
	client_app_name nvarchar(128),
	username nvarchar(128),
	CreateTS datetime2(0) not null
		constraint DF_PlatformNotification_CreateTS default(getdate()),
	constraint PK_PlatformNotification primary key(EventId)
)
GO

create sequence [XE].[PlatformNotificationSequence] 
	as bigint start with 1 cache 1000
