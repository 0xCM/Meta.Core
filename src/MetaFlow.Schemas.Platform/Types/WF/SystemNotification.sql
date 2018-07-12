create type [WF].[SystemNotification] as table
(
 	EventId uniqueidentifier null,
	PairId uniqueidentifier null,
	SourceNodeId nvarchar(75) not null,
	SourceSystemId nvarchar(75) not null,
	EventType nvarchar(128) not null, 
	EventUri nvarchar(250) not null,
	CorrelationToken nvarchar(250) not null,
	SeverityLevel int not null,
	EventTS datetime2(0) not null,
	EventBody nvarchar(max) null,
	FormattedMessage nvarchar(max) not null
)