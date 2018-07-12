create table [WF].[AgentStatusLog] 
(
	EntryId bigint not null
		constraint DF_AgentStatusLog_EntryId 
			default(next value for [WF].[AgentStatusSequence]),
	HostId nvarchar(75) not null,
	SystemId nvarchar(75) not null,
	AgentId nvarchar(75) not null,
	AgentState nvarchar(75) not null,
	StatusSummary nvarchar(4000) null,
	AsOfTS datetime2 (0) generated always as row start not null,
	EndTS datetime2 (0) generated always as row end not null,
	period for system_time (AsOfTS, EndTS),

	constraint PK_AgentStatusLog primary key(EntryId),
	constraint UQ_AgentStatusLog unique(HostId,SystemId,AgentId)

)
with (system_versioning 
	= on(history_table = [WF].[AgentStatusHistory], 
			data_consistency_check=ON))

GO
create sequence [WF].[AgentStatusSequence]
	as bigint start with 1 cache 100
GO
