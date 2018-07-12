create table [WF].[SystemEventStore]
(
	EventRV rowversion,
	EventTS datetime2(7) not null
		constraint DF_SystemEventStore_EventTS
			default(sysdatetime()),	
	EventId uniqueidentifier not null,
	PairId uniqueidentifier null,
	SourceNodeId nvarchar(75) not null,
	SourceSystemId nvarchar(75) not null,
	EventType nvarchar(128) not null,
	EventUri nvarchar(250) not null,
	CorrelationToken nvarchar(250) not null,
	SeverityLevel int not null,
	EventBody varchar(max),
			constraint CK_SystemEvent_CommandBody check(isjson(EventBody)>0),  
	constraint PK_SystemEventStore primary key(EventRV),
	constraint UQ_SystemEventStore unique(EventId),
	
	
)
GO	
