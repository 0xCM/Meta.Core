create type [WF].[SystemEventCapture] as table
(
	EventTS datetime2(7) not null,
 	EventId uniqueidentifier not null,
	PairId uniqueidentifier null,
	SourceNodeId nvarchar(75) not null,
	SourceSystemId nvarchar(75) not null,
	EventType nvarchar(128) not null, 
	EventUri nvarchar(250) not null,
	CorrelationToken nvarchar(250) not null,
	SeverityLevel int not null,
	EventBody nvarchar(max) null
)