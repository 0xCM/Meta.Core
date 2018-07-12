create type [XE].[PlatformNotification] as table
(
	[timestamp] datetime2(0) not null,
	[message] nvarchar(250) not null,
	[error_number] int not null,
	[severity] tinyint not null,
	client_hostname nvarchar(128),
	client_app_name nvarchar(128),
	username nvarchar(128)

)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[XE].[XEventDataType]',
    @level0type = N'SCHEMA',
    @level0name = N'XE',
    @level1type = N'Type',
    @level1name = N'PlatformNotification',
    @level2type = NULL,
    @level2name = NULL
GO







