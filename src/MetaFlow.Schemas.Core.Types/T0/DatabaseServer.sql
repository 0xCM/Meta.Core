create type [T0].[DatabaseServer]  as table
(
 	HostId nvarchar(75) not null,
	SqlNodeId nvarchar(75) not null,
	SqlAlias nvarchar(75) null,
	NodeName nvarchar(75) not null,
	HostName nvarchar(128) not null,
	HostNetworkName varchar(128) null,
	HostIP nvarchar(75) null,
	SqlInstanceName nvarchar(128) not null,
	SqlInstancePort int null,
	FileStreamRoot nvarchar(250) null,
	DefaultDataDir nvarchar(250) null,
	DefaultLogDir nvarchar(250) null,
	DefaultBackupDir nvarchar(250) null,
	AdminLogDir nvarchar(250) null,
	SqlOperatorName nvarchar(128) null,
	SqlOperatorPass nvarchar(128) null,
	WinOperatorName nvarchar(128) null,
	WinOperatorPass nvarchar(128) null
	

)