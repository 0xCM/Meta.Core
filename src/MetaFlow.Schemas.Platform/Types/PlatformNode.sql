create type [PF].[PlatformNode] as table
(	
	NodeId nvarchar(75) not null,
	NodeName nvarchar(75) not null,
	HostName nvarchar(128) not null,
	HostIP varchar(16) null,
	NetworkName varchar(128) null,
	WinOperatorName nvarchar(128) null,
	WinOperatorPass nvarchar(128) null
)
Go

