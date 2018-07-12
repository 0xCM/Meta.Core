create type [T0].[PlatformDatabaseProfile] as table
(
	ServerId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	DatabaseType nvarchar(75) not null,
	ProfilePath nvarchar(250) null,
	ProfileXml nvarchar(max) null

)
	
