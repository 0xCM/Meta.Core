create table [WF].[AgentConfigurationStore]
(
	AgentId nvarchar(75) not null,
	IsEnabled bit not null
		constraint DF_AgentConfiguration_IsEnabled default(1),
	SpinFrequency int not null
		constraint DF_AgentConfiguration_SpinFrequency default(5000),
	CreateTS datetime2(0) not null
		constraint DF_AgentConfiguration_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	SystemRV timestamp
)

	
