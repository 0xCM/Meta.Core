create type [PF].[SystemNotificationSpec] as table
(
 	SystemId nvarchar(75) not null,
	MessageId nvarchar(75) not null,
	Severity int not null,
	MessageTemplate nvarchar(255) not null	
)
	
