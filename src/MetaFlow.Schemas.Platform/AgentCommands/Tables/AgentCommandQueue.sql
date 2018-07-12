create table [WF].[AgentCommandQueue]
(
	CommandId bigint not null 
		constraint DF_AgentComand_CommandId 
			default(next value for [WF].[AgentCommandSequence]),
	
	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	CorrelationToken nvarchar(250) not null,

	AgentId nvarchar(75) not null,
	CommandName nvarchar(75) not null,
	Arg1Name nvarchar(75) null,
	Arg1Value nvarchar(250) null,
	Arg2Name nvarchar(75) null,
	Arg2Value nvarchar(250) null,
	Arg3Name nvarchar(75) null,
	Arg3Value nvarchar(250) null,
	Arg4Name nvarchar(75) null,
	Arg4Value nvarchar(250) null,
	Arg5Name nvarchar(75) null,
	Arg5Value nvarchar(250) null,
	Arg6Name nvarchar(75) null,
	Arg6Value nvarchar(250) null,


	SubmittedTS datetime2(0) not null 
		constraint DF_AgentCommand_SubmissionTS default(getdate()),
	Dispatched bit not null
		constraint DF_AgentCommand_Dispatched default(0),
	DispatchTS datetime2(0) null,
	Completed bit not null
		constraint DF_AgentCommand_Completed default(0),
	Succeeded bit not null
		constraint DF_AgentCommand_Succeeded default(0),	
	CompletionTS datetime2(0) null,
	CompletionMessage nvarchar(1024) null,	

	CreateTS datetime2(0) not null 
		constraint DF_AgentCommand_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_AgentCommand primary key(CommandId)
)
GO
create sequence [WF].[AgentCommandSequence]
	as bigint start with 1 cache 100
GO

